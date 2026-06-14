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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

            // ربط الـ Value Object
            builder.OwnsOne(d => d.Salary, salary =>
            {
                salary.Property(m => m.Amount).HasColumnName("SalaryAmount").IsRequired();
                salary.Property(m => m.Currency).HasColumnName("SalaryCurrency").IsRequired();
            });

            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Specialization).IsRequired().HasMaxLength(100);
        }
    }
}
