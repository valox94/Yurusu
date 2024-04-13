namespace Occam.UI.Audio.Typing;

public interface ITypingAudio
{
    public void StartTyping();
    public void StopTyping();
}

public class TypingAudio : ITypingAudio
{
    private readonly ITypingSound _sound;

    public TypingAudio(ITypingSound sound)
    {
        _sound = sound;
    }

    public void StartTyping()
    {
        _sound.PlayLoop();
    }

    public void StopTyping()
    {
        _sound.Stop();
    }
}

public interface ITypingSound : IGameSound { }

public class TypingSound : GameSound, ITypingSound
{
    public TypingSound() : base("Occam.Assets.Audio.Typing.WobbleType1.wav")
    {
    }
}