using ClinicDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Phone { get; private set; }

        private readonly HashSet<MedicalRecord> _medicalRecords = new();
        public IReadOnlyCollection<MedicalRecord> MedicalRecords => _medicalRecords;

        private readonly HashSet<Appointment> _appointments = new();
        public IReadOnlyCollection<Appointment> Appointments => _appointments;

        public Patient(string name, int age, string phone)
        {
            ValidateName(name);
            ValidateAge(age);
            ValidatePhone(phone);

            Name = name;
            Age = age;
            Phone = phone;
        }

        public void UpdateContactInfo(string newPhone)
        {
            ValidatePhone(newPhone);
            Phone = newPhone;
        }

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("المريض محذوف بالفعل.");
            IsDeleted = true;
        }

        public void AddAppointment(Appointment appointment)
        {
            if (appointment == null) 
                throw new ArgumentNullException(nameof(appointment));
            _appointments.Add(appointment);
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("اسم المريض مطلوب.");
            if (name.Length < 3) 
                throw new ArgumentException("الاسم يجب أن يكون 3 أحرف على الأقل.");
        }

        private void ValidateAge(int age)
        {
            if (age < 0 || age > 120) 
                throw new ArgumentOutOfRangeException(nameof(age), "العمر يجب أن يكون منطقياً.");
        }

        private void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length < 10)
                throw new ArgumentException("رقم الهاتف غير صحيح.");
        }
    }
}
