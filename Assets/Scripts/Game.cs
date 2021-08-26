using System;

public class Game
{
    private const int FRAMES_COUNT = 10;
    public Frame[] frames;

    public int CurrentFrame { get; set; }

    public int Score {
        get {
            int sum = 0;
            foreach (var frame in frames) {
                sum += frame.Score;
            }
            return sum;
        }
    }

    public bool IsFinished { get { return frames[frames.Length - 1].IsFinished; } }

    public Game() {
        frames = new Frame[FRAMES_COUNT];
        InitFrames();
    }

    private void InitFrames() {
        Frame lastFrame = null;
        for (int index = 0; index < FRAMES_COUNT; index++) {
            Frame newFrame = new Frame();
            if (lastFrame != null) lastFrame.NextFrame = newFrame;
            lastFrame = newFrame;
            frames[index] = newFrame;
        }
    }

    public void Roll(int knockedDown) {
        if (CurrentFrame >= frames.Length)
            return;

        frames[CurrentFrame].KnockDown(knockedDown);
        if (frames[CurrentFrame].IsFinished) CurrentFrame++;
    }
}