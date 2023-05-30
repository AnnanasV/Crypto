using Crypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crypto.Services.APICoinCap
{
    public interface ICryptocurrencyService
	{
		Task<IEnumerable<CurrencyModel>> GetCurrency(string properties);
		Task<IEnumerable<HistoryPriceModel>> GetPrices(string currency, string interval); 
	}
}