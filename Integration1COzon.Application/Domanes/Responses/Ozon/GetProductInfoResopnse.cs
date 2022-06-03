using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Responses.Ozon
{
    /// <summary>
    /// Информация о товаре по id
    /// </summary>
    public sealed class GetProductInfoResopnse
    {
        [JsonProperty("result")]
        public ProductInfoData Result { get; set; }
    }
    public class ProductInfoData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("offer_id")]
        public string Offerid { get; set; }
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("buybox_price")]
        public string Buyboxprice { get; set; }
        [JsonProperty("category_id")]
        public int Categoryid { get; set; }
        [JsonProperty("created_at")]
        public DateTime Createdat { get; set; }
        [JsonProperty("images")]
        public List<object> Images { get; set; }
        [JsonProperty("marketing_price")]
        public string Marketingprice { get; set; }
        [JsonProperty("min_ozon_price")]
        public string MinOzonprice { get; set; }
        [JsonProperty("old_price")]
        public string Oldprice { get; set; }
        [JsonProperty("premium_price")]
        public string PremiumPrice { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("recommended_price")]
        public string RecommendedPrice { get; set; }
        [JsonProperty("min_price")]
        public string MinPrice { get; set; }
        [JsonProperty("sources")]
        public List<SourceData> Sources { get; set; }
        [JsonProperty("stocks")]
        public StocksData Stocks { get; set; }
        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
        [JsonProperty("vat")]
        public string Vat { get; set; }
        [JsonProperty("visible")]
        public bool Visible { get; set; }
        [JsonProperty("visibility_details")]
        public VisibilityDetailsData Visibilitydetails { get; set; }
        [JsonProperty("price_index")]
        public string Priceindex { get; set; }
        [JsonProperty("commissions")]
        public List<CommissionData> Commissions { get; set; }
        [JsonProperty("volume_weight")]
        public double Volum_weight { get; set; }
        [JsonProperty("is_prepayment")]
        public bool Isprepayment { get; set; }
        [JsonProperty("is_prepayment_allowed")]
        public bool Is_prepaymentallowed { get; set; }
        [JsonProperty("images360")]
        public List<object> Images360 { get; set; }
        [JsonProperty("color_image")]
        public string Colorimage { get; set; }
        [JsonProperty("primary_image")]
        public string Primaryimage { get; set; }
        [JsonProperty("status")]
        public StatusData Status { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("service_type")]
        public string ServicEtype { get; set; }
        [JsonProperty("fbo_sku")]
        public string FboSku { get; set; }
        [JsonProperty("fbs_sku")]
        public string FbsSku { get; set; }
    }
    public class CommissionData
    {
        [JsonProperty("percent")]
        public int Percent { get; set; }
        [JsonProperty("min_value")]
        public int MinValue { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("sale_schema")]
        public string SaleShema { get; set; }
        [JsonProperty("delivery_amount")]
        public int DeliveryAmount { get; set; }
        [JsonProperty("return_amount")]
        public int ReturnAmount { get; set; }
    }
    public class SourceData
    {
        [JsonProperty("is_enabled")]
        public bool IsEnabled { get; set; }
        [JsonProperty("sku")]
        public int Sku { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class StatusData
    {
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("state_failed")]
        public string Statefailed { get; set; }
        [JsonProperty("moderate_status")]
        public string ModerateStatus { get; set; }
        [JsonProperty("decline_reasons")]
        public List<object> DeclineReasons { get; set; }
        [JsonProperty("validation_state")]
        public string ValidationState { get; set; }
        [JsonProperty("state_name")]
        public string StateName { get; set; }
        [JsonProperty("state_description")]
        public string StateDescription { get; set; }
        [JsonProperty("is_failed")]
        public bool IsFailed { get; set; }
        [JsonProperty("is_created")]
        public bool IsCreated { get; set; }
        [JsonProperty("state_tooltip")]
        public string StateTooltip { get; set; }
        [JsonProperty("item_errors")]
        public List<object> ItemErrors { get; set; }
        [JsonProperty("state_updated_at")]
        public DateTime StateUpdatedAt { get; set; }
    }

    public class StocksData
    {
        [JsonProperty("coming")]
        public int Coming { get; set; }
        [JsonProperty("present")]
        public int Present { get; set; }
        [JsonProperty("reserved")]
        public int Reserved { get; set; }
    }

    public class VisibilityDetailsData
    {
        [JsonProperty("has_price")]
        public bool Hasprice { get; set; }
        [JsonProperty("has_stock")]
        public bool Hasstock { get; set; }
        [JsonProperty("active_product")]
        public bool ActiveProduct { get; set; }
    }
}
