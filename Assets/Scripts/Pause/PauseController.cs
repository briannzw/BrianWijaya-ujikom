using UnityEngine;

public class PauseController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf) Time.timeScale = 1f;
            else Time.timeScale = 0f;

            pausePanel.SetActive(!pausePanel.activeSelf);
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
