using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GestorJuego : MonoBehaviour
{
    public static GestorJuego I { get; private set; }

    [Header("UI")]
    public TMP_Text textoPuntuacion;
    int puntuacion;

    [Header("Audio")]
    public AudioSource sfx;
    public AudioClip sonidoRecoger, sonidoGolpe, sonidoVictoria;

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += AlCargarEscena;
    }

    void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        if (textoPuntuacion == null)
        {
            var go = GameObject.FindWithTag("TextoPuntuacion");
            if (go) textoPuntuacion = go.GetComponent<TMP_Text>();
        }
        ActualizarUI();
    }

    public void SumarPuntos(int n)
    {
        puntuacion += n;
        if (sfx && sonidoRecoger) sfx.PlayOneShot(sonidoRecoger);
        ActualizarUI();
    }

    public void ReiniciarNivel()
    {
        puntuacion = 0;
        ActualizarUI();
        if (sfx && sonidoGolpe) sfx.PlayOneShot(sonidoGolpe);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Victoria()
    {
        if (sfx && sonidoVictoria) sfx.PlayOneShot(sonidoVictoria);
        SceneManager.LoadScene("Victoria");
    }

    public void ReiniciarPuntuacion()
    {
        puntuacion = 0;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoPuntuacion) textoPuntuacion.text = "Puntuacion: " + puntuacion;
    }
}
