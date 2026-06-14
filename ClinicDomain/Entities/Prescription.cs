using ClinicDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class Prescription : ISoftDelete
    {
        public int Id { get; private set; }
        public string MedicineName { get; private set; }
        public string Dosage { get; private set; }
        public int AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; }

        public bool IsDeleted { get; private set; }

        public Prescription(string medicineName, string dosage, int appointmentId)
        {
            ValidateMedicineName(medicineName);
            ValidateDosage(dosage);

            MedicineName = medicineName;
            Dosage = dosage;
            AppointmentId = appointmentId;
        }

        public void ChangeDosage(string newDosage)
        {
            ValidateDosage(newDosage);
            Dosage = newDosage;
        }

        private void ValidateMedicineName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("اسم الدواء مطلوب.");
            if (name.Length < 2)
                throw new ArgumentException("اسم الدواء قصير جداً.");
        }

        private void ValidateDosage(string dosage)
        {
            if (string.IsNullOrWhiteSpace(dosage))
                throw new ArgumentException("الجرعة مطلوبة.");
        }

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("الروشتة محذوفة بالفعل.");
            IsDeleted = true;
        }
    }
}
