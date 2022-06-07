using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Requests;

using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Requests.Ozon
{
    /// <summary>
    /// Запрос на получение остатков со склада по выбранному товару
    /// </summary>
    public class ProductStocksByWarehouseFbsRequest : AuthRequest
    {
        public ProductStocksByWarehouseFbsRequest(string fbs_sku)
        {
            FbsSku = fbs_sku;
        }

        public string FbsSku { get; set; }

        internal override string EndPoint => "/v1/product/info/stocks-by-warehouse/fbs";
        internal override RequestMethod Method => RequestMethod.Post;
        internal override object Body
        {
            get
            {
                var res = new Dictionary<string, object>();
                var arr = new List<string>();
                arr.Add(FbsSku);
                res.Add("fbs_sku", arr);

                return res;
            }
        }
    }
}
