using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Price
    {
        private Price() { }

        public double Amount { get; private set; }
        public string Currency { get; private set; }

        public static Price Create(double amount, string currency)
        {
           return new Price { Amount = amount, Currency = currency };
        }
    }
}
