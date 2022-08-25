
namespace CodeHelper.API.Fixer
{
    public class ExchangeRates
    {
        #region Properties
        public string BseSymbol { get; set; }
        public string ExchangeDate { get; set; }
        public string Symbol { get; set; }
        public double Rate { get; set; }
        #endregion

        #region Constructors
        public ExchangeRates() { }
        #endregion
    }
}
