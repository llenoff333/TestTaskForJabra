namespace JabraTestTasks.Utils
{
    public class Family
    {
        public string description { get; set; }
        public int? familyId { get; set; }
        public string name { get; set; }
        public string pageUrl { get; set; }
        public string supportPageUrl { get; set; }
        public bool? hasBluetoothPairingGuide { get; set; }
        public string productName { get; set; }
        public string segmentType { get; set; }
        public string summary { get; set; }
        public string thumbnailUrl { get; set; }
        public string title { get; set; }
        public string uniqueSellingPoint { get; set; }

        public bool IsAnyFieldIsNullOrEmpty()
        {
            if(description == null || description == "")
            {
                return true;
            }
            if (familyId == null)
            {
                return true;
            }
            if (name == null || name == "")
            {
                return true;
            }
            if (pageUrl == null || pageUrl == "")
            {
                return true;
            }
            if (supportPageUrl == null || supportPageUrl == "")
            {
                return true;
            }
            if (hasBluetoothPairingGuide == null)
            {
                return true;
            }
            if (productName == null || productName == "")
            {
                return true;
            }
            if (segmentType == null || segmentType == "")
            {
                return true;
            }
            if (summary == null || summary == "")
            {
                return true;
            }
            if (thumbnailUrl == null || thumbnailUrl == "")
            {
                return true;
            }
            if (title == null || title == "")
            {
                return true;
            }
            if (uniqueSellingPoint == null || uniqueSellingPoint == "")
            {
                return true;
            }
            return false;
        }

        public string GetNotificationAboutFieldsWithNullOrEmptyValue()
        {
            string notificationAboutFieldsWithNullOrEmptyValue = string.Empty;

            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("description", description);

            if (familyId == null)
            { notificationAboutFieldsWithNullOrEmptyValue += "familyId is null.\n"; }

            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("name", name);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("pageUrl", pageUrl);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("supportPageUrl", supportPageUrl);

            if (hasBluetoothPairingGuide == null)
            { notificationAboutFieldsWithNullOrEmptyValue += "hasBluetoothPairingGuide is null.\n"; }

            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("productName", productName);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("segmentType", segmentType);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("summary", summary);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("thumbnailUrl", thumbnailUrl);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("title", title);
            notificationAboutFieldsWithNullOrEmptyValue += CheckIfStringIsEmpty("uniqueSellingPoint", uniqueSellingPoint);

            return notificationAboutFieldsWithNullOrEmptyValue;
        }

        private string CheckIfStringIsEmpty(string fieldName, string stringValue)
        {
            string notificationErrorString = string.Empty;
            if (stringValue == null)
            { notificationErrorString += $"{fieldName} is null.\n"; }
            if (stringValue == "")
            { notificationErrorString += $"{fieldName} is empty.\n"; }
            return notificationErrorString;
        }
    }
}
