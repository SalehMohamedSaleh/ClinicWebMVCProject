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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.Date, date =>
            {
                date.Property(t => t.Start).HasColumnName("StartTime").IsRequired();
                date.Property(t => t.End).HasColumnName("EndTime").IsRequired();
            });

            builder.HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);
            builder.HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);

            // التعامل مع الـ Collection المخفية (Prescriptions)
            builder.Metadata.FindNavigation(nameof(Appointment.Prescriptions))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
