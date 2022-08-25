using System.Text.Json;
using System.Net.Http;
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
        /// Query for historical rates for a given date
        /// </summary>
        /// <param name="date">Required: yyyy-mm-dd A date in the past for which historical rates are requested..</param>
        /// <param name="baseCurrency">Optional: The three-letter currency code of your preferred base currency.</param>
        /// <paran name="symbols">Optional: a list of comma-separated currency codes to limit output currencies.</paran>
        /// <returns>A List of historical rates.</returns>
        public async Task<List<ExchangeRates>> GetHistoricalRates(string date, string baseCurrency = "", string symbols = "")
        {
            ConvertResult _apiResult = JsonSerializer.Deserialize<ConvertResult>(await GetJson(Constants.APIURL_HISTORICALRATES.Replace("{date}", date), "base=" + baseCurrency + "&symbols=" + symbols.Replace(" ", "").Trim())) ?? new();
            List<ExchangeRates> _result = new();
            foreach (var _r in _apiResult.Rates)
                _result.Add(new() { BseSymbol = _apiResult.BaseSymbol, ExchangeDate = _apiResult.Date, Symbol = _r.Key, Rate = _r.Value });
            return _result;
        }


        /// <summary>
        /// Query for daily historical rates between two dates of your choice, with a maximum time frame of 365 days.
        /// </summary>
        /// <param name="startDate">Required: yyyy-mm-dd The start date of your preferred timeframe.</param>
        /// <param name="end_date">>Required: yyyy-mm-dd The end date of your preferred timeframe.</param>
        /// <param name="baseCurrency">Optional: The three-letter currency code of your preferred base currency.</param>
        /// <paran name="symbols">Optional: a list of comma-separated currency codes to limit output currencies.</paran>
        /// <returns>Daily historical rates.  Use:timeSeriesResults["yyyy-mm-dd]["USD] >= Rate </returns>
        public async Task<TimeSeriesResults> TimeSeries(string startDate, string endDate, string baseCurrency = "", string symbols="")
        {
            return JsonSerializer.Deserialize<TimeSeriesResults>(await GetJson(Constants.APIURL_TIMESERIES, "start_date=" + startDate + "&end_date=" + endDate + "&base=" + baseCurrency + "&symbols=" + symbols.Replace(" ","").Trim() )) ?? new();
        }
        
        /// <summary>
        /// Returns fluctuation data between two specified dates for all available or a specific set of currencies.
        /// Please note that the maximum allowed timeframe is 365 days.
        /// </summary>
        /// <param name="startDate">string: yyyy-mm-dd The start date of your preferred timeframe.</param>
        /// <param name="end_date">>string: yyyy-mm-dd The end date of your preferred timeframe.</param>
        /// <param name="baseCurrency">Enter the three-letter currency code of your preferred base currency.</param>
        /// <returns></returns>
        public async Task<FluctuationResult> Fluctuation(string startDate, string endDate, string baseCurrency = "")
        {
            return JsonSerializer.Deserialize<FluctuationResult>(await GetJson(Constants.APIURL_FLUCTUATION, "start_date=" + startDate + "&end_date=" + endDate + "&base=" + baseCurrency)) ?? new();
        }
        
        /// <summary>
        /// Returning all available currencies.
        /// </summary>
        /// <returns>List of all available currencies.</returns>
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
        /// <param name="from">Required: The three-letter currency code of the currency you would like to convert from.</param>
        /// <param name="to">Required: The three-letter currency code of the currency you would like to convert to.</param>
        /// <param name="amount">Required: The amount to be converted.</param>
        /// <param name="="date">Optional: Specify a date (format YYYY-MM-DD) to use historical rates for this conversion.
        /// /// <returns>The converted value (double)</returns>
        public async Task<double> Convert(string from, string to, double amount=1, string date="")
        {
            ConvertResult _result = JsonSerializer.Deserialize<ConvertResult>(await GetJson(Constants.APIURL_CONVERT, "from=" + from + "&to=" + to + "&amount=" + amount.ToString() + "&date=" + date)) ?? new();
            return _result.Success ? _result.Result : -1;
        }

        /// <summary>
        /// Returns real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.
        /// </summary>
        /// <param name="baseCurrency">Optional: Enter the three-letter currency code of your preferred base currency.</param>
        /// <param name="symbols">Optional: Enter a list of comma-separated currency codes to limit output currencies.</param>
        /// <returns>List of real-time exchange rate data </returns>
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