using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IMedicalRecordRepository
    {
        // إضافة سجل طبي جديد بعد كشف أو موعد
        Task AddAsync(MedicalRecord medicalRecord);

        // جلب السجل الطبي الخاص بموعد معين
        Task<MedicalRecord?> GetByAppointmentIdAsync(int appointmentId);
        Task<MedicalRecord?> GetByIdAsync(int id);

        // جلب جميع السجلات الطبية لمريض معين (مهم جداً للتاريخ الطبي)
        Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<MedicalRecord>> GetDeletedAsync();
    }
}
