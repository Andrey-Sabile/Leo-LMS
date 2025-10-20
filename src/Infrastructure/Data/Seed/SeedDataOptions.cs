namespace LeoLMS.Infrastructure.Data.Seed;

public class SeedDataOptions
{
    /// <summary>
    /// Directory (relative to the application's content root) that contains endpoint seed files.
    /// Defaults to "SeedData".
    /// </summary>
    public string DirectoryName { get; set; } = "SeedData";

    /// <summary>
    /// When true, the reader throws if a seed file is missing. When false, missing files
    /// are treated as optional.
    /// </summary>
    public bool ThrowOnMissingFile { get; set; }
}
