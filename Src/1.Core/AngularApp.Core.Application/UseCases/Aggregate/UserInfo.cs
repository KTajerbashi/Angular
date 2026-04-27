using System.ComponentModel.DataAnnotations;

namespace AngularApp.Core.Application.UseCases.Aggregate
{
    public class UserInfo
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Phone number must be 10-15 digits")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(UserInfo), nameof(ValidateAge))]
        [Display(Name = "Date of Birth")]
        public string DateBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Range(0, 255, ErrorMessage = "Invalid gender value")]
        [Display(Name = "Gender")]
        public byte Gender { get; set; }

        // Custom validation for age (must be at least 18)
        public static ValidationResult ValidateAge(string dateBirth, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(dateBirth))
                return new ValidationResult("Date of birth is required");

            if (!DateTime.TryParse(dateBirth, out DateTime birthDate))
                return new ValidationResult("Invalid date format");

            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            if (age < 18)
                return new ValidationResult($"You must be at least 18 years old. Current age: {age}");

            if (age > 120)
                return new ValidationResult("Please enter a valid date of birth");

            return ValidationResult.Success;
        }
    }
}