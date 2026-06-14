using ClinicDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class Bill
    {
        public int Id { get; private set; }
        public Money Amount { get; private set; }
        public bool IsPaid { get; private set; }
        public int AppointmentId { get; private set; }

        public Bill(Money amount, int appointmentId)
        {
            Amount = amount;
            AppointmentId = appointmentId;
            IsPaid = false;
        }

        public void MarkAsPaid()
        {
            if (IsPaid) throw new InvalidOperationException("الفاتورة مدفوعة بالفعل.");
            IsPaid = true;
        }
    }
}
