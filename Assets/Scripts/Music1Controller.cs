using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music1Controller : MonoBehaviour
{
    private AudioSource audioSource;
    public static Music1Controller instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }
    
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }
}
