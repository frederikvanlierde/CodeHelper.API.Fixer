using System.Text.Json.Serialization;
namespace CodeHelper.API.Fixer
{
    public class RateInfo
    {
        #region Properties
        public string? BaseCurrency { get; set; }
        public string? Currency { get; set; }
        [JsonPropertyName("rate")]          public double Rate { get; set; }
        [JsonPropertyName("timestamp")]     public int Timestamp { get; set; }
        #endregion
        #region Constructors
        public RateInfo() { }
        #endregion
    }
}
