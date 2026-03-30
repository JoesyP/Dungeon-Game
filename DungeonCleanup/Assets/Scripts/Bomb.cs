using UnityEngine;
public class Bomb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController p = other.GetComponent<PlayerController>();

            if (p.hasShield)
            {
                AudioManager.instance.Play(AudioManager.instance.trap);
                p.hasShield = false;
            }
            else
            {
                AudioManager.instance.Play(AudioManager.instance.trap);
                GameManager.instance.RestartLevel();
            }
        }
    }
}