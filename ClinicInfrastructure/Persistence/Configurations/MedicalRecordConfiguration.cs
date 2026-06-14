using ClinicDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInfrastructure.Persistence.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            // تعيين المفتاح الأساسي
            builder.HasKey(mr => mr.Id);

            // قيود الحقول
            builder.Property(mr => mr.Diagnosis)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(mr => mr.Observations)
                   .HasMaxLength(1000);

            // بما أن MedicalRecord يرتبط بمريض وموعد، يجب التأكد من وجود هذه الخصائص في الكيان
            // إذا لم تكن موجودة، تأكد من إضافتها في كلاس MedicalRecord في الـ Domain

            // علاقة مع Patient (مريض واحد لديه سجلات متعددة)
            builder.HasOne(mr => mr.Patient)
                   .WithMany(p => p.MedicalRecords)
                   .HasForeignKey(mr => mr.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            // علاقة مع Appointment (موعد واحد لسجل طبي واحد - 1:1)
            builder.HasOne(mr => mr.Appointment)
                   .WithOne(a => a.MedicalRecord)
                   .HasForeignKey<MedicalRecord>(mr => mr.AppointmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
