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
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(b => b.Id);

            // ربط الـ Money Value Object
            builder.OwnsOne(b => b.Amount, money =>
            {
                money.Property(m => m.Amount).HasColumnName("Amount").IsRequired();
                money.Property(m => m.Currency).HasColumnName("Currency").IsRequired();
            });
            builder.HasOne(b => b.Appointment)
                   .WithOne(a => a.Bill)
                   .HasForeignKey<Bill>(b => b.AppointmentId);
        }
    }
}
