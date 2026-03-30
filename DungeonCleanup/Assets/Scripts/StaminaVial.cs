using UnityEngine;

public class StaminaVial : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play(AudioManager.instance.potion);
            PlayerController p = other.GetComponent<PlayerController>();
            p.stamina += p.maxStamina * 0.5f;
            Destroy(gameObject);
        }
    }
}