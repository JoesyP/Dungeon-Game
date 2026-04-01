using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coinsCollected = 0;
    public int coinsRequired = 3;

    public GameObject exitPortal;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI coinText;

    public GameObject coinPrefab;
    public Transform[] coinSpawnPoints;
    public int coinsToSpawn = 3;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnCoins(); 
        UpdateUI();

        if (exitPortal != null)
            exitPortal.SetActive(false);
    }

    void SpawnCoins()
    {
        List<Transform> availablePoints = new List<Transform>(coinSpawnPoints);

        // Shuffle spawn points
        for (int i = 0; i < availablePoints.Count; i++)
        {
            Transform temp = availablePoints[i];
            int randomIndex = Random.Range(i, availablePoints.Count);

            availablePoints[i] = availablePoints[randomIndex];
            availablePoints[randomIndex] = temp;
        }

        // Spawn coins at unique positions
        for (int i = 0; i < coinsToSpawn && i < availablePoints.Count; i++)
        {
            Instantiate(coinPrefab, availablePoints[i].position, Quaternion.identity);
        }

        coinsRequired = coinsToSpawn; // keeps UI correct
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