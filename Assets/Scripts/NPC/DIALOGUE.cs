using System.Collections;
using UnityEngine;

public class DIALOGUE : MonoBehaviour
{
    public GameObject teclaE;
    public GameObject dialogo;

    private bool cercaDelNPC = false;

    void Start()
    {
        teclaE.SetActive(false);
        dialogo.SetActive(false);
    }

    void Update()
    {
        if (cercaDelNPC && Input.GetKeyDown(KeyCode.E))
        {
            teclaE.SetActive(false);
            dialogo.SetActive(true);
            StartCoroutine(DesactivarDialogoDespuesDeTiempo());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelNPC = true;
            teclaE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelNPC = false;
            teclaE.SetActive(false);
        }
    }

    IEnumerator DesactivarDialogoDespuesDeTiempo()
    {
        yield return new WaitForSeconds(5f);
        dialogo.SetActive(false);
        teclaE.SetActive(true);
    }
}
