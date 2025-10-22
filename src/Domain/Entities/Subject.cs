namespace LeoLMS.Domain.Entities;

public class Subject : BaseAuditableEntity
{
    private Subject() { }

    public string Name { get; private set; } = null!;

    public string Code { get; private set; } = null!;

    public string? Description { get; private set; }

    public static Subject Create(
        string name,
        string code,
        string? description = null)
    {
        var subject = new Subject();
        subject.SetDetails(name, code, description);
        return subject;
    }

    public void UpdateDetails(
        string name,
        string code,
        string? description = null)
    {
        SetDetails(name, code, description);
    }

    private void SetDetails(
        string name,
        string code,
        string? description)
    {
        ValidateFields(name, code);

        Name = name.Trim();
        Code = code.Trim();
        Description = NormalizeDescription(description);
    }

    private static void ValidateFields(string name, string code)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Code is required.", nameof(code));
    }

    private static string? NormalizeDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return null;

        return description.Trim();
    }
}
