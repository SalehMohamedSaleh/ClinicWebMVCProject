using ClinicDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class MedicalRecord : ISoftDelete
    {
        public int Id { get; private set; }
        public string Diagnosis { get; private set; } // التشخيص
        public string Observations { get; private set; } // ملاحظات الطبيب
        public int PatientId { get; private set; }
        public Patient Patient { get; private set; }
        public int AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; }

        public bool IsDeleted { get; private set; }

        public MedicalRecord(string diagnosis, string observations, int patientId, int appointmentId)
        {
            Diagnosis = string.IsNullOrWhiteSpace(diagnosis) ? throw new ArgumentException("التشخيص مطلوب") : diagnosis;
            Observations = observations;
            PatientId = patientId;
            AppointmentId = appointmentId;
        }

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("التقرير الطبي محذوف بالفعل.");
            IsDeleted = true;
        }
    }
}
