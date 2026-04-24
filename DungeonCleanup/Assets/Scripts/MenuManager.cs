using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject difficultyPanel;

    public void ToggleDifficulty()
    {
        difficultyPanel.SetActive(!difficultyPanel.activeSelf);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetEasy()
    {
        DifficultyManager.ghostSpeed = 4f;
        difficultyPanel.SetActive(false);

    }

    public void SetMedium()
    {
        DifficultyManager.ghostSpeed = 6f;
        difficultyPanel.SetActive(false);

    }

    public void SetHard()
    {
        DifficultyManager.ghostSpeed = 9f;
        difficultyPanel.SetActive(false);

    }
}