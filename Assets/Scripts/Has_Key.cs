using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Has_Key : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    private int totalLlaves = 1;
    bool hasKey= false;

    open_door2 doorController;
    void Start()
    {
        scoreText.text = score + "/" + totalLlaves + " LLAVE";
        doorController = FindObjectOfType<open_door2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            bool hasKey = true;
            Destroy(other.gameObject);
            score++;
            UpdateScoreText();
            doorController.OpenDoor();
        }

    }
    private void UpdateScoreText()
    {
        scoreText.text = score + "/" + totalLlaves + " LLAVE";
 
    }

  
}
