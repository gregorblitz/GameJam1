using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Música")]
    public AudioClip musicaAmbiente;
    public AudioClip musicaGameOver;

    [Header("Sonidos del Jugador")]
    public AudioClip sonidoMotor;
    public AudioClip sonidoDisparoNormal;
    public AudioClip sonidoDisparoMetralleta;

    [Header("Sonidos de PowerUps")]
    public AudioClip sonidoAgarrarVida;
    public AudioClip sonidoAgarrarCombustible;
    public AudioClip sonidoAgarrarMunicion;

    [Header("Sonidos de Enemigos")]
    public AudioClip sonidoDestruccionEnemigo;

    // Sources
    private AudioSource musicaSource;   // Para música (loop)
    private AudioSource motorSource;    // Para motor (loop continuo)
    private AudioSource sfxSource;      // Para efectos de sonido (one-shot)

    void Awake()
    {
        // Singleton: solo existe un AudioManager en toda la escena
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Crear los 3 AudioSources
        musicaSource = gameObject.AddComponent<AudioSource>();
        motorSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Configurar música ambiente
        musicaSource.clip = musicaAmbiente;
        musicaSource.loop = true;
        musicaSource.volume = 0.5f;
        musicaSource.playOnAwake = false;

        // Configurar motor (loop)
        motorSource.clip = sonidoMotor;
        motorSource.loop = true;
        motorSource.volume = 0.6f;
        motorSource.playOnAwake = false;

        // Configurar SFX (efectos puntuales)
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
        musicaSource.Play();
    }

    public void PlayMusicaGameOver()
    {
        if (musicaGameOver == null) return;
        musicaSource.Stop();
        motorSource.Stop();
        musicaSource.clip = musicaGameOver;
        musicaSource.loop = false;
        musicaSource.Play();
    }

    // ─── MOTOR ─────────────────────────────────────────────

    public void PlayMotor()
    {
        if (sonidoMotor == null) return;
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
        PlaySFX(sonidoDisparoNormal);
    }

    public void PlayDisparoMetralleta()
    {
        PlaySFX(sonidoDisparoMetralleta);
    }

    // ─── POWERUPS ──────────────────────────────────────────

    public void PlayAgarrarVida()
    {
        PlaySFX(sonidoAgarrarVida);
    }

    public void PlayAgarrarCombustible()
    {
        PlaySFX(sonidoAgarrarCombustible);
    }

    public void PlayAgarrarMunicion()
    {
        PlaySFX(sonidoAgarrarMunicion);
    }

    // ─── ENEMIGOS ──────────────────────────────────────────

    public void PlayDestruccionEnemigo()
    {
        PlaySFX(sonidoDestruccionEnemigo);
    }

    // ─── HELPER PRIVADO ────────────────────────────────────

    private void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }
}