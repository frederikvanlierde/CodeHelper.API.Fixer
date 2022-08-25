using System.Text.Json.Serialization;

namespace CodeHelper.API.Fixer
{
    public class FluctuationRate
    {
        #region Properties
        [JsonPropertyName("change")]        public double Change { get; set; }
        [JsonPropertyName("change_pct")]    public double ChangePct { get; set; }
        [JsonPropertyName("end_rate")]      public double EndRate { get; set; }
        [JsonPropertyName("start_rate")]    public double StartRate { get; set; }
        #endregion

        #region Constructors
        public FluctuationRate() { }
        #endregion
    }
}
