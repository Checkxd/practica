public delegate void VolumeControl(int volume);

public class Speaker
{
    public void SetSpeakerVolume(int volume)
    {
        Console.WriteLine($"Speaker volume set to {volume}%");
    }
}

public class Headphones
{
    public void SetHeadphonesVolume(int volume)
    {
        Console.WriteLine($"Headphones volume set to {volume}%");
    }
}

class Program
{
    static void AdjustVolume(VolumeControl control, int volume)
    {
        control(volume);
    }

    static void Main(string[] args)
    {
        Speaker speaker = new Speaker();
        Headphones headphones = new Headphones();

        VolumeControl speakerControl = speaker.SetSpeakerVolume;
        VolumeControl headphonesControl = headphones.SetHeadphonesVolume;

        AdjustVolume(speakerControl, 75);
        AdjustVolume(headphonesControl, 50);
    }
}