namespace Pandora.Domain;

public record Configuration
{
    public double Volume { get; private set; } = 1.0;

    public double Speed { get; private set; } = 1.0;

    public double Appearance { get; private set; } = 1.0;

    public TimeSpan Duration { get; private set; } = TimeSpan.FromMinutes(1);

    public TimeSpan Cooldown { get; private set; } = TimeSpan.FromSeconds(30);

    public Configuration() { }

    public Configuration(
        double volume,
        double speed,
        double appearance,
        TimeSpan duration,
        TimeSpan cooldown)
    {
        if (double.IsNaN(volume) ||
            volume < 0 ||
            volume > 1)
            throw new ArgumentOutOfRangeException(
                nameof(Volume),
                volume,
                $"{nameof(Volume)} is outside the allowed range.");

        if (double.IsNaN(speed) ||
            speed < 0.5 ||
            speed > 2)
            throw new ArgumentOutOfRangeException(
                nameof(Speed),
                speed,
                $"{nameof(Speed)} is outside the allowed range.");

        if (double.IsNaN(appearance) ||
            appearance < 0 ||
            appearance > 1)
            throw new ArgumentOutOfRangeException(
                nameof(Appearance),
                appearance,
                $"{nameof(Appearance)} is outside the allowed range.");

        if (duration <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(duration));

        if (duration > TimeSpan.FromHours(1))
            throw new ArgumentOutOfRangeException(nameof(duration));

        if (cooldown <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(cooldown));

        if (cooldown > TimeSpan.FromDays(1))
            throw new ArgumentOutOfRangeException(nameof(cooldown));

        Volume = volume;
        Speed = speed;
        Appearance = appearance;
        Duration = duration;
        Cooldown = cooldown;
    }
}
