using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    private void Reset()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }

    public void Add(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score.ToString();
    }
}
