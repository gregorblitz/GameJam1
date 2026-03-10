using UnityEngine;

public class HDRIDayNight : MonoBehaviour
{
    [Header("Velocidad del Ciclo")]
    public float duracionDiaSegundos = 90f;

    [Header("Configuración de Luz")]
    public float intensidadMaxima = 1.2f;
    public float intensidadMinima = 0f;

    private Light sol;
    private float tiempoActual = 0.25f;
    private Material skyboxMat;

    void Start()
    {
        sol = GetComponent<Light>();
        skyboxMat = RenderSettings.skybox;
    }

    void Update()
    {
        // Avanzar tiempo del día
        tiempoActual += Time.deltaTime / duracionDiaSegundos;
        if (tiempoActual >= 1f) tiempoActual = 0f;

        // Rotar el sol (esto mueve el sol visible en el Procedural skybox)
        float angulo = tiempoActual * 360f - 90f;
        transform.rotation = Quaternion.Euler(angulo, 170f, 0f);

        // Calcular intensidad (0=noche, 1=mediodía)
        float intensidad = Mathf.Sin(tiempoActual * Mathf.PI);
        intensidad = Mathf.Clamp01(intensidad);

        // Cambiar intensidad de la luz
        sol.intensity = Mathf.Lerp(intensidadMinima, intensidadMaxima, intensidad);

        // Cambiar color de la luz
        sol.color = Color.Lerp(
            new Color(1f, 0.4f, 0.1f),  // Naranja amanecer/atardecer
            new Color(1f, 1f, 0.9f),     // Blanco mediodía
            intensidad
        );

        // Ajustar el Procedural Skybox
        if (skyboxMat != null)
        {
            // Exposición (brillo del cielo)
            skyboxMat.SetFloat("_Exposure",
                Mathf.Lerp(0.05f, 1.3f, intensidad));

            // Color del cielo
            skyboxMat.SetColor("_SkyTint", Color.Lerp(
                new Color(0.02f, 0.02f, 0.08f),  // Azul muy oscuro (noche)
                new Color(0.5f, 0.7f, 1f),        // Azul cielo (día)
                intensidad
            ));

            // Atmósfera
            skyboxMat.SetFloat("_AtmosphereThickness",
                Mathf.Lerp(0.2f, 1f, intensidad));
        }

        // Oscurecer ambiente en la noche
        RenderSettings.ambientIntensity = Mathf.Lerp(0.05f, 1f, intensidad);
    }
}