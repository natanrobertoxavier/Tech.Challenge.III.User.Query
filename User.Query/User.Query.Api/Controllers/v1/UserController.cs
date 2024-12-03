using Microsoft.AspNetCore.Mvc;
using User.Query.Application.UseCase.Recover;
using User.Query.Communication.Request;
using User.Query.Communication.Response;

namespace User.Query.Api.Controllers.v1;

public class UserController : TechChallengeController
{
    [HttpGet("{email}")]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecoverUser(
        [FromServices] IRecoverUserUseCase useCase,
        [FromRoute] string email)
    {
        var result = await useCase.RecoverByEmail(email);

        return Ok(result);
    }

    [HttpGet("there-is-user/{email}")]
    [ProducesResponseType(typeof(ResponseExistsUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> ThereIsUser(
        [FromServices] IRecoverUserUseCase useCase,
        [FromRoute] string email)
    {
        var result = await useCase.ThereIsUserWithEmail(email);

        return Ok(result);
    }

    [HttpPost("recover-email-password")]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecoverByEmailAndPassword(
        [FromServices] IRecoverUserUseCase useCase,
        [FromBody] RequestEmailPasswordUserJson request)
    {
        var result = await useCase.RecoverEmailPassword(request);

        return Ok(result);
    }
}
