using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Logics.Interfaces;
using UserManagement.Shared.DOTs.ResponseDTO;
using UserManagement.Shared;
using UserManagement.Shared.DOTs.RequestDTO;

namespace UserManagement.Application.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, GenericResponse<CreateUserResponse>>
    {
        private readonly IUserLogics _userLogics;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserLogics userLogics, ILogger<CreateUserCommandHandler> logger)
        {
            _userLogics = userLogics;
            _logger = logger;
        }

        public async Task<GenericResponse<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing user creation command for {Email}", request.Email);
            return await _userLogics.CreateUser(request);
        }
    }
}
