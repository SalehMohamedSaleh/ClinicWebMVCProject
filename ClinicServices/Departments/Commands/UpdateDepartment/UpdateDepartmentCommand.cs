using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Commands.UpdateDepartment
{
    public record UpdateDepartmentCommand(int Id, string NewName) : IRequest<Unit>;
}
