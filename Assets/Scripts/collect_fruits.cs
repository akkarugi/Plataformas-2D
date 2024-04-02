using UnityEngine;
using UnityEngine.UI;

public class collect_fruits : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    private int totalFrutas = 4;

   

    open_door doorController;

    private void Start()
    {
        scoreText.text = score + "/" + totalFrutas + " FRUTAS";
        doorController = FindObjectOfType<open_door>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruta"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreText();
        }

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
