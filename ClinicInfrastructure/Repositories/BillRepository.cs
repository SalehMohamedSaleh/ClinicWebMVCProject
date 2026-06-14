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
    public class BillRepository : IBillRepository
    {
        private readonly ClinicDbContext _context;
        public BillRepository(ClinicDbContext context) => _context = context;

        public async Task<Bill?> GetByAppointmentIdAsync(int appointmentId)
        {
            // جلب الفاتورة الخاصة بموعد محدد
            return await _context.Bills
                .FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);
        }

        public async Task AddAsync(Bill bill) => await _context.Bills.AddAsync(bill);

        public Task<IEnumerable<Bill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
