using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coinsCollected = 0;
    public int coinsRequired = 3;

    public GameObject exitPortal;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();

        if (exitPortal != null)
            exitPortal.SetActive(false);
    }

    public void CollectCoin()
    {
        coinsCollected++;
        UpdateUI();

        if (coinsCollected >= coinsRequired)
        {
            tutorialText.text = "Exit Unlocked!";
            exitPortal.SetActive(true);
        }
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinsCollected + " / " + coinsRequired;
        }
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}