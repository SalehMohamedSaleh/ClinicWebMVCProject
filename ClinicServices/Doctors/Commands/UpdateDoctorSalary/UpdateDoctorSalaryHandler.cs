using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Commands.UpdateDoctorSalary
{
    public class UpdateDoctorSalaryHandler : IRequestHandler<UpdateDoctorSalaryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateDoctorSalaryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateDoctorSalaryCommand request, CancellationToken ct)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);

            if (doctor == null)
                throw new KeyNotFoundException("الطبيب غير موجود");

            var newSalary = new Money(request.NewSalary, request.Currency);
            doctor.UpdateSalary(newSalary);

            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }

     
    }
}
