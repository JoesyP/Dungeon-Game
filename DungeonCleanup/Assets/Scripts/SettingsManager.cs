using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsMenu;
    private bool waitingForKey = false;
    private string currentKey = "";

    void Update()
    {
        if (waitingForKey)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        if (currentKey == "Sprint")
                            Keybinds.sprintKey = key;

                        if (currentKey == "Jump")
                            Keybinds.jumpKey = key;

                        waitingForKey = false;
                        settingsMenu.SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void ChangeSprintKey()
    {
        waitingForKey = true;
        currentKey = "Sprint";
    }

    public void ChangeJumpKey()
    {
        waitingForKey = true;
        currentKey = "Jump";
    }
}