# CodeHelper.API.Fixer
Fixer is a lightweight and simple API for historical and current foreign exchange rates. It is used by many SMBs, large corporations, and developers every day due to its reliable data sources for real-time exchange rates.
For more information and a list of endpoints available, please see the detailed documentation pages below.

## Question?
Fixer API: <https://apilayer.com/marketplace/fixer-api>
Frederik van Lierde <https://twitter.com/@frederik_vl/>
GitHub <https://github.com/frederikvanlierde/CodeHelper.API.Fixer>
NuGet <https://www.nuget.org/packages/CodeHelper.API.Fixer>

## Version
1.1.0 : Fluctuations, TimeSeries, Get Historical Rates
1.0.0 : Get Symbols, Convert Amounts, Get Latest Exchange Rate Data

## Methods
* FixerHelper.GetSymbols() : Returning all available currencies.
* FixerHelper.Convert(string from, string to, double amount=1) : Returns the conversion value for the given amount
* FixerHelper.LatestExchangeRates(string baseCurrency, string symbols) : Returns real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.
* FixerHelper.GetHistoricalRates(string date, string baseCurrency = "", string symbols = "") : Query for historical rates for a given date.
* FixerHelper.TimeSeries(string startDate, string endDate, string baseCurrency = "", string symbols="") : Query for daily historical rates between two dates of your choice.
* FixerHelper.Fluctuation(string startDate, string endDate, string baseCurrency = "") : Returns fluctuation data between two specified dates for all available or a specific set of currencies.

## Authentication
Fixer API uses API keys to authenticate requests. You can view and manage your API keys in the Accounts page.

Your API keys carry many privileges, so be sure to keep them secure! Do not share your secret API keys in publicly accessible areas such as GitHub, client-side code, and so forth.

All requests made to the API must hold a custom HTTP header named "apikey". Implementation differs with each programming language. Below are some samples.

All API requests must be made over HTTPS. Calls made over plain HTTP will fail. API requests without authentication will also fail.

## Usage
* Free Plan: 100 Requests / Daily
* Paid plans available: <https://apilayer.com/marketplace/fixer-api#pricing>