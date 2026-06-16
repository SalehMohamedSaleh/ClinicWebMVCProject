using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IBillRepository : IGenaricRepository<Bill>
    {
        //جلب الفاتورة بموعد معين
        Task<Bill> GetByAppointmentIdAsync(int appointmentId);

    }
}
