using Integration1COzon.Application.Domanes.Enum;

using JetBrains.Annotations;

using System.Collections.Generic;
using System.ComponentModel;

namespace Integration1COzon.Application.Requests
{
    /// <summary>
    /// Общий вид реквеста с авторизацией
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class AuthRequest
    {
        [NotNull]
        internal abstract string EndPoint { get; }
        internal abstract RequestMethod Method { get; }
        internal int? RecvWindow { get; set; }
        [CanBeNull]
        internal virtual IDictionary<string, object> Properties => null;
        [CanBeNull]
        internal virtual object Body { get; }
    }
}
