using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IPrescriptionRepository : IGenaricRepository<Prescription>
    {

        // جلب جميع الوصفات الطبية الخاصة بموعد معين
        Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(int appointmentId);


    }
}
