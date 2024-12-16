using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Entities
{
    public class UserPasswordHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
    }
}
