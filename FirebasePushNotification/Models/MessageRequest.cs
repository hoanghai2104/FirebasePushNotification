namespace FirebasePushNotification.Models
{
    public class MessageRequest
    {
        public string title { get; set; }
        public string body { get; set; }
        public string callback_uri { get; set; }
        public string image_url { get; set; }
        public string _deviceToken { get; set; }
    }
}
