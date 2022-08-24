using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace CodeHelper.API.Fixer
{
    public class SymbolsResults
    {
        #region Properties
        [JsonPropertyName("success")]   public bool Success { get; set; }
        [JsonPropertyName("symbols")] public Dictionary<string, string> Symbols { get; set; } = new();
        #endregion

        #region Constructors
        public SymbolsResults() { }
        #endregion
    }
}
