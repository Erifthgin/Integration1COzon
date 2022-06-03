

namespace Integration1COzon.Application.Handler.JsonHandlers
{
    public interface IDataHandler<out T> : ISingleMessageHandler<T>
    {
    }
}
