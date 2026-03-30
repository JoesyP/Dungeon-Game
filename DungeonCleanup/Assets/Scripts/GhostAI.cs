using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public Transform player;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!TutorialManager.tutorialFinished)
        {
            agent.isStopped = true;
            return;
        }

        agent.isStopped = false;

        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController p = other.GetComponent<PlayerController>();

            if (p.hasShield)
            {
                AudioManager.instance.Play(AudioManager.instance.ghostHit);
                p.hasShield = false;
            }
            else
            {
                AudioManager.instance.Play(AudioManager.instance.ghostHit);
                GameManager.instance.RestartLevel();
            }
        }
    }
}