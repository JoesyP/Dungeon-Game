using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform targetPosition;
    public float moveSpeed = 1.5f;

    public TextMeshProUGUI text;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        cameraTransform.position = Vector3.Lerp(
            cameraTransform.position,
            targetPosition.position,
            moveSpeed * Time.deltaTime
        );

        if (timer > 2f)
        {
            text.text = "You Escaped The Dungeon...";
        }

        if (timer > 6f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}