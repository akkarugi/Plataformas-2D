using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
