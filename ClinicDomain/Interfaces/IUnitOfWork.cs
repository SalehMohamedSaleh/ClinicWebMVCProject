using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IMedicalRecordRepository MedicalRecords { get; }
        IBillRepository Bills { get; }
        IPrescriptionRepository Prescriptions { get; }

        Task<int> CompleteAsync();
    }
}
