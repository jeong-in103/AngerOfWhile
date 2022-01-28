using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreHighlight;

    private GameObject scoreText;

    private bool isHighlight;
    public bool IsHighlight { get { return isHighlight; } }

    private void Awake()
    {
        scoreHighlight = GetComponentInChildren<TextMeshProUGUI>();

        isHighlight = false;
    }

    public void ScoreAccent(int score, GameObject text)
    {
        isHighlight = true;
        scoreText = text;
        scoreHighlight.text = score.ToString();

        this.gameObject.SetActive(true);

        Invoke("OffScoreAccent", 1.5f);
    }

    private void OffScoreAccent()
    {
        this.gameObject.SetActive(false);
        scoreText.SetActive(true);
        isHighlight = false;
    }
}
