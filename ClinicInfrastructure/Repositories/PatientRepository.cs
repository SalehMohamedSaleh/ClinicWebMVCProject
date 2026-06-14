using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using ClinicInfrastructure.Persistence;
using ClinicServices.Patients.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInfrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicDbContext _context;

        public PatientRepository(ClinicDbContext context) => _context = context;

        // جلب مريض مع مواعيده
        public async Task<Patient?> GetByIdAsync(int id) =>
            await _context.Patients
                          .Include(p => p.Appointments)
                          .FirstOrDefaultAsync(p => p.Id == id);

        // إضافة مريض جديد
        public async Task AddAsync(Patient patient) =>
            await _context.Patients.AddAsync(patient);

        // توفير استعلام مرن (IQueryable) للاستخدام في Handler إذا لزم الأمر
        public IQueryable<Patient> GetAll() =>
            _context.Patients.AsQueryable();

        // جلب قائمة كاملة من المرضى النشطين (تستخدم GetAll() لتقليل التكرار)
        public async Task<IEnumerable<Patient>> GetAllAsync() =>
            await GetAll().ToListAsync();

        // تحديث بيانات المريض
        public void Update(Patient patient) =>
            _context.Patients.Update(patient);

        // جلب المرضى المحذوفين فقط (يتجاهل الـ Global Filters)
        public async Task<List<Patient>> GetDeletedPatientsAsync()
        {
            return await _context.Patients
                                 .IgnoreQueryFilters()
                                 .Where(p => p.IsDeleted)
                                 .ToListAsync();
        }

        public async Task<List<PatientDto>> GetAllPatientsAsync()
        {
            return await _context.Patients
                                 .Select(p => new PatientDto(p.Id, p.Name, p.Age, p.Phone))
                                 .ToListAsync();
        }

        Task<List<Patient>> IPatientRepository.GetAllPatientsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
