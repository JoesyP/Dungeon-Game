using UnityEngine;
public class SpeedBoost : MonoBehaviour
{
    public float duration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController p = other.GetComponent<PlayerController>();
            p.StartCoroutine(InfiniteStamina(p));
            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator InfiniteStamina(PlayerController p)
    {
        float originalDrain = p.staminaDrain;

        p.staminaDrain = 0;

        yield return new WaitForSeconds(duration);

        p.staminaDrain = originalDrain;
    }
}