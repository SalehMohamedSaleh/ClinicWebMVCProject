using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IAppointmentRepository : IGenaricRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId);
    }
}
