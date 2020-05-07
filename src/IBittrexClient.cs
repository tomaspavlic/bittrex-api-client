using System.Threading.Tasks;

namespace Topdev.Bittrex
{
    public interface IBittrexClient
    {
        /// <summary>
        /// Retrieve recent candles for a specific market and candle interval. 
        /// The maximum age of the returned candles depends on the interval as follows: (MINUTE_1: 1 day, MINUTE_5: 1 day, HOUR_1: 31 days, DAY_1: 366 days).
        /// Candles for intervals without any trading activity are omitted.
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve candles for</param>
        /// <param name="interval">desired time interval between candles</param>
        /// <returns></returns>
        Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval);
        
        /// <summary>
        /// Retrieve recent candles for a specific market and candle interval. 
        /// The maximum age of the returned candles depends on the interval as follows: (MINUTE_1: 1 day, MINUTE_5: 1 day, HOUR_1: 31 days, DAY_1: 366 days).
        /// Candles for intervals without any trading activity are omitted.
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve candles for</param>
        /// <param name="interval">desired time interval between candles</param>
        /// <param name="year">desired year to start from</param>
        /// <param name="month">desired month to start from (if applicable)</param>
        /// <param name="day">desired day to start from (if applicable)</param>
        /// <returns></returns>
        Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval, int year, int month, int day);

        /// <summary>
        /// List markets.
        /// </summary>
        /// <returns></returns>
        Task<Market[]> GetMarketsAsync();

        /// <summary>
        /// List summaries of the last 24 hours of activity for all markets. 
        /// ** Note: baseVolume is being deprecated and will be removed in favor of quoteVolume
        /// </summary>
        /// <returns></returns>
        Task<Summary[]> GetMarketSummariesAsync();

        /// <summary>
        /// List tickers for all markets.
        /// </summary>
        /// <returns></returns>
        Task<Ticker[]> GetMarketTickersAsync();

        /// <summary>
        /// Retrieve information for a specific market.
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve ticker for</param>
        /// <returns></returns>
        Task<Market> GetMarketAsync(string marketSymbol);

        /// <summary>
        /// Retrieve summary of the last 24 hours of activity for a specific market. 
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve ticker for</param>
        /// <returns></returns>
        Task<Summary> GetMarketSummaryAsync(string marketSymbol);

        /// <summary>
        /// Retrieve the order book for a specific market.
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve ticker for</param>
        /// <returns></returns>
        Task<OrderBook> GetMarketOrderBookAsync(string marketSymbol);

        /// <summary>
        /// Retrieve the recent trades for a specific market.
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve ticker for</param>
        /// <returns></returns>
        Task<Trade[]> GetMarketTradesAsync(string marketSymbol);

        /// <summary>
        /// Retrieve the ticker for a specific market.
        /// </summary>
        /// <param name="marketSymbol">symbol of market to retrieve ticker for</param>
        /// <returns></returns>
        Task<Ticker> GetMarketTickerAsync(string marketSymbol);
    }
}