using JetBrains.Annotations;

namespace Integration1COzon.Application.Requests
{
    public sealed class RequestArranger
    {
        /// <summary>
        /// Пустой конструктор для создания публичных запросов из (Payload)
        /// </summary>
        public RequestArranger()
        { }
        
        public RequestArranger([NotNull] string apiKey, [NotNull] string apiSecret, [NotNull] string host)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            Host = host;
        }

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Host { get; set; }


        /// <summary>
        /// Метод создания запроса к бирже
        /// </summary>
        /// <param name="payload">Вся собранная информация запроса</param>
        /// <returns></returns>
        [NotNull]
        public IRequestContent Arrange([NotNull] AuthRequest payload)
        {
            return new PrivateRequest(payload,ApiKey, ApiSecret, Host);
        }
    }
}
