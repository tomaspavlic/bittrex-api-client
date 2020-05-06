using System.Threading.Tasks;
using Topdev.Bittrex.Client.Models;

namespace Topdev.Bittrex
{
    public interface IBittrexClient
    {
        Task<Candle[]> GetMarketCandlesAsync(string marketSymbol, CandleInterval interval);
        Task<Market[]> GetMarketsAsync();
    }
}