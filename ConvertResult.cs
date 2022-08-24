using System.Text.Json.Serialization;

namespace CodeHelper.API.Fixer
{
    public class ConvertResult
    {
        #region Properties
        [JsonPropertyName("date")]          public string Date { get; set; } = "";
        [JsonPropertyName("historical")]    public string Historical { get; set; } = "";
        [JsonPropertyName("info")]          public RateInfo Info { get; set; } = new();
        [JsonPropertyName("result")]        public double Result { get; set; }
        [JsonPropertyName("success")]       public bool Success { get; set; }
        #endregion

        #region Constructors
        public ConvertResult() { }
        #endregion
    }
}
