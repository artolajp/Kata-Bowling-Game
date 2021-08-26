using System;

public class Frame
{
    public const int PINS_COUNT = 10;
    private const int BALLS_COUNT = 2;

    private int currentBall = 0;

    private int[] balls;
    public int[] Balls { get => balls; protected set => balls = value; }

    public Frame NextFrame { get; set; }

    public bool IsLastFrame { get => NextFrame == null; }

    private bool isFinished;
    public bool IsFinished { get => isFinished; }
    public bool IsStrike { get => Balls[0] == PINS_COUNT; }
    public bool IsSpare { get => Balls[0] + Balls[1] == PINS_COUNT && !IsStrike; }

    public int Score {
        get {
            int score = SumScore();
            if (!IsLastFrame && IsStrike) {
                return score + NextBallScore + NextSecondBallScore;
            } else if (!IsLastFrame && IsSpare) {
                return score + NextBallScore;
            }
            return score;
        }
    }

    public int NextBallScore =>
        IsLastFrame ? Balls[1] : NextFrame.Balls[0];

    public int NextSecondBallScore =>
        NextFrame.IsStrike ? NextFrame.NextBallScore : NextFrame.Balls[1];

    public Frame() {
        Balls = new int[BALLS_COUNT];
    }

    private int SumScore() {
        int sum = 0;
        foreach (var ball in Balls) {
            sum += ball;
        }
        return sum;
    }

    public void KnockDown(int knockedDownPins) {
        bool isBallInFrame = currentBall < Balls.Length;

        if (isBallInFrame) {
            Balls[currentBall] = knockedDownPins;
            Remove2ndBallOnStrike();
            AddExtraBallOnLastFrame();
            currentBall++;
        }

        isFinished = currentBall >= Balls.Length;
    }

    private void AddExtraBallOnLastFrame() {
        bool hasExtraBall = Balls.Length < 3;
        if (IsLastFrame && (IsStrike || IsSpare) && hasExtraBall) {
            Array.Resize(ref balls, BALLS_COUNT + 1);
        }
    }

    private void Remove2ndBallOnStrike() {
        if (!IsLastFrame && IsStrike) {
            Array.Resize(ref balls, 1);
        }
    }

}
