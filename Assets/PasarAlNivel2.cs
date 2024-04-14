using UnityEngine;

public class PasarAlNivel2 : MonoBehaviour
{
    public Transform checkpoint2;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PasarAlNivel();
        }
    }

    void PasarAlNivel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && checkpoint2 != null)
        {
            player.transform.position = checkpoint2.position;
        }
        else
        {
            Debug.LogError("Player o checkpoint2 no encontrados.");
        }
    }
}
