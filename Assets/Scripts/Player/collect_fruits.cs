using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class collect_fruits : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    private int totalFrutas = 4;
    private open_door doorController;
    private bool canCollect = true;

    public AudioSource collectSound;


    private void Start()
    {
        scoreText.text = score + "/" + totalFrutas + " FRUTAS";
        doorController = FindObjectOfType<open_door>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruta") && canCollect)
        {
            collectSound.Play();    
            StartCoroutine(CollectDelay());
            Destroy(other.gameObject);
            score++;
            UpdateScoreText();
        }
    }

    private IEnumerator CollectDelay()
    {
        canCollect = false;
        yield return new WaitForSeconds(0.2f);
        canCollect = true;
    }

    private void UpdateScoreText()
    {
        scoreText.text = score + "/" + totalFrutas + " FRUTAS";
        if (score == totalFrutas && doorController != null)
        {
            doorController.OpenDoor();
        }
    }
}
