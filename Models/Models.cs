// In Models/Models.cs

public class Organisation
{
    // Existing properties...

    // Optional fields
    public string? LogoFileName { get; set; }
    public string? LogoUrl { get; set; }
}

public class Show
{
    // Existing properties...

    // Optional fields
    public string? PosterFileName { get; set; }
    public string? PosterUrl { get; set; }
}