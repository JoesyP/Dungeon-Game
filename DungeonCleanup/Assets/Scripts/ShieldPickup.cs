using UnityEngine;
public class ShieldPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play(AudioManager.instance.shield);
            PlayerController p = other.GetComponent<PlayerController>();
            p.hasShield = true;
            Destroy(gameObject);
        }
    }
}