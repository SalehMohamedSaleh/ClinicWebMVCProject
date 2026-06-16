using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Exceptions
{
    public class AppointmentConflictException : Exception
    {
        public AppointmentConflictException(string message) : base(message)
        {
        }
        public static AppointmentConflictException ForDoctor(string doctorName, DateTime date)
        {
            return new AppointmentConflictException(
                $"الطبيب صاحب المعرف {doctorName} لديه موعد مسجل بالفعل في هذا الوقت: {date}");
        }
    }
}
