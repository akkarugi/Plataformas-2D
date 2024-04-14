using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicFinalBoss : MonoBehaviour
{
    public AudioSource music;
    public AudioSource backgroundMusic;
    private bool isPlaying = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPlaying)
        {
            music.Play();
            isPlaying = true;

            if (backgroundMusic.isPlaying)
            {
                backgroundMusic.Pause();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isPlaying)
        {
            music.Stop();
            isPlaying = false;

            if (!backgroundMusic.isPlaying)
            {
                backgroundMusic.UnPause();
            }
        }
    }
}
