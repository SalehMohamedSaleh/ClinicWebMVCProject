using ClinicDomain.Enums;
using ClinicDomain.Interfaces;
using ClinicServices.Appointments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Queries.GetCancelledAppointments
{
    public class GetCancelledAppointmentsHandler : IRequestHandler<GetCancelledAppointmentsQuery, IEnumerable<AppointmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCancelledAppointmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AppointmentDto>> Handle(GetCancelledAppointmentsQuery request, CancellationToken cancellationToken)
        {
            // جلب المواعيد الملغاة مباشرة من قاعدة البيانات
            var cancelledAppointments = await _unitOfWork.Appointments.GetCancelledAsync();

            // تحويل الكيانات إلى DTOs
            return cancelledAppointments.Select(a => new AppointmentDto(
                a.Id,
                a.Date.Start,
                a.Date.End,
                a.Status.ToString(),
                a.Doctor?.Name ?? "N/A",
                a.Patient?.Name ?? "N/A"
            ));
        }
    }
}
