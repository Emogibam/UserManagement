using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public bool EmailVerified { get; set; } = false;


        public DateTime? LastLoginAt { get; set; }

        public int FailedLoginAttempts { get; set; } = 0;

        public bool IsLockedOut { get; set; } = false;

        public DateTime? LockoutEndTime { get; set; }

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
        public ICollection<UserPasswordHistory> PasswordHistories { get; set; } = new List<UserPasswordHistory>();

    }
}
