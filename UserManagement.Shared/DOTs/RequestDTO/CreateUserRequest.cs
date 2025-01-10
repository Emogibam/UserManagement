using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared.DOTs.RequestDTO
{
    using System.ComponentModel.DataAnnotations;

    namespace UserManagement.Shared.DTOs
    {
        public class CreateUserRequest
        {
            [Required(ErrorMessage = "Username is required.")]
            [MaxLength(50, ErrorMessage = "Username must not exceed 50 characters.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "First name is required.")]
            [MaxLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required.")]
            [MaxLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "A valid email address is required.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "PhoneNumber is required.")]
            [StringLength(11, ErrorMessage = "Phone must have exactly 11 character.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }
            [Required(ErrorMessage = "ConfirmPassword is required.")]
            public string ConfirmPassword { get; set; }
        }
    }

}
