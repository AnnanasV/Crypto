using Crypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crypto.Services
{
    public interface ICryptocurrencyService
	{
		Task<IEnumerable<CurrencyModel>> GetCurrency();
	}
}
