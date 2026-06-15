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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicDbContext _context;

        public DoctorRepository(ClinicDbContext context) => _context = context;

        public async Task<Doctor?> GetByIdAsync(int id)
            => await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task AddAsync(Doctor doctor)
            => await _context.Doctors.AddAsync(doctor);

        // في DoctorRepository.cs
        public async Task<IEnumerable<Doctor>> GetDeletedAsync()
        {
            return await _context.Doctors
                .IgnoreQueryFilters() // تجاهل الفلتر العالمي الذي يخفي المحذوفين
                .Where(d => d.IsDeleted == true)
                .ToListAsync();
        }
    }
}
