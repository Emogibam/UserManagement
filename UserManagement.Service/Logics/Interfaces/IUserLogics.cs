using UserManagement.Shared.DOTs.ResponseDTO;
using UserManagement.Shared;
using UserManagement.Shared.DOTs.RequestDTO;

namespace UserManagement.Application.Logics.Interfaces
{
    public interface IUserLogics
    {
        Task<GenericResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
    }
}
