using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAllAsync();
        // لا نحتاج لـ Update أو Delete هنا إذا كانت الـ UoW تدعم الـ Tracking
    }
}
