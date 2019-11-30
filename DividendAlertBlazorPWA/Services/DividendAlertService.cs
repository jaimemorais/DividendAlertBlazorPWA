using DividendAlertBlazorPWA.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DividendAlertBlazorPWA.Services
{
    public class DividendAlertService : IDividendAlertService
    {

        private readonly IConfiguration _config;

        public DividendAlertService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Dividend>> GetNewDividendsAsync(int days)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                const string LASTDAYS_DIVIDENDS_ENDPOINT = "dividends/lastDays";

                string uri = $"{_config["dividendApiUri"]}/{LASTDAYS_DIVIDENDS_ENDPOINT}/{_config["scrapeToken"]}/{days}";


                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Dividend> dividends = JsonConvert.DeserializeObject<List<Dividend>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });


                    return dividends.OrderByDescending(d => d.PaymentDate).ToList();
                }
                else
                {
                    // TODO logging
                    return null;
                }
            }
        }

    }
}
