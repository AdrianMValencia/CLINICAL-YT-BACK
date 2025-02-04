namespace CLINICAL.Application.Dtos.Medic
{
    public class GetMedicByIdResponseDto
    {
        public int? MedicId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public int? SpecialtyId { get; set; }
    }
}