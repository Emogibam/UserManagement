using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Entities
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UserPermission> Permissions { get; set; } = new List<UserPermission>();
    }
}
