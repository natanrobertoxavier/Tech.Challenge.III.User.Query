namespace User.Query.Communication.Response;

public class ResponseUserJson(
    string name, 
    string email)
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
}
