using ClinicDomain.Interfaces;
using ClinicInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInfrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicDbContext _context;

        public IAppointmentRepository Appointments { get; }
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public IDepartmentRepository Departments { get; }
        public IMedicalRecordRepository MedicalRecords { get; }
        public IBillRepository Bills { get; }
        public IPrescriptionRepository Prescriptions { get; }

        public UnitOfWork(ClinicDbContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(_context);
            Doctors = new DoctorRepository(_context);
            Patients = new PatientRepository(_context);
            Departments = new DepartmentRepository(_context);
            MedicalRecords = new MedicalRecordRepository(_context);
            Bills = new BillRepository(_context);
            Prescriptions = new PrescriptionRepository(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
