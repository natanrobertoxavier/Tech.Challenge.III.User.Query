using Microsoft.AspNetCore.Mvc;
using User.Query.Application.UseCase.Recover;
using User.Query.Communication.Response;

namespace User.Query.Api.Controllers.v1;

public class UserController : TechChallengeController
{
    [HttpGet("{email}")]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RecoverUser(
        [FromServices] IRecoverUserUseCase useCase,
        [FromRoute] string email)
    {
        var result = await useCase.Execute(email);

        return Ok(result);
    }
}
