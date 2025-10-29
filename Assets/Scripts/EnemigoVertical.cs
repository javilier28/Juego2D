using UnityEngine;

public class EnemigoVertical : MonoBehaviour
{
    public float amplitud = 0.01f;
    public float velocidad = 1.5f;
    Vector3 origen;

    void Start(){ origen = transform.position; }

    void Update(){
        transform.position = origen + Vector3.up * Mathf.Sin(Time.time * velocidad) * amplitud;
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Jugador")) GestorJuego.I.ReiniciarNivel();
    }
}

