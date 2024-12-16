namespace UserManagement.Domain.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Action { get; set; } 

        public string EntityName { get; set; } 

        public string EntityId { get; set; } 

        public string PerformedBy { get; set; } 

        public DateTime Timestamp { get; set; } = DateTime.UtcNow.AddHours(1);

        public string Details { get; set; } 
    }
}
