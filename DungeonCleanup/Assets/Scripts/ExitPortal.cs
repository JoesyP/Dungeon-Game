using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    public string sceanToLoad;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play(AudioManager.instance.portal);
            SceneManager.LoadScene(sceanToLoad);
        }
    }
}