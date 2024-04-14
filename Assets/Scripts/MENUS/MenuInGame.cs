using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject contadores;
    public GameObject opciones;

    
    void Start()
    {
        contadores.SetActive(true);
        menu.SetActive(false);
        opciones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            contadores.SetActive(false );
            menu.SetActive(true );
        }

    }

    public void BotonReanudar ()
    {
        Time.timeScale = 1f;
        contadores.SetActive(true);
        menu.SetActive(false);
    }

    public void BotonOpciones()
    {
        
        menu.SetActive(false);
        opciones.SetActive(true);
    }
    public void BotonSalir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }

    public void BotonVolver()
    {

        menu.SetActive(true);
        opciones.SetActive(false);
    }

}
