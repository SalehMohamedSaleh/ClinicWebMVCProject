using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDepartmentHandler(IUnitOfWork uow) => _unitOfWork = uow;

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken ct)
        {
            var dept = await _unitOfWork.Departments.GetByIdAsync(request.Id);
            if (dept == null) throw new KeyNotFoundException();

            dept.Delete(); // هنا يتم تطبيق الـ Soft Delete
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
