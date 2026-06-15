using ClinicServices.MedicalRecords.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Queries.GetMedicalRecordById
{
    public record GetMedicalRecordByIdQuery(int Id) : IRequest<MedicalRecordDto>;
}
