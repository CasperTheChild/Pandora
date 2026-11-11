namespace Pandora.Domain;

public class MediaList
{
    public MediaListId Id { get; private set; }

    public string Name { get; private set; }

    public bool IsEnabled { get; private set; }

    private IList<MediaItem> mediaItems = new List<MediaItem>();

    public IReadOnlyCollection<MediaItem> MediaItems => mediaItems.AsReadOnly();

    public MediaList(
        MediaListId id,
        string name,
        bool isEnabled,
        IList<MediaItem> mediaItems)
    {
        ValidateName(name);

        Id = id;
        Name = name;
        IsEnabled = isEnabled;
        this.mediaItems = mediaItems;
    }

    public static MediaList Create(
        string name)
    {
        return new MediaList(
            MediaListId.Generate(),
            name,
            true,
            []);
    }

    public void Enable()
        => IsEnabled = true;

    public void Disable()
        => IsEnabled = false;

    public void AddMediaItem(MediaItem item)
    {
        if (mediaItems.Contains(item))
            throw new ArgumentException("This list already contains this item");

        mediaItems.Add(item);
    }

    public void RemoveMediaItem(Guid id)
    {
        var mediaItem = mediaItems
            .FirstOrDefault(c => c.Id.Value == id);

        if (mediaItem is null)
            throw new ArgumentNullException(nameof(mediaItem));

        mediaItems.Remove(mediaItem);
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (name.Length < 5 || name.Length > 100)
            throw new ArgumentOutOfRangeException(
                nameof(name),
                "Name length should be between 5 and 100");
    }

}
