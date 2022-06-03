using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Requests;

namespace Integration1COzon.Application.Domanes.Requests.Ozon
{
    /// <summary>
    /// Получение списка складов
    /// </summary>
    public sealed  class GetWarehouseListRequest : AuthRequest
    {
        internal override string EndPoint => "/v1/warehouse/list";
        internal override RequestMethod Method => RequestMethod.Post;
    }
}
