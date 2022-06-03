using Integration1COzon.Application.Domanes.Responses.Ozon;
using Integration1COzon.Application.Handler.JsonHandlers;

using JetBrains.Annotations;

namespace Integration1COzon.Application.Abstractions.Ozon
{
    /// <summary>
    /// Интерфейс фабрики
    /// </summary>
    public interface IOzonHandlerFactory
    {
        [NotNull]
        ISingleMessageHandler<GetWarehouseListResponse> CreateGetWarehouseListResponse();
        [NotNull]
        ISingleMessageHandler<GetProductInfoResopnse> CreateGetProductInfoResopnse();
        [NotNull]
        ISingleMessageHandler<ProductStocksByWarehouseFbsResponse> CreateProductStocksByWarehouseFbsResponse();
        
    }
}
