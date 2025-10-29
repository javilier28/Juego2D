using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour
{
    public Transform puntoA, puntoB;
    public float velocidad = 2f;
    Vector3 destino;

    void Start(){ destino = puntoB.position; }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position, destino) < 0.05f)
            destino = (destino == puntoB.position) ? puntoA.position : puntoB.position;
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Jugador")) GestorJuego.I.ReiniciarNivel();
    }
}
