using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorColisiones : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Peligro"))
        {
            if (GestorJuego.I != null) GestorJuego.I.ReiniciarNivel();
            else SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Peligro"))
        {
            if (GestorJuego.I != null) GestorJuego.I.ReiniciarNivel();
            else SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
