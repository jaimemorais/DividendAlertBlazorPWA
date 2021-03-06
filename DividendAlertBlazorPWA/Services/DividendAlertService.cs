using DividendAlertBlazorPWA.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
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


        public async Task<List<Dividend>> GetNextDividendsAsync(DateTime fromDate)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                const string NEXT_DIVIDENDS_ENDPOINT = "dividends/next";

                fromDate = fromDate.AddDays(-1);

                string uri = $"{_config["dividendApiUri"]}/{NEXT_DIVIDENDS_ENDPOINT}/{_config["scrapeToken"]}/" +
                    $"{fromDate.Year}/{fromDate.Month.ToString("00")}/{fromDate.Day.ToString("00")}";

                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Dividend> dividends = JsonConvert.DeserializeObject<List<Dividend>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

                    return dividends.OrderByDescending(d => d.PaymentDate).ToList();
                }
                else
                {
                    // TODO log error
                    return Array.Empty<Dividend>().ToList();
                }
            }
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
                    // TODO log error
                    return Array.Empty<Dividend>().ToList();
                }
            }
        }

    }
}
