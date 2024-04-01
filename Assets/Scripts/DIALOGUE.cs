using System.Collections;
using UnityEngine;

public class DIALOGUE : MonoBehaviour
{
    public GameObject teclaE;
    public GameObject dialogo;

    void Start()
    {
        teclaE.SetActive(true);
        dialogo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            teclaE.SetActive(false);
            dialogo.SetActive(true);
            StartCoroutine(DesactivarDialogoDespuesDeTiempo());
        }
    }

    IEnumerator DesactivarDialogoDespuesDeTiempo()
    {
        yield return new WaitForSeconds(5f);
        dialogo.SetActive(false);
        teclaE.SetActive(true);
    }
}
