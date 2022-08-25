using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CodeHelper.API.Fixer
{
    public class TimeSeriesResults
    {
        #region Properties
        [JsonPropertyName("base")]          public string Base { get; set; } = "";
        [JsonPropertyName("end_date")]      public string EndDate { get; set; } = "";
        [JsonPropertyName("rates")]         public Dictionary<string, Dictionary<string, double>> Rates { get; set; }
        [JsonPropertyName("start_date")]    public string StartDate { get; set; } = "";
        [JsonPropertyName("success")]       public bool Success { get; set; }
        [JsonPropertyName("timeseries")]    public bool Timeseries { get; set; }
        #endregion

        #region Constructors
        public TimeSeriesResults() { }
        #endregion
    }
}
