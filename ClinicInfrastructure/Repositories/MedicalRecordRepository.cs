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

        public Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
