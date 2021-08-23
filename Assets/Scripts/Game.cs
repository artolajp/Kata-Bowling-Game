public class Game
{
    private int FramesCount = 10;
    public Frame[] frames;

    public Game()
    {
        Frame frame = new Frame();
        frames = new Frame[FramesCount];
        frames[0] = frame;
        
    }
}