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

        /// <summary>
        /// Pings the service.
        /// </summary>
        /// <returns></returns>
        Task<long> PingAsync();

        /// <summary>
        /// Retrieve information for the account associated with the request. 
        /// For now, it only echoes the subaccount if one was specified in the header, 
        /// which can be used to verify that one is operating on the intended account. 
        /// More fields will be added later.
        /// </summary>
        /// <returns></returns>
        Task<Account> GetAccountAsync();

        /// <summary>
        /// Get 30 day volume for account.
        /// </summary>
        /// <returns></returns>
        Task<Volume> GetAccountVolumeAsync();

        /// <summary>
        /// List deposit addresses that have been requested or provisioned.
        /// </summary>
        /// <returns></returns>
        Task<Address[]> GetAddressesAsync();

        /// <summary>
        /// Request provisioning of a deposit address for a currency for which no address has been requested or provisioned.
        /// </summary>
        /// <param name="currencySymbol"></param>
        /// <returns>Provisioned address</returns>
        Task<Address> ProvisionNewAddressAsync(string currencySymbol);

        /// <summary>
        /// Retrieve the status of the deposit address for a particular currency for which one has been requested or provisioned.
        /// </summary>
        /// <param name="currencySymbol"></param>
        /// <returns></returns>
        Task<Address> GetAddressAsync(string currencySymbol);

        /// <summary>
        /// List account balances across available currencies. Returns a Balance entry for each currency for which there is either a balance or an address.
        /// </summary>
        /// <returns></returns>
        Task<Balance[]> GetBalancesAsync();

        /// <summary>
        /// Retrieve account balance for a specific currency. Request will always succeed when the currency exists, regardless of whether there is a balance or address.
        /// </summary>
        /// <param name="currencySymbol"></param>
        /// <returns></returns>
        Task<Balance> GetBalanceAsync(string currencySymbol);

        /// <summary>
        /// List currencies.
        /// </summary>
        /// <returns></returns>
        Task<Currency[]> GetCurrenciesAsync();

        /// <summary>
        /// Retrieve info on a specified currency.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<Currency> GetCurrencyAsync(string symbol);

        /// <summary>
        /// Retrieve information on a specific conditional order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ConditionalOrder> GetConditionalOrderAsync(string orderId);

        /// <summary>
        /// Cancel a conditional order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task DeleteConditionalOrderAsync(string orderId);

        /// <summary>
        /// List closed conditional orders.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<ConditionalOrder[]> GetConditionalOrdersAsync(ConditionalOrderState state);

        /// <summary>
        /// Create a new conditional order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<ConditionalOrder> CreateConditionalOrderAsync(ConditionalOrder order);
    }
}