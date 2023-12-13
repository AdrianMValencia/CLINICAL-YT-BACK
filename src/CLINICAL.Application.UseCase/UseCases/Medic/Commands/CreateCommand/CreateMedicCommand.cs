using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand
{
    public class CreateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public string? Names {  get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName {  get; set; }
        public string? Address {  get; set; }
        public string? Phone { get; set; }
        public string? BirthDate {  get; set; }
        public int DocumentTypeId {  get; set; }
        public string? DocumentNumber { get; set; }
        public int SpecialtyId { get; set; }
    }
}