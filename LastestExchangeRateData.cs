using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CodeHelper.API.Fixer
{
    public class LastestExchangeRateData
    {
        #region Properties
        [JsonPropertyName("base")] public string BaseCurrency { get; set; } = "";
        [JsonPropertyName("date")] public string Date { get; set; } = "";
        [JsonPropertyName("rates")] public Dictionary<string, double> Rates { get; set; } = new();
        [JsonPropertyName("success")] public bool Success { get; set; }
        [JsonPropertyName("timestamp")] public int Timestamp { get; set; }
        #endregion

        #region COnstructors
        public LastestExchangeRateData(){}
        #endregion
    }
}
