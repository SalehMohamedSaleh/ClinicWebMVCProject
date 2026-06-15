using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IBillRepository
    {
        // جلب فاتورة واحدة بناءً على رقم الموعد
        Task<Bill?> GetByAppointmentIdAsync(int appointmentId);

        // إضافة فاتورة جديدة
        Task AddAsync(Bill bill);

        // ميثود إضافية مفيدة لتقارير المالية
        Task<IEnumerable<Bill>> GetAllAsync();
        Task<Bill?> GetByIdAsync(int billId);
        Task<IEnumerable<Bill>> GetDeletedAsync();
    }
}
