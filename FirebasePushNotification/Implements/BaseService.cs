using FirebasePushNotification.Interfaces;

namespace FirebasePushNotification.Implements
{
    public class BaseService: IBaseService
    {
        protected readonly IConfiguration _configuration;
        public BaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Dispose()
        {

        }
    }
}
