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

    public void Initialize(int frameNumber, int frameScore, int[] balls, bool isStrike, bool isSpare) {
        frameNumberLabel.text = $"{frameNumber}";
        frameScoreLabel.text = $"{frameScore}";

        ballContainers.ForEach(TurnOffContainer);

        for (int i = 0; i < balls.Length; i++) {
            if (isStrike)
                ballLabels[i].text = "X" ;
            else if (isSpare && i == 1)
                ballLabels[i].text = "/";
            else 
                ballLabels[i].text = $"{balls[i]}";

            ballContainers[i].SetActive(true);
        }
    }

    private void TurnOffContainer(GameObject container) {
        container.SetActive(false);
    }
}
