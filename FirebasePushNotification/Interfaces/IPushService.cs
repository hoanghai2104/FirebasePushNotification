using FirebasePushNotification.Models;

namespace FirebasePushNotification.Interfaces
{
    public interface IPushService
    {
        public Task<string> SendMessage(MessageRequest request);
    }
}
