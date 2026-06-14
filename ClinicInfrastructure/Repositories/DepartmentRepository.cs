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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ClinicDbContext _context;
        public DepartmentRepository(ClinicDbContext context) => _context = context;

        public async Task<Department?> GetByIdAsync(int id) =>
            await _context.Departments.Include(d => d.Doctors).FirstOrDefaultAsync(d => d.Id == id);

        public async Task AddAsync(Department department) => await _context.Departments.AddAsync(department);

        public Task<IEnumerable<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
