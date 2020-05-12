using System;
using System.Collections.Generic;
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
        Task<IEnumerable<Candle>> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval);
        
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
        Task<IEnumerable<Candle>> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval, int year, int month, int day);

        /// <summary>
        /// List markets.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Market>> GetMarketsAsync();

        /// <summary>
        /// List summaries of the last 24 hours of activity for all markets. 
        /// ** Note: baseVolume is being deprecated and will be removed in favor of quoteVolume
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Summary>> GetMarketSummariesAsync();

        /// <summary>
        /// List tickers for all markets.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ticker>> GetMarketTickersAsync();

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
        Task<IEnumerable<Trade>> GetMarketTradesAsync(string marketSymbol);

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
        Task<IEnumerable<Address>> GetAddressesAsync();

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
        Task<IEnumerable<Balance>> GetBalancesAsync();

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
        Task<IEnumerable<Currency>> GetCurrenciesAsync();

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
        IAsyncEnumerable<ConditionalOrder> GetConditionalOrdersAsync(State state);

        /// <summary>
        /// Create a new conditional order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<ConditionalOrder> CreateConditionalOrderAsync(NewConditionalOrder order);

        /// <summary>
        /// List closed/open orders.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        IAsyncEnumerable<Order> GetOrdersAsync(State state);

        /// <summary>
        /// Retrieve information on a specific order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> GetOrderAsync(string orderId);

        /// <summary>
        /// Cancel an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> DeleteOrderAsync(string orderId);

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> CreateOrderAsync(NewOrder order);

        /// <summary>
        /// List open deposits. Results are sorted in inverse order of UpdatedAt, and are limited to the first 1000.
        /// </summary>
        /// <param name="state">filter by an open deposit status (optional)</param>
        /// <returns></returns>
        Task<IEnumerable<Deposit>> GetDepositsAsync(State state);

        /// <summary>
        /// Retrieve information for a specific deposit.
        /// </summary>
        /// <param name="depositId"></param>
        /// <returns></returns>
        Task<Deposit> GetDepositAsync(string depositId);

        /// <summary>
        /// Retrieves all deposits for this account with the given TxId
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        Task<Deposit> GetDepositByTxIdAsync(string txId);

        /// <summary>
        /// List subaccounts. 
        /// (NOTE: This API is limited to partners and not available for traders.)
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<Subaccount> GetSubaccountsAsync();

        /// <summary>
        /// Create a new subaccount. 
        /// (NOTE: This API is limited to partners and not available for traders.)
        /// </summary>
        /// <param name="newSubaccount"></param>
        /// <returns></returns>
        Task<Subaccount> CreateSubaccountAsync(NewSubaccount newSubaccount);

        /// <summary>
        /// Retrieve details for a specified subaccount. 
        /// (NOTE: This API is limited to partners and not available for traders.)
        /// </summary>
        /// <param name="subAccountId"></param>
        /// <returns></returns>
        Task<Subaccount> GetSubaccountAsync(string subAccountId);

        /// <summary>
        /// List sent transfers.
        /// (NOTE: This API is limited to partners and not available for traders.) 
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<SentTransferInfo> GetSendTransfersAsync();

        /// <summary>
        /// List received transfers.
        /// (NOTE: This API is limited to partners and not available for traders.) 
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<ReceivedTransferInfo> GetReceiveTransfersAsync();

        /// <summary>
        /// Retrieve information on the specified transfer.
        /// (NOTE: This API is limited to partners and not available for traders.)
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        Task<ReceivedTransferInfo> GetReceivedTransferAsync(string transferId);

        /// <summary>
        /// Executes a new transfer.
        /// (NOTE: This API is limited to partners and not available for traders.)
        /// </summary>
        /// <param name="newTransfer"></param>
        /// <returns></returns>
        Task<NewTransfer> CreateTransferAsync(NewTransfer newTransfer);

        /// <summary>
        /// List open withdrawals. Results are sorted in inverse order of the CreatedAt field, and are limited to the first 1000.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="currencySymbol"></param>
        /// <returns></returns>
        Task<IEnumerable<Withdrawal>> GetWithdrawalsAsync(State state, string currencySymbol);

        /// <summary>
        /// Retrieves all withdrawals for this account with the given TxId
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        Task<Withdrawal> GetWithdrawalByTxIdAsync(string txId);

        /// <summary>
        /// Retrieve information on a specified withdrawal.
        /// </summary>
        /// <param name="withdrawalId"></param>
        /// <returns></returns>
        Task<Withdrawal> GetWithdrawalAsync(string withdrawalId);

        /// <summary>
        /// Cancel a withdrawal. 
        /// (Withdrawals can only be cancelled if status is REQUESTED, AUTHORIZED, or ERROR_INVALID_ADDRESS.)
        /// </summary>
        /// <param name="withdrawalId"></param>
        /// <returns></returns>
        Task DeleteWithdrawalAsync(string withdrawalId);

        /// <summary>
        /// Create a new withdrawal.
        /// </summary>
        /// <param name="newWithdrawal"></param>
        /// <returns></returns>
        Task<Withdrawal> CreateWithdrawalAsync(NewWithdrawal newWithdrawal);
    }
}