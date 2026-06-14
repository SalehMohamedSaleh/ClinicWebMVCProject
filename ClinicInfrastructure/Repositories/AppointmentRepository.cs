using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using ClinicInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInfrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public AppointmentRepository(ClinicDbContext context) => _context = context;

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId)
        {
            return await _context.Appointments
                .Include(a => a.Patient) // جلب بيانات المريض
                .Where(a => a.DoctorId == doctorId) // الفلترة حسب الطبيب
                .ToListAsync();
        }
        public void Update(Appointment appointment)
        {
            // EF Core يقوم بتحديث حالة الكيان إلى Modified تلقائياً
            _context.Appointments.Update(appointment);
        }
        public void Delete(Appointment appointment)
        {
            // بدلاً من الحذف، نقوم بإلغاء الموعد أو وضع علامة محذوف
            appointment.Cancel();
        }
    }
}
