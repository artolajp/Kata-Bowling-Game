using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameView
{
    void Initialize(GamePresenter presenter, string initalGame);
    void RunGame(int[] rolls);
    void DrawScore(int score);
    void DrawFrame(int frameNumber, int frameScore, int[] balls, int currentBall, bool isStrike, bool isSpare);
}
