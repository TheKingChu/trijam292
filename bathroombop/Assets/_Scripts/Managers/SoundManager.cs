using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip backgroundMusic;
    public AudioClip[] sfx;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < sfx.Length)
        {
            AudioSource.PlayClipAtPoint(sfx[index], Camera.main.transform.position);
        }
    }

    public void LowerMusic()
    {
        audioSource.volume = 0.1f;
    }
}
