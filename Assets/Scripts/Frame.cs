using System;

public class Frame
{
    public int PinsCount = 10;
    private int BallsCount = 2;

    public int[] balls;
    public Frame NextFrame { get; set; }

    private int currentBall = 0;

    public int Score {
        get {
            int score = balls[0] + balls[1];
            if (NextFrame == null) {
                return score;
            } else if (balls[0] == PinsCount) {
                return score + NextFrame.Score;
            } else if (score == PinsCount) {
                return score + NextFrame.balls[0];
            } else {
                return score;
            }
        }
    }

    public Frame() {
        balls = new int[BallsCount];
    }

    public void KnockDown(int knockedDownPins) {
        if (currentBall < balls.Length) {
            balls[currentBall] = knockedDownPins;
        }
        currentBall++;
        if (NextFrame == null && currentBall == 2 && Score == PinsCount && BallsCount < 3) {
            BallsCount++;
            Array.Resize(ref balls, BallsCount);
            var length = balls.Length;

        }
    }
}