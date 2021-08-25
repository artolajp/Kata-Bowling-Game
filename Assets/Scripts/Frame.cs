using System;

public class Frame
{
    public const int PINS_COUNT = 10;
    private const int BALLS_COUNT = 2;

    private int[] balls;
    public int[] Balls { get => balls; set => balls = value; }
    public Frame NextFrame { get; set; }

    private bool isFinished;
    public bool IsFinished { get => isFinished; private set => isFinished = value; }
    public bool IsLastFrame { get => NextFrame == null; }
    public bool IsStrike { get => Balls[0] == PINS_COUNT; }
    public bool IsSpare { get => Balls[0]+ Balls[1] == PINS_COUNT && !IsStrike; }

    private int currentBall = 0;

    public int Score {
        get
        {
            int score = SumScore();
            if (!IsLastFrame && IsStrike)
            {
                return score + NextBallScore() + NextSecondBallScore();
            }
            else if (!IsLastFrame && IsSpare)
            {
                return score + NextBallScore();
            }
            return score;

        }
    }

    private int SumScore()
    {
        int sum = 0;
        foreach (var ball in Balls)
        {
            sum += ball;
        }

        return sum;
    }

    public Frame() {
        Balls = new int[BALLS_COUNT];
    }

    public void KnockDown(int knockedDownPins) {
        if (currentBall < Balls.Length) {
            Balls[currentBall] = knockedDownPins;
            if(!IsLastFrame && IsStrike) {
                Array.Resize(ref balls, 1);
            }
        }
        currentBall++;

        if (IsLastFrame && (IsStrike || IsSpare) && Balls.Length < 3) {
            Array.Resize(ref balls, BALLS_COUNT+1);
        }

        IsFinished = currentBall >= Balls.Length;
    }

    public int NextBallScore()
    {
        if (IsLastFrame) 
        {
            return Balls[1];
        }
        return NextFrame.Balls[0];
    }

    public int NextSecondBallScore()
    {
        if (NextFrame.IsStrike)
        {
            return NextFrame.NextBallScore();
        }
        return NextFrame.Balls[1];

    }
}