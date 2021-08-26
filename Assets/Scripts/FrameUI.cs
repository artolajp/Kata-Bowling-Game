using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text frameNumberLabel;
    [SerializeField] private TMP_Text frameScoreLabel;

    [SerializeField] private List<TMP_Text> ballLabels;

    [SerializeField] private List<GameObject> ballContainers;

    public void Initialize(int frameNumber, int frameScore, int[] balls,int currentBall, bool isStrike, bool isSpare) {
        frameNumberLabel.text = $"{frameNumber}";

        frameScoreLabel.text = currentBall >= balls.Length ? $"{frameScore}" : "";

        ballContainers.ForEach(TurnOffContainer);

        for (int i = 0; i < balls.Length; i++) {
            if ((isStrike && balls.Length == 1) 
                || ( balls.Length == 3 && balls[i] == 10))
                if (i == 1 && balls[0] < 10)
                    ballLabels[i].text = "/";
                else
                    ballLabels[i].text = "X";
            else if (isSpare && i == 1)
                ballLabels[i].text = "/";
            else if (i + 1 > currentBall) {
                ballLabels[i].text = "";
            } else {
                ballLabels[i].text = balls[i] == 0 ? "-" : $"{balls[i]}"; 
            }

            ballContainers[i].SetActive(true);
        }
    }

    private void TurnOffContainer(GameObject container) {
        container.SetActive(false);
    }
}
