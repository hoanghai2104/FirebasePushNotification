using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using FirebasePushNotification.Interfaces;
using FirebasePushNotification.Models;
using Google.Apis.Auth.OAuth2;

namespace FirebasePushNotification.Implements
{
    public class PushService : BaseService, IPushService
    {
        public PushService(IConfiguration configuration) : base(configuration) { }

        public async Task<string> SendMessage(MessageRequest request)
        {
            string jsonString = File.ReadAllText(@"Keys\pushnotification-3efbb-firebase-adminsdk-cbnm0-b2e392a61d.json");

            if (FirebaseMessaging.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(jsonString)
                });
            }

            var androidNotiObj = new Dictionary<string, string>();
            androidNotiObj.Add("callback_uri", request.callback_uri);

            var obj = new Message()
            {
                Token = request._deviceToken,

                Notification = new Notification()
                {
                    Title = request.title,
                    Body = request.body,
                    ImageUrl = request.image_url,
                },
                Webpush = new WebpushConfig()
                {
                    FcmOptions = new WebpushFcmOptions()
                    {
                        Link = request.callback_uri,
                    }
                },
                Data = androidNotiObj
            };

            var response = await FirebaseMessaging.DefaultInstance.SendAsync(obj);
            return response;
        }
    }
}
