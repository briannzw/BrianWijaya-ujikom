using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private PlayerMovementController playerMovement;
    [SerializeField] private PlayerThrowController playerThrow;
    [SerializeField] private AnimalSpawner animalSpawner;
    [SerializeField] private PauseController pauseController;

    [Header("UI References")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Parameters")]
    [SerializeField] private float gameTime = 60;
    private float gameTimer;

    private bool IsOver = false;

    public void Reset()
    {
        IsOver = false;
        gameOverPanel.SetActive(false);
        gameTimer = gameTime;
        playerAnimator.SetBool("IsGameOver", false);
        timerText.text = "Timer: " + Mathf.RoundToInt(gameTimer).ToString();
        playerMovement.enabled = true;
        playerThrow.enabled = true;
        animalSpawner.enabled = true;
        pauseController.enabled = true;
    }

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (IsOver) return;

        if (gameTimer <= 0f)
        {
            IsOver = true;
            gameTimer = 0f;
            timerText.text = "Timer: 0";
            StartCoroutine(GameOver());
            return;
        }

        gameTimer -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.RoundToInt(gameTimer).ToString();
    }

    private IEnumerator GameOver()
    {
        playerMovement.enabled = false;
        playerThrow.enabled = false;
        animalSpawner.StopAllCoroutines();
        animalSpawner.enabled = false;
        pauseController.enabled = false;

        // Animation
        playerAnimator.SetBool("IsGameOver", true);

        yield return new WaitForSeconds(2f);

        gameOverPanel.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
