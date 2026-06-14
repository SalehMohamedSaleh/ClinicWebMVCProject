using ClinicDomain.Entities;
using ClinicDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomainTests.Entities
{
    public class DoctorTests
    {
        [Fact]
        public void AddAppointment_ShouldThrowConflictException_WhenDateIsTaken()
        {
            // Arrange
            var doctor = new Doctor("د. أحمد", "باطنية", 5000);
            var date = DateTime.Now.AddDays(1);
            doctor.AddAppointment(new Appointment(date, 1, 1));

            // Act & Assert
            Assert.Throws<AppointmentConflictException>(() => doctor.AddAppointment(new Appointment(date, 1, 2)));
        }
    }
}
