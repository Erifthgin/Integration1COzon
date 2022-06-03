

namespace Integration1COzon.Application.Handler.JsonHandlers
{
    public interface ISingleMessageHandler<out T>
    {
        T HandleSingle(string message);
    }
}
