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
        public string PasswordHash { get; set; }
        public string PasswordResetToken { get; set; }
        public DateTime PasswordResetTokenExpiryTIme { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public bool EmailVerified { get; set; } = false;
        public string EmailVerificationToken { get; set; }
        public DateTime EmailVerificationTokenExpiryTime { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public int FailedLoginAttempts { get; set; } = 0;

        public bool IsLockedOut { get; set; } = false;

        public DateTime? LockoutEndTime { get; set; }

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
        public ICollection<UserPasswordHistory> PasswordHistories { get; set; } = new List<UserPasswordHistory>();

    }
}
