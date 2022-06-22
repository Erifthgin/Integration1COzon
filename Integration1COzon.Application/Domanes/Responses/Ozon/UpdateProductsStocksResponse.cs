using Newtonsoft.Json;

using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Responses.Ozon
{
    /// <summary>
    /// Респонс обновление товара на складе
    /// </summary>
    public sealed class UpdateProductsStocksResponse
    {
        [JsonProperty("result")]
        public IReadOnlyList<UpdateProductsStocksData> Result { get; set; }
    }

    public sealed class UpdateProductsStocksData
    {
        [JsonProperty("warehouse_id")]
        public long WarehouseId { get; set; }
        [JsonProperty("product_id")]
        public int ProductId { get; set; }
        [JsonProperty("offer_id")]
        public string OfferId { get; set; }
        [JsonProperty("updated")]
        public bool Updated { get; set; }
        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }
}
