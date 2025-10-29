using UnityEngine;

public class Meta : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Jugador")) GestorJuego.I.Victoria();
    }
}
