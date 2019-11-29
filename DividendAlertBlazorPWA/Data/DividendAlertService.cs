using DividendAlertBlazorPWA.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Dividend>> GetNewDividendsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                int days = 7;

                string uri = $"{_config["dividendApiUri"]}/lastDays/{days}";

                // TODO
                // return await httpClient.GetAsync(uri);
                return null;
            }
        }

    }
}
