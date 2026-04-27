using System.ComponentModel.DataAnnotations;

namespace AngularApp.Core.Application.UseCases.Aggregate
{
    public class UserEducation
    {
        [Required(ErrorMessage = "Degree is required")]
        [StringLength(100, ErrorMessage = "Degree cannot exceed 100 characters")]
        [Display(Name = "Highest Degree")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Institution name is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Institution name must be between 3 and 200 characters")]
        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Graduation year is required")]
        [Range(1950, 2100, ErrorMessage = "Graduation year must be between 1950 and 2100")]
        [CustomValidation(typeof(UserEducation), nameof(ValidateGraduationYear))]
        [Display(Name = "Graduation Year")]
        public int GraduationYear { get; set; }

        [Required(ErrorMessage = "Field of study is required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Field of study must be between 3 and 150 characters")]
        [Display(Name = "Field of Study")]
        public string FieldOfStudy { get; set; }

        [Range(0, 4, ErrorMessage = "GPA must be between 0 and 4")]
        [Display(Name = "GPA")]
        public decimal? GPA { get; set; }

        [Display(Name = "Certifications")]
        public List<string> Certifications { get; set; }

        // Custom validation for graduation year (cannot be in future if not completed)
        public static ValidationResult ValidateGraduationYear(int year, ValidationContext context)
        {
            var currentYear = DateTime.Now.Year;

            if (year > currentYear + 5)
                return new ValidationResult("Graduation year cannot be more than 5 years in the future");

            return ValidationResult.Success;
        }

        public UserEducation()
        {
            Certifications = new List<string>();
        }
    }
}