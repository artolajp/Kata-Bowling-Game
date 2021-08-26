using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform framesContainer;
    private List<FrameUI> frameUIs;

    private Game game;

    void Start()
    {
        game = new Game();

        frameUIs = new List<FrameUI>(framesContainer.GetComponentsInChildren<FrameUI>());
        
        for (int i = 0; i < 20; i++) {
            game.Roll(5);
        }
        game.Roll(10);

        /*
        for (int i = 0; i < 12; i++) {
            game.Roll(10);
        }*/
        DrawResults(game);
    }

    private void DrawResults(Game game) {
        for (int i = 0; i< game.frames.Length; i++ ) {
            frameUIs[i].Initialize(i+1 , game.frames[i].Score, game.frames[i].Balls, game.frames[i].IsStrike, game.frames[i].IsSpare);
        }
    }

}
