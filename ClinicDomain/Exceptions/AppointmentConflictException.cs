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

        // يمكننا إضافة خصائص إضافية هنا لتسهيل عملية التصحيح (Debugging)
        public static AppointmentConflictException ForDoctor(int doctorId, DateTime date)
        {
            return new AppointmentConflictException(
                $"الطبيب صاحب المعرف {doctorId} لديه موعد مسجل بالفعل في هذا الوقت: {date}");
        }
    }
}
