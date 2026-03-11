using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PresentacionEquipo : MonoBehaviour
{
    [Header("Panel Bienvenida")]
    public GameObject panelBienvenida;
    public float tiempoBienvenida = 4f;

    [Header("Panel Tutorial")]
    public GameObject panelTutorial;
    public TextMeshProUGUI tituloTexto;
    public TextMeshProUGUI descripcionTexto;
    //public Image iconoImagen;
    public Image[] puntosindicadores;
    public CanvasGroup canvasGroupTutorial;

    [Header("Iconos por tarjeta")]
    public Sprite[] iconosPorTarjeta;

    [Header("Configuracion")]
    public float tiempoPorTarjeta = 5f;
    public float tiempoFade = 0.6f;

    private string[] titulos = {
        "Christian Nuñez",
        "Ricardo Patiño",
        "Santiago Cortazar",
        "Holmes Garces",
        
    };

    private string[] descripciones = {
        "Programmer, UI",
        "Gameplay Programmer, Tech Art",
        "Gameplay Programmer",
        "Gameplay Programmer"
    };

    private int tarjetaActual = 0;
    private bool tutorialActivo = true;

    void Start()
    {
        // Reset alpha del panel bienvenida por si quedó en 0
        CanvasGroup cgBienvenida = panelBienvenida.GetComponent<CanvasGroup>();
        if (cgBienvenida != null) cgBienvenida.alpha = 1f;

        panelTutorial.SetActive(false);
        StartCoroutine(FlujoBienvenidaYTutorial());
    }

    IEnumerator FlujoBienvenidaYTutorial()
    {
        panelBienvenida.SetActive(true);
        yield return new WaitForSeconds(tiempoBienvenida);
        yield return StartCoroutine(FadeOutObjeto(panelBienvenida));
        panelBienvenida.SetActive(false);
        yield return StartCoroutine(MostrarTutorial());
    }

    IEnumerator MostrarTutorial()
    {
        // Ocultar todos los puntos al inicio
        for (int i = 0; i < puntosindicadores.Length; i++)
            puntosindicadores[i].gameObject.SetActive(false);

        panelTutorial.SetActive(true);
        canvasGroupTutorial.alpha = 0;

        while (tarjetaActual < titulos.Length && tutorialActivo)
        {
            ActualizarTarjeta(tarjetaActual);
            yield return StartCoroutine(FadeIn(canvasGroupTutorial));
            yield return new WaitForSeconds(tiempoPorTarjeta);
            yield return StartCoroutine(FadeOut(canvasGroupTutorial));
            tarjetaActual++;
        }

        panelTutorial.SetActive(false);
    }

    void ActualizarTarjeta(int index)
    {
        tituloTexto.text = titulos[index];
        descripcionTexto.text = descripciones[index];

        // Cambiar ícono según la tarjeta
        /*if (iconosPorTarjeta != null && iconosPorTarjeta.Length > index && iconosPorTarjeta[index] != null)
            iconoImagen.sprite = iconosPorTarjeta[index];*/

        // Mostrar solo el punto activo, ocultar los demás
        for (int i = 0; i < puntosindicadores.Length; i++)
        {
            if (i == index)
            {
                puntosindicadores[i].gameObject.SetActive(true);
                puntosindicadores[i].transform.localScale = Vector3.one * 1.3f;
            }
            else
            {
                puntosindicadores[i].gameObject.SetActive(false);
            }
        }
    }

    public void SaltarTutorial()
    {
        tutorialActivo = false;
        StopAllCoroutines();
        panelBienvenida.SetActive(false);
        panelTutorial.SetActive(false);
    }

    IEnumerator FadeIn(CanvasGroup cg)
    {
        float t = 0;
        while (t < tiempoFade)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Clamp01(t / tiempoFade);
            yield return null;
        }
        cg.alpha = 1;
    }

    IEnumerator FadeOut(CanvasGroup cg)
    {
        float t = tiempoFade;
        while (t > 0)
        {
            t -= Time.deltaTime;
            cg.alpha = Mathf.Clamp01(t / tiempoFade);
            yield return null;
        }
        cg.alpha = 0;
    }

    IEnumerator FadeOutObjeto(GameObject obj)
    {
        CanvasGroup cg = obj.GetComponent<CanvasGroup>();
        if (cg == null) cg = obj.AddComponent<CanvasGroup>();
        cg.alpha = 1f;
        yield return StartCoroutine(FadeOut(cg));
    }
}