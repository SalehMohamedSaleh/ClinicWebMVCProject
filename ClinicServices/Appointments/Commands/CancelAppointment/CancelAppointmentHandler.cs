using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Commands.DeleteAppointment
{
    public class CancelAppointmentHandler : IRequestHandler<CancelAppointmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // تم تغيير نوع الإرجاع إلى Task<Unit>
        public async Task<Unit> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
        {
            // 1. جلب الموعد
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);

            if (appointment == null)
                throw new KeyNotFoundException($"الموعد ذو المعرف {request.AppointmentId} غير موجود.");

            // 2. تنفيذ منطق الإلغاء
            appointment.Cancel();

            // 3. حفظ التغييرات
            await _unitOfWork.CompleteAsync();

            // إرجاع قيمة Unit لإنهاء العملية بنجاح
            return Unit.Value;
        }
    }
}
