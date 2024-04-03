using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Has_Key : MonoBehaviour
{
    public Text scoreText2;
    public int score2 = 0;
    private int totalKey = 1;

    open_door doorController;

    private void Start()
    {
        scoreText2.text = score2 + "/" + totalKey + " LLAVE";
        doorController = FindObjectOfType<open_door>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Llave"))
        {
            Destroy(other.gameObject);
            score2++;
            UpdateScoreText2();
        }

    }
    private void UpdateScoreText2()
    {
        scoreText2.text = score2 + "/" + totalKey + " FRUTAS";
        if (score2 == totalKey && doorController != null)
        {
            doorController.OpenDoor();
        }
    }

}
