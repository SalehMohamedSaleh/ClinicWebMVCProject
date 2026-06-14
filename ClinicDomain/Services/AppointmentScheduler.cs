using ClinicDomain.Entities;
using ClinicDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Services
{
    public class AppointmentScheduler
    {
        public void Schedule(Doctor doctor, Patient patient, TimeRange date)
        {
            if (patient.Appointments.Any(a => a.Date.Start == date.Start))
            {
                throw new InvalidOperationException("المريض لديه موعد آخر في نفس التوقيت.");
            }

            var newAppointment = new Appointment(date, doctor.Id, patient.Id);

            doctor.AddAppointment(newAppointment);
            patient.AddAppointment(newAppointment);
        }
    }
}
