﻿using System;

namespace DividendAlertBlazorPWA.Model
{
    public class Dividend
    {
        public string StockName { get; set; }
        public string Type { get; set; }
        public string ExDate { get; set; }
        public string PaymentDate { get; set; }
        public string Value { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
