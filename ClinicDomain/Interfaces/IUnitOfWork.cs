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
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IDepartmentRepository Departments { get; }
        IMedicalRecordRepository MedicalRecords { get; }
        IBillRepository Bills { get; }
        IPrescriptionRepository Prescriptions { get; }

        // الميثود المسؤولة عن حفظ جميع التغييرات في قاعدة البيانات دفعة واحدة
        Task<int> CompleteAsync();
    }
}
