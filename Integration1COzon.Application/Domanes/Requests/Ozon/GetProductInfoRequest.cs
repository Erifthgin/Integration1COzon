using Integration1COzon.Application.Domanes.Enum;
using Integration1COzon.Application.Requests;

using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Requests.Ozon
{
    /// <summary>
    /// Запрос на получение инфорамции о товаре
    /// </summary>
    public sealed class GetProductInfoRequest : AuthRequest
    {
        public GetProductInfoRequest(string offerId)
        {
            OfferId = offerId;
        }

        public string OfferId { get; set; }
        public string ProductId { get; set; }
        public string Sku { get; set; }

        internal override string EndPoint => "/v2/product/info";
        internal override RequestMethod Method => RequestMethod.Post;
        internal override object Body
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.Add("offer_id", OfferId);
                res.Add("product_id", ProductId);
                res.Add("sku", Sku);

                return res;
            }
        }
    }
}
