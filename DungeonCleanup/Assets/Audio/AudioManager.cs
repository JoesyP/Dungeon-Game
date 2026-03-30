using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;

    public AudioClip coin;
    public AudioClip jump;
    public AudioClip ghostHit;
    public AudioClip portal;
    public AudioClip trap;
    public AudioClip shield;
    public AudioClip potion;

    void Awake()
    {
        instance = this;
        sfxSource = GetComponent<AudioSource>();

    }

    public void Play(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}