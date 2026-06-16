using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class Bill : BaseEntity
    {
        public Money Amount { get; private set; }
        public bool IsPaid { get; private set; }
        public int AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; }

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

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("الفاتورة محذوفة بالفعل.");
            IsDeleted = true;
        }

 
        public void Update(Money newAmount)
        {
            if (IsPaid)
                throw new InvalidOperationException("لا يمكن تعديل فاتورة تم دفعها بالفعل.");

            Amount = newAmount;
        }
    }
}
