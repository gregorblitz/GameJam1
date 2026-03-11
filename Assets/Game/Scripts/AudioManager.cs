using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Música")]
    public AudioClip musicaAmbiente;
    public AudioClip musicaGameOver;
    [Range(0f, 1f)] public float volumenMusicaAmbiente = 0.5f;
    [Range(0f, 1f)] public float volumenMusicaGameOver = 0.8f;

    [Header("Sonidos del Jugador")]
    public AudioClip sonidoMotor;
    public AudioClip sonidoDisparoNormal;
    public AudioClip sonidoDisparoMetralleta;
    [Range(0f, 1f)] public float volumenMotor = 0.6f;
    [Range(0f, 1f)] public float volumenDisparoNormal = 0.7f;
    [Range(0f, 1f)] public float volumenDisparoMetralleta = 0.7f;

    [Header("Sonidos de PowerUps")]
    public AudioClip sonidoAgarrarVida;
    public AudioClip sonidoAgarrarCombustible;
    public AudioClip sonidoAgarrarMunicion;
    [Range(0f, 1f)] public float volumenAgarrarVida = 1f;
    [Range(0f, 1f)] public float volumenAgarrarCombustible = 1f;
    [Range(0f, 1f)] public float volumenAgarrarMunicion = 1f;

    [Header("Sonidos de Enemigos")]
    public AudioClip sonidoDestruccionEnemigo;
    [Range(0f, 1f)] public float volumenDestruccionEnemigo = 1f;

    // Sources
    private AudioSource musicaSource;
    private AudioSource motorSource;
    private AudioSource sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        musicaSource = gameObject.AddComponent<AudioSource>();
        motorSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        musicaSource.loop = true;
        musicaSource.playOnAwake = false;

        motorSource.clip = sonidoMotor;
        motorSource.loop = true;
        motorSource.volume = volumenMotor;
        motorSource.playOnAwake = false;

        sfxSource.loop = false;
        sfxSource.playOnAwake = false;
    }

    void Start()
    {
        PlayMusicaAmbiente();
        PlayMotor();
    }

    // ─── MÚSICA ────────────────────────────────────────────

    public void PlayMusicaAmbiente()
    {
        if (musicaAmbiente == null) return;
        musicaSource.clip = musicaAmbiente;
        musicaSource.volume = volumenMusicaAmbiente;
        musicaSource.loop = true;
        musicaSource.Play();
    }

    public void PlayMusicaGameOver()
    {
        if (musicaGameOver == null) return;
        musicaSource.Stop();
        motorSource.Stop();
        musicaSource.clip = musicaGameOver;
        musicaSource.volume = volumenMusicaGameOver;
        musicaSource.loop = false;
        musicaSource.Play();
    }

    // ─── MOTOR ─────────────────────────────────────────────

    public void PlayMotor()
    {
        if (sonidoMotor == null) return;
        motorSource.volume = volumenMotor;
        if (!motorSource.isPlaying)
            motorSource.Play();
    }

    public void StopMotor()
    {
        motorSource.Stop();
    }

    // ─── DISPAROS ──────────────────────────────────────────

    public void PlayDisparoNormal()
    {
        PlaySFX(sonidoDisparoNormal, volumenDisparoNormal);
    }

    public void PlayDisparoMetralleta()
    {
        PlaySFX(sonidoDisparoMetralleta, volumenDisparoMetralleta);
    }

    // ─── POWERUPS ──────────────────────────────────────────

    public void PlayAgarrarVida()
    {
        PlaySFX(sonidoAgarrarVida, volumenAgarrarVida);
    }

    public void PlayAgarrarCombustible()
    {
        PlaySFX(sonidoAgarrarCombustible, volumenAgarrarCombustible);
    }

    public void PlayAgarrarMunicion()
    {
        PlaySFX(sonidoAgarrarMunicion, volumenAgarrarMunicion);
    }

    // ─── ENEMIGOS ──────────────────────────────────────────

    public void PlayDestruccionEnemigo()
    {
        PlaySFX(sonidoDestruccionEnemigo, volumenDestruccionEnemigo);
    }

    // ─── HELPER PRIVADO ────────────────────────────────────

    private void PlaySFX(AudioClip clip, float volumen)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, volumen);
    }
}