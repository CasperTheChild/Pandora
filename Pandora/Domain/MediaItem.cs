using System.IO;

namespace Pandora.Domain;

public class MediaItem
{
    public MediaItemId Id { get; private set; }

    public string Name { get; private set; }

    public string AudioPath { get; private set; }

    public bool IsEnabled { get; private set; }

    public Configuration Configuration { get; private set; }

    public MediaItem(
        MediaItemId id, 
        string name, 
        string audioPath, 
        bool isEnabled, 
        Configuration configuration)
    {
        ValidateName(name);
        ValidatePath(audioPath);
        ArgumentNullException.ThrowIfNull(configuration);

        Id = id;
        Name = name;
        AudioPath = audioPath;
        IsEnabled = isEnabled;
        Configuration = configuration;
    }

    public static MediaItem Create(
        string name,
        string audioPath)
    {
        return new MediaItem(
            MediaItemId.Generate(),
            name,
            audioPath,
            true,
            new Configuration());
    }

    public void ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void Enable()
        => IsEnabled = true;

    public void Disable()
        => IsEnabled = false;

    public void ChangeConfiguration(Configuration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        Configuration = configuration;
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

    private void ValidatePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));
    }
}
