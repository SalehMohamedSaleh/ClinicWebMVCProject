using ClinicDomain.Exceptions;
using ClinicDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Specialization { get; private set; }
        public Money Salary { get; private set; }
        public bool IsDeleted { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }

        private readonly HashSet<Appointment> _appointments = new();
        public IReadOnlyCollection<Appointment> Appointments => _appointments;

        public Doctor(string name, string specialization, Money salary)
        {
            ValidateName(name);
            ValidateSpecialization(specialization);
            ValidateSalary(salary);

            Name = name;
            Specialization = specialization;
            Salary = salary;
            IsDeleted = false;
        }

        public void UpdateProfile(string name, string specialization)
        {
            ValidateName(name);
            ValidateSpecialization(specialization);

            Name = name;
            Specialization = specialization;
        }

        public void UpdateSalary(Money newSalary)
        {
            ValidateSalary(newSalary);
            Salary = newSalary;
        }

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("الطبيب محذوف بالفعل.");
            IsDeleted = true;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("الاسم مطلوب.");
            if (name.Length < 3) throw new ArgumentException("الاسم يجب أن يتكون من 3 أحرف على الأقل.");
        }

        private void ValidateSpecialization(string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization)) throw new ArgumentException("التخصص مطلوب.");
            if (specialization.Length < 3) throw new ArgumentException("التخصص يجب أن يتكون من 3 أحرف على الأقل.");
        }

        private void ValidateSalary(Money salary)
        {
            if (salary.Amount < 1000 || salary.Amount > 20000)
                throw new ArgumentOutOfRangeException(nameof(salary), "الراتب يجب أن يكون بين 1000 و 20000.");
        }

        public void AddAppointment(Appointment newAppointment)
        {
       
            bool isConflict = _appointments.Any(a => a.Date == newAppointment.Date);

            if (isConflict)
            {
                throw AppointmentConflictException.ForDoctor(this.Id, newAppointment.Date.Start);
            }

            _appointments.Add(newAppointment);
        }
    }
}
