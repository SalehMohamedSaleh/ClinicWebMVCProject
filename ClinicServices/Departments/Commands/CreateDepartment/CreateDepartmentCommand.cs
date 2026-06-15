using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Commands.CreateDepartment
{
    public record CreateDepartmentCommand(string Name) : IRequest<Unit>;
}
