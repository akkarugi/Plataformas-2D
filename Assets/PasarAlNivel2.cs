using UnityEngine;

public class PasarAlNivel2 : MonoBehaviour
{
    public Transform checkpoint2;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.transform.position = checkpoint2.position;
        }
        else
        {
            Debug.LogError("No se encontr� al jugador. Aseg�rate de que tenga la etiqueta 'Player'.");
        }
    }
}
