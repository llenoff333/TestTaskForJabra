using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JabraTestTasks.Utils
{
    public class HttpHelper
    {
        public async Task<HttpStatusCode> GetStatusCodeFromHttpResponseMessage(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    return response.StatusCode;
                }
            }
            catch(WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure)
                {
                    throw new Exception($"Could not connect to {url}.");
                }
                throw ex;
            }
        }

        public HttpStatusCode GetStatusCode(string url)
        {
            Task<HttpStatusCode> responseStatusCode = GetStatusCodeFromHttpResponseMessage(url);
            responseStatusCode.Wait(1000);
            return responseStatusCode.Result;
        }

        public async Task<string> CheckStatusCodeAndGetJsonFromHttpResponseMessage(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure)
                {
                    throw new Exception($"Could not connect to {url}.");
                }
                throw ex;
            }
        }

        public string GetJson(string url)
        {
            Task<string> responseJsonBody = CheckStatusCodeAndGetJsonFromHttpResponseMessage(url);
            responseJsonBody.Wait(1000);

            if (GetStatusCode(url) == HttpStatusCode.NoContent)
            {
                throw new Exception("Body does not have any content.");
                
            }
            return responseJsonBody.Result;
        }
    }
}
