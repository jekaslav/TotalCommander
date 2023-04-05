using NAudio.Wave;

namespace TotalCommander;

public class Music
{
    public void MusicSong()
    {
        const string audioFile = @"C:\Dream_Theater_Octavarium.mp3";
        using var audioStream = new AudioFileReader(audioFile);
        using var outputDevice = new WaveOutEvent();
        {
            outputDevice.Init(audioStream);

            outputDevice.Play();
            Console.ReadKey();
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                outputDevice.Stop();
            }
        }
    }
}