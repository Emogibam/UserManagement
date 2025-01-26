using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

                var checkExistingUser = await _writeContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email.Trim());

                var token = new GenericHelper().GenerateRandomString(6);

            }
            catch (ArgumentNullException ex)
            {
                _iLogger.LogError("Null argument passed: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
                return GenericResponse<CreateUserResponse>.BadRequest("One or more required fields are null. Please check your input.");
            }
            catch (InvalidOperationException ex)
            {
                _iLogger.LogError("Invalid operation: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
                return GenericResponse<CreateUserResponse>.BadRequest("An invalid operation occurred. Please try again.");
            }
            catch (DbUpdateException ex)
            {
                _iLogger.LogError("Database update error: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
                return GenericResponse<CreateUserResponse>.InternalServerError("Database update failed. Please try again.");
            }
            catch (InvalidCastException ex)
            {
                _iLogger.LogError("Invalid type casting: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
                return GenericResponse<CreateUserResponse>.BadRequest("A type conversion error occurred. Please verify the data types.");
            }
            catch (TimeoutException ex)
            {
                _iLogger.LogError("Timeout exception: {Message}, StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
                return GenericResponse<CreateUserResponse>.InternalServerError("Operation timed out. Please try again later.");
            }
            catch (Exception ex)
            {
                _iLogger.LogError("Unexpected error: Email: {Email}, Exception: Message: {Message}, StackTrace: {StackTrace}", request.Email, ex.Message, ex.StackTrace);
                return GenericResponse<CreateUserResponse>.InternalServerError("Something went wrong. Please try again later.");
            }


        }
    }
}
