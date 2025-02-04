using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Shared.DOTs.RequestDTO.UserManagement.Shared.DTOs;
using UserManagement.Shared.DOTs.ResponseDTO;
using UserManagement.Shared;

namespace UserManagement.Application.Logics.Interfaces
{
    public interface IUserLogics
    {
        Task<GenericResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
    }
}
