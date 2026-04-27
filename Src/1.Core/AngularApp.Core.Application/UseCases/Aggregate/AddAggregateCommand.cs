using System.ComponentModel.DataAnnotations;

namespace AngularApp.Core.Application.UseCases.Aggregate
{
    // Command and Handler implementations
    public class AddAggregateCommand : ICommand
    {
        [Required]
        public UserInfo UserInfo { get; set; }

        [Required]
        public UserEducation UserEducation { get; set; }
    }

    public class AddAggregateHandler : CommandHandler<AddAggregateCommand>
    {
        public AddAggregateHandler(ProviderServices provider) : base(provider)
        {
        }

        public override async Task Handle(AddAggregateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "User data is required");

            // Validate
            //var validator = new UserModelValidator();
            //var validationResult = await validator.ValidateAsync(userModel, cancellationToken);

            //if (!validationResult.IsValid)
            //{
            //    throw new ValidationException(string.Join("; ", validationResult.Errors));
            //}

            // Validate the model
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(request);

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
            {
                var errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }

            // TODO: Add business logic here
            // Example: Save to database
            await SaveToDatabase(request, cancellationToken);
        }

        private async Task SaveToDatabase(AddAggregateCommand userData, CancellationToken cancellationToken)
        {
            // Implement database save logic
            // Example using your repository pattern:
            // var repository = Provider.GetService<IUserRepository>();
            // await repository.AddAsync(userData, cancellationToken);
            // await repository.SaveChangesAsync(cancellationToken);

            await Task.CompletedTask;
        }
    }

    // Enum for Gender (better than using magic numbers)
    public enum Gender : byte
    {
        [Display(Name = "Prefer not to say")]
        PreferNotToSay = 0,

        [Display(Name = "Male")]
        Male = 1,

        [Display(Name = "Female")]
        Female = 2,

        [Display(Name = "Other")]
        Other = 3
    }

    // DTO for response
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    // Search/Filter model
    public class UserSearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string Degree { get; set; }
        public int? GraduationYearFrom { get; set; }
        public int? GraduationYearTo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    // Update model for partial updates
    public class UpdateUserModel
    {
        public UserInfo UserInfo { get; set; }
        public UserEducation UserEducation { get; set; }
    }
}