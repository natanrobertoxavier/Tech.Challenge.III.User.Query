
using User.Query.Communication.Response;

namespace User.Query.Application.UseCase.Recover;
public interface IRecoverUserUseCase
{
    Task<Result<ResponseUserJson>> Execute(string email);
}
