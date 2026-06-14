using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.ValueObjects
{
    public record TimeRange
    {
        public DateTime Start { get; init; }
        public DateTime End { get; init; }

        public TimeRange(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentException("وقت البداية يجب أن يكون قبل وقت النهاية");

            Start = start;
            End = end;
        }
    }
}
