using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public AudioSource enemysound;

    public Transform checkpoint1;
    public Transform checkpoint2;

    public TextMeshProUGUI checkpointMessage1; // Primer mensaje de checkpoint
    public TextMeshProUGUI checkpointMessage2; // Segundo mensaje de checkpoint

    private int vidas = 3;
    private Vector3 respawnPosition;
    private bool passedCheckpoint2 = false;

    void Start()
    {
        corazon1.SetActive(true);
        corazon2.SetActive(true);
        corazon3.SetActive(true);

        respawnPosition = checkpoint1.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint1"))
        {
            ShowCheckpointMessage(checkpointMessage1, "CHECKPOINT");
            passedCheckpoint2 = false;
        }
        else if (collision.gameObject.CompareTag("Checkpoint2"))
        {
            ShowCheckpointMessage(checkpointMessage2, "CHECKPOINT");
            passedCheckpoint2 = true;
        }
    }

    private void ShowCheckpointMessage(TextMeshProUGUI checkpointMessage, string message)
    {
        checkpointMessage.text = message;
        StartCoroutine(HideMessageAfterDelay(checkpointMessage, 2f));
    }

    private IEnumerator HideMessageAfterDelay(TextMeshProUGUI checkpointMessage, float delay)
    {
        yield return new WaitForSeconds(delay);
        checkpointMessage.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || (collision.gameObject.CompareTag("FinalBoss")))
        {
            enemysound.Play();

            vidas--;

            if (vidas > 0)
            {
                UpdateHearts();
                Respawn();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void Respawn()
    {
        if (passedCheckpoint2)
        {
            transform.position = checkpoint2.position;
        }
        else
        {
            transform.position = checkpoint1.position;
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void UpdateHearts()
    {
        if (vidas == 2)
        {
            corazon3.SetActive(false);
        }
        else if (vidas == 1)
        {
            corazon2.SetActive(false);
        }
        else if (vidas == 0)
        {
            corazon1.SetActive(false);
        }
    }
}
