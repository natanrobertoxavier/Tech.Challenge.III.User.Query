using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using User.Query.Communication.Response;
using User.Query.Integration.Tests.Fakes.Request;

namespace User.Query.Integration.Tests.Api.Controllers.v1;
public class UserControllerTests() : BaseTestClient("/api/v1/user")
{
    [Fact]
    public async Task RecoverByEmailAndPassword_ReturnsOk_WhenCorrectEmailAndPassword()
    {
        // Arrange
        var user = Factory.RecoverUser();

        var request = new RequestEmailPasswordUserJsonBuilder()
            .WithEmail(user.Email)
            .WithPassword(user.Password)
            .Build();

        var uri = string.Concat(ControllerUri, "/recover-email-password");

        // Act
        var response = await Client.PostAsJsonAsync(uri, request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var loggedUserJson = await DeserializeResponse<Response.Result<ResponseUserJson>>(response);

        loggedUserJson.Data.Name.Should().NotBeNullOrWhiteSpace();
        loggedUserJson.Data.Email.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task RecoverByEmailAndPassword_ReturnsOk_WhenIncorrectEmailAndPassword()
    {
        // Arrange
        var user = Factory.RecoverUser();

        var request = new RequestEmailPasswordUserJsonBuilder()
            .WithEmail("incorrect-email")
            .WithPassword("incorrect-password")
            .Build();

        var uri = string.Concat(ControllerUri, "/recover-email-password");

        // Act
        var response = await Client.PostAsJsonAsync(uri, request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var loggedUserJson = await DeserializeResponse<Response.Result<ResponseUserJson>>(response);

        loggedUserJson.Data.Should().BeNull();
        loggedUserJson.IsSuccess.Should().BeFalse();
        loggedUserJson.Error.Equals("Invalid email or username.");
    }

    [Fact]
    public async Task RecoverByEmailAndPassword_ReturnsOk_WhenAnErrorOccurs()
    {
        // Arrange
        var user = Factory.RecoverUser();

        var request = new RequestEmailPasswordUserJsonBuilder()
            .WithEmail("incorrect-email")
            .WithPassword("incorrect-password")
            .Build();

        var uri = string.Concat(ControllerUri, "/recover-email-password");

        // Act
        var response = await Client.PostAsJsonAsync(uri, request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var loggedUserJson = await DeserializeResponse<Response.Result<ResponseUserJson>>(response);

        loggedUserJson.Data.Should().BeNull();
        loggedUserJson.IsSuccess.Should().BeFalse();
        loggedUserJson.Error.Equals("Invalid email or username.");
    }

}
