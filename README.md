# CodeHelper.API.Fixer
Fixer is a lightweight and simple API for historical and current foreign exchange rates. It is used by many SMBs, large corporations, and developers every day due to its reliable data sources for real-time exchange rates.
For more information and a list of endpoints available, please see the detailed documentation pages below.

## Question?
Fixer API: <https://apilayer.com/marketplace/fixer-api>
Frederik van Lierde <https://twitter.com/@frederik_vl/>

## Version
1.0.0 : Get Symbols, Convert Amounts, Get Latest Exchange Rate Data

## Methods
* FixerHelper.GetSymbols() : Returning all available currencies.
* FixerHelper.Convert(string from, string to, double amount=1) : Returns the conversion value for the given amount
* FixerHelper.LatestExchangeRates(string baseCurrency, string symbols) : Returns real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.

## Usage
* Free Plan: 100 Requests / Daily
* Paid plans available: <https://apilayer.com/marketplace/fixer-api#pricing>