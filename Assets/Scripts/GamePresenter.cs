using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    private IGameView gameView;

    private string initalGame = "5,3,10,6,0,2,5,6,4,4,0,0,0,6,3,2,8,10,10,10";

    private Game game;

    public void Initialize(IGameView gameView)
    {
        this.gameView = gameView;
        gameView.Initialize(this, initalGame);
    }

    public void RunGame(string rolls) {
        game = new Game();
        gameView.RunGame(ParseInputs(rolls));
    }

    public void DrawResults() {
        gameView.DrawScore(game.Score);
        for (int i = 0; i < game.frames.Length; i++) {
            gameView.DrawFrame(i + 1, game.frames[i].Score, game.frames[i].Balls, game.frames[i].CurrentBall, game.frames[i].IsStrike, game.frames[i].IsSpare);
        }

    }

    private int[] ParseInputs(string text) {
        var splittedText = text.Split(',');
        var arrayOfInputs = new int[splittedText.Length];

        for (int i = 0; i < splittedText.Length; i++) {
            arrayOfInputs[i] = int.Parse(splittedText[i]);
        }

        return arrayOfInputs;
    }

    internal void Roll(int pins) {
        game.Roll(pins);
        DrawResults();
    }
}
