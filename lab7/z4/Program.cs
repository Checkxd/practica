public class VolumeControl
{
    public event EventHandler<int> VolumeChanged;

    public void ChangeVolume(int volume)
    {
        VolumeChanged?.Invoke(this, volume);
    }
}

public class VolumeManager
{
    private readonly VolumeControl _control;
    private readonly Display _display;
    private readonly SpeakerSystem _speaker;

    public VolumeManager(VolumeControl control, Display display, SpeakerSystem speaker)
    {
        _control = control;
        _display = display;
        _speaker = speaker;

        _control.VolumeChanged += _display.ShowVolume;
        _control.VolumeChanged += _speaker.AdjustVolume;
    }
}

public class Display
{
    public void ShowVolume(object sender, int volume)
    {
        Console.WriteLine($"Display: Volume is {volume}%");
    }
}

public class SpeakerSystem
{
    public void AdjustVolume(object sender, int volume)
    {
        Console.WriteLine($"Speaker: Volume adjusted to {volume}%");
    }
}

class Program
{
    static void Main(string[] args)
    {
        VolumeControl control = new VolumeControl();
        Display display = new Display();
        SpeakerSystem speaker = new SpeakerSystem();

        VolumeManager manager = new VolumeManager(control, display, speaker);

        control.ChangeVolume(30);
        control.ChangeVolume(80);
    }
}