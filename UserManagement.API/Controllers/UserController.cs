using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Shared;
using UserManagement.Shared.DOTs.RequestDTO;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            _logger.LogInformation("Received request to create user with email: {Email}", request.Email);

            var response = await _mediator.Send(request);

            return GenerateActionResult(response);
        }

        /// <summary>
        /// Converts a GenericResponse<T> into an IActionResult using the appropriate status code.
        /// </summary>
        private IActionResult GenerateActionResult<T>(GenericResponse<T> response)
        {
            return StatusCode(response.Code, response);
        }
    }
}
