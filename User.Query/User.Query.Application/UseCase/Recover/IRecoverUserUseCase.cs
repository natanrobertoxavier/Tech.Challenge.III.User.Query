
using User.Query.Communication.Request;
using User.Query.Communication.Response;

namespace User.Query.Application.UseCase.Recover;
public interface IRecoverUserUseCase
{
    Task<Result<ResponseExistsUserJson>> ThereIsUserWithEmail(string email);
    Task<Result<ResponseUserJson>> RecoverByEmail(string email);
    Task<Result<ResponseUserJson>> RecoverEmailPassword(RequestLoginJson request);
}
