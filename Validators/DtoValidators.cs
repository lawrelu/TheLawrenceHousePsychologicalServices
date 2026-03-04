using FluentValidation;

public class CreateOrganisationDto
{
    public string Name { get; set; }
    // Other properties...
}

public class CreateShowDto
{
    public string Title { get; set; }
    // Other properties...
}

public class CreatePerformanceDto
{
    public string PerformanceDate { get; set; }
    // Other properties...
}

public class DtoValidators
{
    public class CreateOrganisationDtoValidator : AbstractValidator<CreateOrganisationDto>
    {
        public CreateOrganisationDtoValidator()
        {
            RuleFor(org => org.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");
            // Other rules...
        }
    }

    public class CreateShowDtoValidator : AbstractValidator<CreateShowDto>
    {
        public CreateShowDtoValidator()
        {
            RuleFor(show => show.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 200).WithMessage("Title must be between 1 and 200 characters.");
            // Other rules...
        }
    }

    public class CreatePerformanceDtoValidator : AbstractValidator<CreatePerformanceDto>
    {
        public CreatePerformanceDtoValidator()
        {
            RuleFor(performance => performance.PerformanceDate)
                .NotEmpty().WithMessage("Performance date is required.");
            // Other rules...
        }
    }
}