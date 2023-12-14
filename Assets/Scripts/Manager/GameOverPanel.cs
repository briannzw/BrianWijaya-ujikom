using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text prevScoreText;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        scoreText.text = prevScoreText.text;
    }   
}
