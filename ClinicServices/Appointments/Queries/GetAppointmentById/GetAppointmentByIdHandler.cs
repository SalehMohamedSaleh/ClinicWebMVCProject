using ClinicDomain.Interfaces;
using ClinicServices.Appointments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppointmentDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. جلب الموعد من الـ Repository
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);

            // 2. التحقق من وجود الموعد
            if (appointment == null)
                throw new KeyNotFoundException($"الموعد ذو المعرف {request.AppointmentId} غير موجود.");

            // 3. تحويل الكيان إلى DTO وإرجاعه
            return new AppointmentDto(
                appointment.Id,
                appointment.Date.Start,
                appointment.Date.End,
                appointment.Status.ToString(),
                appointment.Doctor?.Name ?? "غير متاح",
                appointment.Patient?.Name ?? "غير متاح"
            );
        }
    }
}
