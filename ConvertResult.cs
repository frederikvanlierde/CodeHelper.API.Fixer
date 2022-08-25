using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.Fixer
{
    public class ConvertResult
    {
        #region Properties
        [JsonPropertyName("date")]          public string Date { get; set; } = "";
        [JsonPropertyName("historical")]    public bool Historical { get; set; }
        [JsonPropertyName("info")]          public RateInfo Info { get; set; } = new();
        [JsonPropertyName("result")]        public double Result { get; set; }
        [JsonPropertyName("success")]       public bool Success { get; set; }
        [JsonPropertyName("base")]          public string BaseSymbol { get; set; } = "";
        [JsonPropertyName("rates")]         public Dictionary<string, double> Rates { get; set; }

        #endregion

        #region Constructors
        public ConvertResult() { }
        #endregion
    }
}
