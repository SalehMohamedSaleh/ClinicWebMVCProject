using ClinicDomain.Interfaces;
using ClinicServices.Patients.DTOs;
using ClinicServices.Patients.Queries.GetDeletedPatients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Queries.GetAllPatients
{
    // GetAllPatientsHandler.cs
    public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, List<PatientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatientsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken ct)
        {
            // الـ Repository هو من قام بالتحويل للـ DTOs بالفعل
            return await _unitOfWork.Patients.GetAll();
        }
    }
}
