using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;

    private int vidas = 3;
    private Vector3 respawnPosition;

    void Start()
    {
        corazon1.SetActive(true);
        corazon2.SetActive(true);
        corazon3.SetActive(true);

        respawnPosition = GameObject.Find("respawn").transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            vidas--;

            if (vidas == 2)
            {
                corazon3.SetActive(false);
                Respawn();
            }
            else if (vidas == 1)
            {
                corazon2.SetActive(false);
                Respawn();
            }
            else if (vidas == 0)
            {
                corazon1.SetActive(false);
                GameOver();
            }
        }
    }

    private void Respawn()
    {
        transform.position = respawnPosition;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
