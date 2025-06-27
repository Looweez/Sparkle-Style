using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    public static BackgroundMusicPlayer instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
