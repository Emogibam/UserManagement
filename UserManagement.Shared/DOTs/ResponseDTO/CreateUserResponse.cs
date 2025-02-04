using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared.DOTs.ResponseDTO
{
    public class CreateUserResponse
    {
        public string Token {  get; set; }
        public string Email { get; set; }
    }
}
