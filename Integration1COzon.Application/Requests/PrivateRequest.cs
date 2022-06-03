using Integration1COzon.Application.Domanes.Enum;
using System;
using System.Collections.Generic;


namespace Integration1COzon.Application.Requests
{
    internal class PrivateRequest : Request
    {
        private readonly string _apiClientId;
        private readonly string _apiKey;
        private readonly string _host;

        private AuthRequest _requestPayload;

        public RequestMethod Method => _requestPayload.Method;
        public PrivateRequest(AuthRequest requestPayload, string apiKey, string apiClientId, string host)
            : base(requestPayload, apiKey)
        {
            _apiClientId = apiClientId ?? throw new ArgumentNullException(nameof(apiClientId));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _host = host ?? throw new ArgumentNullException(nameof(host));

            _requestPayload = requestPayload;
        }
        public sealed override IReadOnlyDictionary<string, string> Headers
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.Add("Host", _host);
                res.Add("Api-Key", _apiKey);
                res.Add("Client-Id", _apiClientId);
                res.Add("Content-Type", "application/json");

                return res;
            }
        }
    }
}
