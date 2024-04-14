using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMen;
    public GameObject Opciones;
    
    
    void Start()
    {
        MainMen.SetActive(true);
        Opciones.SetActive(false);
    }

    public void salir()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    public void abrirOpciones()
    {
        MainMen.SetActive(false );
        Opciones.SetActive(true );
    }
    public void jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void cerrarOpciones()
    {
        Opciones.SetActive(false);
        MainMen.SetActive(true);
        
    }
}
