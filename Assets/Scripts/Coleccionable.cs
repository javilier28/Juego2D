using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int valor = 1;
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Jugador"))
        {
            GestorJuego.I.SumarPuntos(valor);
            Destroy(gameObject);
        }
    }
}
