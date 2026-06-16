using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IMedicalRecordRepository : IGenaricRepository<MedicalRecord>
    {
        // جلب السجل الطبي الخاص بموعد معين
        Task<MedicalRecord?> GetByAppointmentIdAsync(int appointmentId);

        // جلب جميع السجلات الطبية لمريض معين (مهم جداً للتاريخ الطبي)
        Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
    }
}
