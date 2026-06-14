using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.ValueObjects
{
        public record SalaryRange
        {
            public Money Min { get; } 
            public Money Max { get; }

            public static readonly Money DefaultMin = new Money(1000, "USD");
            public static readonly Money DefaultMax = new Money(20000, "USD");

        public SalaryRange() : this(DefaultMin, DefaultMax) { }
        public SalaryRange(Money min, Money max)
        {
            if (min.Currency != max.Currency)
                throw new InvalidOperationException("لا يمكن تحديد نطاق لعملات مختلفة.");

            if (min.Amount >= max.Amount)
                throw new ArgumentException("الحد الأدنى يجب أن يكون أقل من الحد الأعلى.");

            Min = min;
            Max = max;
        }
        public bool IsValid(Money salary)
            {
            return salary.Currency == Min.Currency &&
                   salary.Amount >= Min.Amount &&
                   salary.Amount <= Max.Amount;
        }

        }
    }

