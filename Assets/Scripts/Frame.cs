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
                return score + NextBallScore() + NextSecondBallScore() ;
            } else if (score == PinsCount) {
                return score + NextBallScore();
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
        if (NextFrame == null && currentBall < 3 && Score == PinsCount && BallsCount < 3) {
            BallsCount++;
            Array.Resize(ref balls, BallsCount);
        }
    }

    public int NextBallScore()
    {
        if (NextFrame == null)
        {
            return 0;
        }
        if (balls[0] < PinsCount)
        {
            return balls[1];
        }
        return NextFrame.balls[0];
    }

    public int NextSecondBallScore()
    {
        if (NextFrame.balls[0] < PinsCount)
        {
            return NextFrame.balls[1];
        }
        return NextFrame.NextBallScore();

    }
}