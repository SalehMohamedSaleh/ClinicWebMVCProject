using ClinicDomain.Enums;
using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{

    public class Appointment : BaseEntity
    {
        public TimeRange Date { get; private set; }
        public AppointmentStatus Status { get; private set; }

        public int DoctorId { get; private set; }
        public int PatientId { get; private set; }
        public int BillId { get; private set; }
        public Bill Bill { get; private set; }
        public int MedicalRecordId { get; private set; }
        public MedicalRecord MedicalRecord { get; private set; }
        public Doctor Doctor { get; private set; } = null!;
        public Patient Patient { get; private set; } = null!;

        private readonly HashSet<Prescription> _prescriptions = new();
        public IReadOnlyCollection<Prescription> Prescriptions => _prescriptions;

        public Appointment(TimeRange date, int doctorId, int patientId)
        {
            if (date.Start < DateTime.Now)
                throw new ArgumentException("لا يمكن حجز موعد في تاريخ ماضٍ.");

            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
            Status = AppointmentStatus.Scheduled;
        }

        public void Complete()
        {
            if (Status == AppointmentStatus.Cancelled)
                throw new InvalidOperationException("لا يمكن إكمال موعد ملغي.");

            Status = AppointmentStatus.Completed;
        }

        public void Cancel()
        {
            if (Status == AppointmentStatus.Completed)
                throw new InvalidOperationException("لا يمكن إلغاء موعد تم إتمامه بالفعل.");

            Status = AppointmentStatus.Cancelled;
        }

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("الموعد محذوف بالفعل.");
            IsDeleted = true;
        }

        public void AddPrescription(Prescription prescription)
        {
            if(prescription == null)
                throw new ArgumentNullException(nameof(prescription));
            if (Status != AppointmentStatus.Scheduled)
                throw new InvalidOperationException("يمكن إضافة وصفة فقط للمواعيد المجدولة.");

            _prescriptions.Add(prescription);
        }

        public void UpdateDate(TimeRange newDate)
        {
            if (Status == AppointmentStatus.Completed)
                throw new InvalidOperationException("لا يمكن تعديل موعد تم إتمامه.");

            if (newDate.Start < DateTime.Now)
                throw new ArgumentException("لا يمكن اختيار تاريخ في الماضي.");

            Date = newDate;
        }

    }
}
