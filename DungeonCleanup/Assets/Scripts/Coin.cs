using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play(AudioManager.instance.coin);
            GameManager.instance.CollectCoin();
            Destroy(gameObject);
        }
    }
}