using Newtonsoft.Json;

using System.Collections.Generic;

namespace Integration1COzon.Application.Domanes.Responses.Ozon
{
    /// <summary>
    /// Респонс список складов
    /// </summary>
    public sealed class GetWarehouseListResponse
    {
        [JsonProperty("result")]
        public List<WarehouseListData> Result { get; set; }
    }

    public sealed class WarehouseListData
    {
        [JsonProperty("warehouse_id")]
        public long Warehouse_id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("is_rfbs")]
        public bool IsRfbs { get; set; }
        [JsonProperty("is_able_to_set_price")]
        public bool IsAbleToSetPrice { get; set; }
        [JsonProperty("has_entrusted_acceptance")]
        public bool HasEntrustedAcceptance { get; set; }
        [JsonProperty("first_mile_type")]
        public FirstMileTypeData FirstMileType { get; set; }
        [JsonProperty("is_kgt")]
        public bool IsKgt { get; set; }
        [JsonProperty("can_print_act_in_advance")]
        public bool CanPrintActInAdvance { get; set; }
        [JsonProperty("min_working_days")]
        public int MinWorkingDays { get; set; }
        [JsonProperty("is_karantin")]
        public bool IsKarantin { get; set; }
        [JsonProperty("has_postings_limit")]
        public bool HasPostingsLimit { get; set; }
        [JsonProperty("postings_limit")]
        public int PostingsLimit { get; set; }
        [JsonProperty("working_days")]
        public List<int> WorkingDays { get; set; }
        [JsonProperty("min_postings_limit")]
        public int MinPostingsLimit { get; set; }
        [JsonProperty("is_timetable_editable")]
        public bool IsTimetableEditable { get; set; }
    }

    public class FirstMileTypeData
    {
        [JsonProperty("dropoff_point_id")]
        public string DropoffPointId { get; set; }
        [JsonProperty("dropoff_timeslot_id")]
        public int DropoffTimeslotId { get; set; }
        [JsonProperty("first_mile_is_changing")]
        public bool FirstMileIsChanging { get; set; }
        [JsonProperty("first_mile_type")]
        public string FirstMileType { get; set; }
    }
}
