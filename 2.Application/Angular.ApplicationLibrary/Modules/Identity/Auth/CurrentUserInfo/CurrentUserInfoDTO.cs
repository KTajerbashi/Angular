using Angular.ApplicationLibrary.BaseApplication.DTO;

namespace Angular.ApplicationLibrary.Modules.Identity.Auth.CurrentUserInfo
{
    public class CurrentUserInfoDTO : BaseDTO
    {
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ErrorMessage { get; set; }
        public string? DisplayName { get; set; }
        public string? NationalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserRoleId { get; set; }
        public string? RoleId { get; set; }
        public string? IsAdmin { get; set; }
        public bool DataIsLoaded { get; set; }
        public required List<string> Roles { get; set; }

    }
}
