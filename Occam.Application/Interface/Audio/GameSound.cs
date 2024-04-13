using System.Media;
using System.Reflection;
using Assembly = Occam.Assets.Assembly;

namespace Occam.UI.Audio;


public interface IGameSound
{
    public void PlayLoop();
    public void Stop();
} 
public abstract class GameSound : IGameSound
{
    private SoundPlayer _player;
    private Task _loadingTask;
    protected GameSound(string soundResourceName)
    {
        var stream = typeof(Assembly).Assembly.GetManifestResourceStream(soundResourceName);
        if (stream == null)
            throw new InvalidOperationException("Sound resource not found.");

        _player = new SoundPlayer(stream);
        _player.Load();
    }

    
    public void PlayLoop()
    {
        _player.PlayLooping();
    }

    public void Stop()
    {
        _player.Stop();
    }
}
