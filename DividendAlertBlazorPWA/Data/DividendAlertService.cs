using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace DividendAlertBlazorPWA.Data
{
    public class DividendAlertService : IDividendAlertService
    {

        private readonly IConfiguration _config;

        public DividendAlertService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetNewDividendsHtmlAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(_config["dividendApiUri"]);
            }
        }

    }
}
