using System;

public class Frame
{
    public int PinsCount = 10;
    private int BallsCount = 2;

    public int[] balls;
    public int KnockedDownCount = 8;
    public Frame NextFrame { get; set; }

    public int Score { 
        get {
            int score = balls[0] + balls[1];
            if (score == 10) {
                return score + NextFrame.Score;
            } else
                return score;
        }
    }

    public Frame()
    {
        balls = new int[BallsCount];
    }

    public void KnockDown(int knockedDownPins) {
        balls[0] = knockedDownPins;
    }
}