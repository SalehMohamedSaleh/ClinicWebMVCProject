using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IPrescriptionRepository
    {
        // إضافة وصفة طبية جديدة
        Task AddAsync(Prescription prescription);

        // جلب جميع الوصفات الطبية الخاصة بموعد معين
        Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(int appointmentId);

        // جلب وصفة طبية واحدة عن طريق الـ Id
        Task<Prescription?> GetByIdAsync(int id);
    }
}
