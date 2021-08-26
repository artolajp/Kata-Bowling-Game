using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Transform framesContainer;
    private List<FrameUI> frameUIs;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_InputField rollsInput;
    [SerializeField] private Button runButton;

    [SerializeField] private float animationTime = 0.1f;

    private Game game;

    void Start() {
        rollsInput.text = "5,3,10,6,0,2,5,6,4,4,0,0,0,6,3,2,8,10,10,10";

        frameUIs = new List<FrameUI>(framesContainer.GetComponentsInChildren<FrameUI>());

        runButton.onClick.AddListener(RunGame);

        RunGame();
    }

    private void RunGame() {
        StopCoroutine(nameof(rollsRutine));

        game = new Game();
        DrawResults(game);

        StartCoroutine(rollsRutine(ParseInputs(rollsInput.text)));
    }

    private int[] ParseInputs(string text) {
        var splittedText = text.Split(',');
        var arrayOfInputs = new int[splittedText.Length];

        for (int i = 0; i < splittedText.Length; i++) {
            arrayOfInputs[i] = int.Parse(splittedText[i]);
        }

        return arrayOfInputs;
    }

    private IEnumerator rollsRutine(int[] rolls) {
        yield return new WaitForSeconds(1);

        foreach (var pins in rolls) {
            game.Roll(pins);
            DrawResults(game);
            yield return new WaitForSeconds(animationTime);
        }

    }

    private void DrawResults(Game game) {
        for (int i = 0; i < game.frames.Length; i++) {
            frameUIs[i].Initialize(i + 1, game.frames[i].Score, game.frames[i].Balls, game.frames[i].CurrentBall, game.frames[i].IsStrike, game.frames[i].IsSpare);
        }
        scoreText.text = game.Score.ToString();
    }

}
