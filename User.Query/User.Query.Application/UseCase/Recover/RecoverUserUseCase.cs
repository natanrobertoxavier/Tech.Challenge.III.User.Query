using Serilog;
using User.Query.Communication.Response;
using User.Query.Domain.Repositories;

namespace User.Query.Application.UseCase.Recover;
public class RecoverUserUseCase(
    IUserReadOnlyRepository userReadOnlyRepository,
    ILogger logger) : IRecoverUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = userReadOnlyRepository;
    private readonly ILogger _logger = logger;
    private const string logMessageDefault = "of email user consultation.";

    public async Task<Result<ResponseUserJson>> Execute(string email)
    {
        var output = new Result<ResponseUserJson>();

        try
        {
            _logger.Information($"Start {logMessageDefault}");

            var user = await _userReadOnlyRepository.RecoverByEmailAsync(email);

            if (user is null)
            {
                var notFoundMessage = string.Format("No user found with email: {0}", email);

                _logger.Warning(notFoundMessage);

                return output.Failure(notFoundMessage); ;
            }

            _logger.Information($"End {logMessageDefault}");

            return output.Success(new ResponseUserJson(user.Name, user.Email));
        }
        catch (Exception ex)
        {
            var errorMessage = string.Format("There are an error: {0}", ex.Message);

            _logger.Error(ex, errorMessage);

            return output.Failure(errorMessage); ;
        }
    }
}
