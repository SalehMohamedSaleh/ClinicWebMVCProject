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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ClinicDbContext _context;
        public PrescriptionRepository(ClinicDbContext context) => _context = context;

        public async Task AddAsync(Prescription prescription)
            => await _context.Prescriptions.AddAsync(prescription);

        public async Task<IEnumerable<Prescription>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _context.Prescriptions
                .Where(p => p.AppointmentId == appointmentId)
                .ToListAsync();
        }

        public async Task<Prescription?> GetByIdAsync(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.Appointment) // جلب الموعد المرتبط بالوصفة
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
