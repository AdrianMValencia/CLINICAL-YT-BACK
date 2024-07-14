namespace CLINICAL.Domain.Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId {  get; set; }
        public int? State {  get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
