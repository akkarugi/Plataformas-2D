using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Victory"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
