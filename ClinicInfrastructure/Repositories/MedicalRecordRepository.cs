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
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ClinicDbContext _context;
        public MedicalRecordRepository(ClinicDbContext context) => _context = context;

        public async Task AddAsync(MedicalRecord record) => await _context.MedicalRecords.AddAsync(record);

        public async Task<MedicalRecord?> GetByAppointmentIdAsync(int appointmentId) =>
            await _context.MedicalRecords.FirstOrDefaultAsync(m => m.AppointmentId == appointmentId);

        public async Task<MedicalRecord?> GetByIdAsync(int id)
        {
            // جلب السجل الطبي مع المريض والموعد المرتبط به (Eager Loading)
            return await _context.MedicalRecords
                .Include(m => m.Patient)
                .Include(m => m.Appointment)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
        {
            return await _context.MedicalRecords
                .Where(m => m.PatientId == patientId && !m.IsDeleted) // استبعاد المحذوف منطقياً
                .Include(m => m.Appointment)
                .ToListAsync();
        }

        // في MedicalRecordRepository.cs
        public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
        {
            return await _context.MedicalRecords
                .Include(m => m.Patient)
                .Include(m => m.Appointment)
                .ToListAsync();
        }

        // في MedicalRecordRepository.cs
        public async Task<IEnumerable<MedicalRecord>> GetDeletedAsync()
        {
            return await _context.MedicalRecords
                .IgnoreQueryFilters()
                .Where(m => m.IsDeleted == true)
                .ToListAsync();
        }

    }
}
