using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Requests;

using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Requests.Ozon
{
    /// <summary>
    /// Запрос на обновление товаров
    /// </summary>
    public sealed class UpdateProductsStocksRequest : AuthRequest
    {
        public UpdateProductsStocksRequest(string offerId, int productId,string count,string warehouseId)
        {
            OfferId = offerId;
            ProductId = productId;
            Count = count;
            WarehouseId = warehouseId;
        }

        public string OfferId { get; set; }
        public int ProductId { get; set; }
        public string Count { get; set; }
        public string WarehouseId { get; set; }

        internal override string EndPoint => "/v2/products/stocks";
        internal override RequestMethod Method => RequestMethod.Post;
        internal override object Body
        {
            get
            {
                var arr = new Dictionary<string, string>();
                arr.Add("offer_id", OfferId);
                arr.Add("product_id", ProductId.ToString());
                arr.Add("stock", Count);
                arr.Add("warehouse_id", WarehouseId);

                var res = new Dictionary<string, object>();
                res.Add("stocks", arr);

                return res;
            }
        }
    }
}
