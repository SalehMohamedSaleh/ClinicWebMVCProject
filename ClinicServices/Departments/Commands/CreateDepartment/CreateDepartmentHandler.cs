using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateDepartmentHandler(IUnitOfWork uow) => _unitOfWork = uow;

        public async Task<Unit> Handle(CreateDepartmentCommand request, CancellationToken ct)
        {
            var dept = new Department(request.Name);
            await _unitOfWork.Departments.AddAsync(dept);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
