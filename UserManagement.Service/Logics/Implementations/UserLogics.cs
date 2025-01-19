using Microsoft.Extensions.Logging;
using UserManagement.Application.Logics.Interfaces;
using UserManagement.Infrastructure.Context;
using UserManagement.Shared;
using UserManagement.Shared.DOTs.RequestDTO;
using UserManagement.Shared.DOTs.RequestDTO.UserManagement.Shared.DTOs;
using UserManagement.Shared.DOTs.ResponseDTO;

namespace UserManagement.Application.Logics.Implementations
{
    public class UserLogics : IUserLogics
    {
        private readonly WriteAppDbContext _writeContext;
        private readonly ILogger<UserLogics> _iLogger;

        public UserLogics(WriteAppDbContext writeContext, ILogger<UserLogics> iLogger,)
        {
            this._writeContext = writeContext;
            this._iLogger = iLogger;
        }

        public async Task<GenericResponse<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            string _MethodName = "UserLogic: Create";
            _iLogger.LogInformation("Starting user creation for email: {Email}", request.Email);

            try
            {
                var token = new GenericHelper().GenerateRandomString(6);

            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }
}
