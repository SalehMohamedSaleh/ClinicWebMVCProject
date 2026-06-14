using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.ValueObjects
{

    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentException("المبلغ لا يمكن أن يكون سالباً.");
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("العملة مطلوبة.");

            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("لا يمكن جمع عملات مختلفة");
            return new Money(a.Amount + b.Amount, a.Currency);
        }
    }
}
