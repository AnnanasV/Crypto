using Crypto.Services.APICoinCap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crypto.Services
{
    public interface ICryptocurrencyService
	{
		Task<IEnumerable<Cryptocurrency>> GetCurrency();
	}
}
