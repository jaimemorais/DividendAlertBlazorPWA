using System;

namespace DividendAlertBlazorPWA.Model
{
    public class Dividend
    {
        public string StockName { get; set; }
        public string Type { get; set; }
        public string ExDate { get; set; }
        public DateTime PaymentDate { get; set; }

        public string PaymentDateFormatted => PaymentDate.ToString("dd/MM/yyyy");

        public string Value { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
