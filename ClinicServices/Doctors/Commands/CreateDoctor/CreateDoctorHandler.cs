using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDoctorHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken ct)
        {
            var salary = new Money(request.SalaryAmount, request.Currency);
            var doctor = new Doctor(request.Name, request.Specialization, salary);

            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.CompleteAsync();
            return doctor.Id;
        }
    }
}
