namespace User.Query.Communication.Response;

public struct Result<T>(
    T value,
    bool isSuccess,
    string error)
{
    public T Value { get; } = value;
    public bool IsSuccess { get; } = isSuccess;
    public string Error { get; } = error;

    public Result<T> Success(T value) => new Result<T>(value, true, string.Empty);

    public new Result<T> Failure(string error) => new Result<T>(default, false, error);
}
