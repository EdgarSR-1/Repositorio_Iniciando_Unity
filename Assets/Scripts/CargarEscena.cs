using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class CargarEscena : MonoBehaviour
{
    [SerializeField] private TMP_Text textoCarga;

    public int tiempo = 5;

    private bool escenaLista = false;

    private void Start()
    {
        StartCoroutine(ContadorCarga());
    }

    private IEnumerator ContadorCarga()
    {
        for (int contador = 0; contador <= tiempo; contador++)
        {
            textoCarga.text = "Cargando escena " + contador + "/" + tiempo;

            yield return new WaitForSeconds(1f);
        }

        textoCarga.text = "Escena cargada, presiona Espacio para continuar";
        escenaLista = true;
    }

    private void Update()
    {
        if (escenaLista && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}