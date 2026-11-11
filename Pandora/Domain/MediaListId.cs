namespace Pandora.Domain;

public record MediaListId(Guid Value)
{
    public static MediaListId Generate()
        => new(Guid.NewGuid());

    public MediaListId(string value)
        : this(Guid.Parse(value))
    { }
}
