using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.Fixer
{    
    public class FluctuationResult
    {
        #region Properties
        [JsonPropertyName("base")]          public string Base { get; set; }
        [JsonPropertyName("end_date")]      public string EndDate { get; set; }
        [JsonPropertyName("fluctuation")]   public bool Fluctuation { get; set; }
        [JsonPropertyName("rates")]         public Dictionary<string, FluctuationRate>  Rates { get; set; }
        [JsonPropertyName("start_date")]    public string StartDate { get; set; }
        [JsonPropertyName("success")]       public bool Success { get; set; }
        #endregion

        #region Constructors
        public FluctuationResult(){ }
        #endregion
    }
}
