using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour, IGameView
{
    [SerializeField] private Transform framesContainer;
    private List<FrameUI> frameUIs;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_InputField rollsInput;
    [SerializeField] private Button runButton;

    [SerializeField] private float animationTime = 0.1f;

    private GamePresenter presenter;

    private void Awake() {
        frameUIs = new List<FrameUI>(framesContainer.GetComponentsInChildren<FrameUI>());
        runButton.onClick.AddListener(OnRunGameClick);
    }

    private void Start() {
        presenter = new GamePresenter();
        presenter.Initialize(this);
    }

    public void Initialize(GamePresenter presenter, string initalGame) {
        this.presenter = presenter;
        rollsInput.text = initalGame;
        presenter.RunGame(rollsInput.text);
    }

    public void OnRunGameClick() {
        StopCoroutine(nameof(rollsRutine));
        presenter.RunGame(rollsInput.text);
    }

    public void RunGame(int[] rolls) {
        StartCoroutine(rollsRutine(rolls));
    }


    private IEnumerator rollsRutine(int[] rolls) {
        yield return new WaitForSeconds(1);

        foreach (var pins in rolls) {
            presenter.Roll(pins);
            yield return new WaitForSeconds(animationTime);
        }
    }

    public void DrawFrame(int frameNumber, int frameScore, int[] balls, int currentBall, bool isStrike, bool isSpare) {
        frameUIs[frameNumber - 1].Initialize(frameNumber, frameScore, balls, currentBall, isStrike, isSpare);
    }

    public void DrawScore(int score) {
        scoreText.text = score.ToString();
    }
}
