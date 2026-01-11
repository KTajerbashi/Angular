namespace AngularApp.EndPoint.WebApi.Models;

public record ProductDTO(long Id,string Title, decimal Price, int Rate);
public record LoginRequest(string Username, string Password, bool RemeberMe);
public record SignUpRequest(string FirstName, string LastName, string Username, string Email, string Phone, string Password);
