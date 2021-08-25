using System;

public class Game
{
    private int FramesCount = 10;
    public Frame[] frames;

    public int CurrentFrame { get; set; }

    public int Score { get {
        int sum = 0;
        foreach (var frame in frames)
        {
            sum += frame.Score;
        }
        return sum;
    }}

    public bool IsFinished { get { return frames[frames.Length - 1].isFinished; } }

    public Game()
    {
        frames = new Frame[FramesCount];
        Frame lastFrame = null;
        for (int index = 0; index < FramesCount; index++)
        {
            Frame newFrame = new Frame();
            if (lastFrame != null) lastFrame.NextFrame = newFrame;
            lastFrame = newFrame;
            frames[index] = newFrame;
        }
    }

    public void Roll(int knockedDown)
    {
        frames[CurrentFrame].KnockDown(knockedDown);
        if (frames[CurrentFrame].isFinished) CurrentFrame++;
    }
}