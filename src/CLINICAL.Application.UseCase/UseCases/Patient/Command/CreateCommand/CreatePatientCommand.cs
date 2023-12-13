using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.CreateCommand
{
    public class CreatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public string? Names { get; set; }
        public string? LastName {  get; set; }
        public string? MotherMaidenName { get; set; }
        public int DocumentTypeId {  get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phone { get; set; }
        public int TypeAgeId { get; set; }
        public int Age {  get; set; }
        public int GenderId { get; set; }
    }
}