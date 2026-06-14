using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(int id);
        Task AddAsync(Patient patient);
        IQueryable<Patient> GetAll();
        Task<IEnumerable<Patient>> GetAllAsync();
        void Update(Patient patient);
        Task<List<Patient>> GetDeletedPatientsAsync();

     
    }
}
