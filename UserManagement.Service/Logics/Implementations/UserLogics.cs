using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UserManagement.Application.Helpers;
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

                var emailValidationResponse = ValidationHelperService.ValidateEmail(request.Email);
                if (emailValidationResponse.Code != StatusCodes.Status200OK)
                {
                    _iLogger.LogWarning("Email validation failed: {Email}", request.Email);
                    return GenericResponse<CreateUserResponse>.BadRequest(emailValidationResponse.Message);
                }

                var passwordValidationResponse =  ValidationHelperService.ValidatePassword(request.Password, request.ConfirmPassword);
                if (passwordValidationResponse.Code != StatusCodes.Status200OK)
                {
                    _iLogger.LogWarning("Password validation failed for email: {Email}", request.Email);
                    return GenericResponse<CreateUserResponse>.BadRequest(passwordValidationResponse.Message);
                }
                var token = new GenericHelper().GenerateRandomString(6);

            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }
}
