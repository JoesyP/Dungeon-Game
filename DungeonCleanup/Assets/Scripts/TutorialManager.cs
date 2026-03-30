using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    public static bool tutorialFinished = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("TutorialDone"))
        {
            StartCoroutine(RunTutorial());
        }
        else
        {
            tutorialFinished = true;
            tutorialText.text = "";
        }
    }

    IEnumerator RunTutorial()
    {
        tutorialFinished = false;

        tutorialText.text = "WASD to Move";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Move Mouse to Look";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Press SPACE to Jump";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Hold SHIFT to Sprint (Watch Stamina)";
        yield return new WaitForSeconds(4);

        tutorialText.text = "Blue Potion = Full Stamina";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Vial = Half Stamina";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Speed Boost = Infinite Stamina!";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Shield = One Free Hit";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Avoid Bombs and Spikes!";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Avoid the Ghost!";
        yield return new WaitForSeconds(3);

        tutorialText.text = "Collect 3 Coins to Unlock Exit";
        yield return new WaitForSeconds(4);
        
        tutorialText.text = "Press ESC to Pause";
        yield return new WaitForSeconds(3);

        tutorialText.text = "";

        // Save that tutorial is done
        PlayerPrefs.SetInt("TutorialDone", 1);
        PlayerPrefs.Save();

        tutorialFinished = true;
    }
}