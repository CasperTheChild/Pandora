namespace Pandora.Domain;

public record MediaItemId(Guid Value)
{
    public static MediaItemId Generate()
        => new(Guid.NewGuid());

    public MediaItemId(string value)
        : this(Guid.Parse(value)) 
    { }
}
