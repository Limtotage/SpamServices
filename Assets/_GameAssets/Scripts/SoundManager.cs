using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClip meowSound;
    [SerializeField] private AudioClip PCON;
    [SerializeField] private AudioClip Click;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioSource sfwSource;
    [SerializeField] private AudioSource musicSource;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic()
    {
        musicSource.Play();
    }
    public void PlayMeow()
    {
        sfwSource.PlayOneShot(meowSound);
    }
    public void PlayPCON()
    {
        sfwSource.PlayOneShot(PCON);
    }
    public void PlayClick()
    {
        sfwSource.PlayOneShot(Click);
    }
    public void PlayGameOver()
    {
        sfwSource.PlayOneShot(gameOver);
    }

}
