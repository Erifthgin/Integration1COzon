using Integration1COzon.Application.Abstractions.Ozon;
using Integration1COzon.Application.Domanes.Responses.Ozon;
using Integration1COzon.Application.Handler.JsonHandlers;

namespace Integration1COzon.Ozon
{
    /// <summary>
    /// Фабрика
    /// </summary>
    public sealed class OzonHandlerFactory : IOzonHandlerFactory
    {
        public ISingleMessageHandler<GetWarehouseListResponse> CreateGetWarehouseListResponse() => new BaseJsonHandler<GetWarehouseListResponse>();
        public ISingleMessageHandler<GetProductInfoResopnse> CreateGetProductInfoResopnse() => new BaseJsonHandler<GetProductInfoResopnse>();
        public ISingleMessageHandler<ProductStocksByWarehouseFbsResponse> CreateProductStocksByWarehouseFbsResponse() => new BaseJsonHandler<ProductStocksByWarehouseFbsResponse>();
        public ISingleMessageHandler<UpdateProductsStocksResponse> CreateUpdateProductsStocksResponse() => new BaseJsonHandler<UpdateProductsStocksResponse>();
    }
}
