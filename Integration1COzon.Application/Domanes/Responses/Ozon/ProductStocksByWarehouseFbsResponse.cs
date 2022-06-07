using Newtonsoft.Json;

using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Responses.Ozon
{
    /// <summary>
    /// Респонс ответа с информацией остатков со складов
    /// </summary>
    public sealed class ProductStocksByWarehouseFbsResponse
    {
        [JsonProperty("result")]
        public List<ProductStocksByWarehouseData> Result { get; set; }
    }
    public class ProductStocksByWarehouseData
    {
        [JsonProperty("product_id")]
        public int ProductId { get; set; }
        [JsonProperty("present")]
        public int Present { get; set; }
        [JsonProperty("reserved")]
        public int Reserved { get; set; }
        [JsonProperty("fbs_sku")]
        public int FbsSku { get; set; }
        [JsonProperty("warehouse_id")]
        public string WarehouseId { get; set; }
        [JsonProperty("warehouse_name")]
        public string WarehouseName { get; set; }
    }
}
