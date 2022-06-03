using Integration1COzon.Application.Domanes.Enum;

using JetBrains.Annotations;

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Integration1COzon.Application.Requests
{
    /// <summary>
    /// Общий вид реквеста для озона
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Request : IRequestContent
    {
        [NotNull]
        private readonly AuthRequest _requestPayload;
        private readonly string _apiKey;
        public Request([NotNull] AuthRequest requestPayload, [CanBeNull] string apiKey)
        {
            _requestPayload = requestPayload ?? throw new ArgumentNullException(nameof(requestPayload));
            _apiKey = apiKey;
        }
        public RequestMethod Method => _requestPayload.Method;
        public virtual IReadOnlyDictionary<string, string> Headers => null;
        public object Body => _requestPayload.Body;
        public string Query => _requestPayload.EndPoint;
    }
}
