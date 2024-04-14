using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Has_Key : MonoBehaviour
{
    public Text scoreText2;
    public int score2 = 0;
    private int totalKey = 1;
    private open_door2 doorController;
    private bool canCollect = true;
    public AudioSource collectSound;

    private void Start()
    {
        scoreText2.text = score2 + "/" + totalKey + " LLAVE";
        doorController = FindObjectOfType<open_door2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave") && canCollect)
        {
            collectSound.Play();
            StartCoroutine(CollectDelay());
            Destroy(other.gameObject);
            score2++;
            UpdateScoreText2();
        }
    }

    private IEnumerator CollectDelay()
    {
        canCollect = false;
        yield return new WaitForSeconds(1f);
        canCollect = true;
    }

    private void UpdateScoreText2()
    {
        scoreText2.text = score2 + "/" + totalKey + " LLAVE";
        if (score2 == totalKey && doorController != null)
        {
            doorController.OpenDoor();
        }
    }
}
