using System.Text.Json;
using System.Linq;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CodeHelper.API.Fixer
{
    public class FixerHelper
    {
        #region Properties
        private readonly HttpClient _httpClient = new();
        public string APIKey { get; set; } = "";
        #endregion

        #region Constructors
        public FixerHelper() { }
        #endregion
        #region Public Methods  
        /// <summary>
        /// Returning all available currencies.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Symbol>> GetSymbols()
        {
            SymbolsResults _result = JsonSerializer.Deserialize<SymbolsResults>(await GetJson(Constants.APIURL_SYMBOLS,"")) ?? new();
            List<Symbol> _symbols = new();
            foreach (var _r in _result.Symbols)
                _symbols.Add(new() { CurrencySymbol = _r.Key, CurrencyName = _r.Value });

            return _symbols;
        }
        /// <summary>
        /// Returns the conversion value for the given amount, if conversion failes, -1 will be returned
        /// </summary>        
        public async Task<double> Convert(string from, string to, double amount=1)
        {
            ConvertResult _result = JsonSerializer.Deserialize<ConvertResult>(await GetJson(Constants.APIURL_CONVERT, "from=" + from + "&to=" + to + "&amount=" + amount.ToString())) ?? new();
            return _result.Success ? _result.Result : -1;
        }

        /// <summary>
        /// Returns real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.
        /// </summary>
        /// <param name="baseCurrency">string: Enter the three-letter currency code of your preferred base currency.</param>
        /// <param name="symbols">string: Enter a list of comma-separated currency codes to limit output currencies.</param>
        /// <returns></returns>
        public async Task<List<RateInfo>> LatestExchangeRates(string baseCurrency, string symbols)
        {
            LastestExchangeRateData _result = JsonSerializer.Deserialize<LastestExchangeRateData>(await GetJson(Constants.APIURL_LATEST, "base=" + baseCurrency + "&symbols=" + symbols.Replace(" ","").Trim() )) ?? new();
            List<RateInfo> _rates = new();
            foreach (var _r in _result.Rates)
                _rates.Add(new() { BaseCurrency = _result.BaseCurrency, Currency = _r.Key, Rate = _r.Value, Timestamp = _result.Timestamp });

            return _rates;
        }
        #endregion

        #region Private Methods
        private void SetAuthorizationHeader()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("apikey"))
                _httpClient.DefaultRequestHeaders.Add("apikey", this.APIKey);
        }
        private async Task<string> GetJson(string apiBaseUrl, string apiParameters)
        {
            SetAuthorizationHeader();
            var _task = await _httpClient.GetAsync(apiBaseUrl + apiParameters);
            return await _task.Content.ReadAsStringAsync();
        }
        #endregion
    }
}