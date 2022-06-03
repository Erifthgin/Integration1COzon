using Integration1COzon.Application.Domanes.Enum;

using JetBrains.Annotations;

using System.Collections.Generic;

namespace Integration1COzon.Application.Requests
{
    public interface IRequestContent
    {
        RequestMethod Method { get; }
        [NotNull]
        string Query { get; }

        /// <summary>
        /// Authorized requests only; null otherwise
        /// </summary>
        [CanBeNull]
        IReadOnlyDictionary<string, string> Headers { get; }

        [CanBeNull]
        object Body { get; }
    }
}
