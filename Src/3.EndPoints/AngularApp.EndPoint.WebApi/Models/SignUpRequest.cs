namespace AngularApp.EndPoint.WebApi.Models;

public record SignUpRequest(string FirstName, string LastName, string Username, string Email, string Phone, string Password);
