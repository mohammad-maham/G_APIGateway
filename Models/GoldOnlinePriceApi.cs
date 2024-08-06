using Newtonsoft.Json;

namespace GoldAPIGateway.Models
{
    public partial class GoldOnlinePriceApi
    {
        [JsonProperty("result")]
        public Result? Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("last_page")]
        public long LastPage { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("data")]
        public List<GoldOnlinePriceApiData>? Data { get; set; }
    }

    public partial class GoldOnlinePriceApiData
    {
        [JsonProperty("key")]
        public long Key { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("عنوان")]
        public string? Subject { get; set; }

        [JsonProperty("قیمت")]
        public long CurrentPrice { get; set; }

        [JsonProperty("تغییر")]
        public string? SwappPercentage { get; set; }

        [JsonProperty("بیشترین")]
        public long Highest { get; set; }

        [JsonProperty("کمترین")]
        public long Lowest { get; set; }

        [JsonProperty("تاریخ بروزرسانی")]
        public DateTime UpdateDateTime { get; set; }
    }
}
