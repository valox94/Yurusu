using Occam.UI.Audio.Typing;

namespace Occam.Application.Interface.View;


public interface IViewBox
{
    public void SetOrigin(int left, int top);
    void Display(string word, ITypingAudio typingAudio);
    void Reset();
    void AddBreak(ITypingAudio typingAudio);
    void Initialize();
    void Dispose();
}
public abstract class ViewBox : IViewBox
{
    public abstract void SetOrigin(int left, int top);
    public abstract void Display(string word, ITypingAudio typingAudio);
    public abstract void Reset();
    public abstract void AddBreak(ITypingAudio typingAudio);
    public abstract void Initialize();
    public abstract void Dispose();
}