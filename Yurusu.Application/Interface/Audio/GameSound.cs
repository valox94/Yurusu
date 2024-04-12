using System.Media;
using System.Reflection;
namespace Yurusu.UI.Audio;


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
        var stream = typeof(Yurusu.Assets.Assembly).Assembly.GetManifestResourceStream(soundResourceName);
        if (stream == null)
            throw new InvalidOperationException("Sound resource not found.");

        _player = new SoundPlayer(stream);
        
        _loadingTask = Task.Run(() => { _player.Load(); });
    }

    
    public void PlayLoop()
    {
        _loadingTask.ContinueWith(t => _player.PlayLooping(), TaskScheduler.Default);
    }

    public void Stop()
    {
        _loadingTask.ContinueWith(t => _player.Stop(), TaskScheduler.Default);

    }
}
