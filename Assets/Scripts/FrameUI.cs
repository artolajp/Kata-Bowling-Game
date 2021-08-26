using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text frameNumberLabel;
    [SerializeField] private TMP_Text frameScoreLabel;

    [SerializeField] private TMP_Text ball1Label;
    [SerializeField] private TMP_Text ball2Label;
    [SerializeField] private TMP_Text ball3Label;

    [SerializeField] private GameObject ball1Container;
    [SerializeField] private GameObject ball2Container;
    [SerializeField] private GameObject ball3Container;
}
