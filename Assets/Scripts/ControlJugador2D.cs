using UnityEngine;

public class ControlJugador2D : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 12f;

    [Header("Suelo")]
    public Transform comprobadorSuelo;
    public float radioSuelo = 0.15f;
    public LayerMask capaSuelo;

    Rigidbody2D rb;
    bool enSuelo;
    float inputX;

    void Awake(){ rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (inputX != 0)
        {
            var s = transform.localScale;
            s.x = Mathf.Sign(inputX) * Mathf.Abs(s.x);
            transform.localScale = s;
        }

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        if (comprobadorSuelo)
            enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, radioSuelo, capaSuelo);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputX * velocidad, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (!comprobadorSuelo) return;
        Gizmos.DrawWireSphere(comprobadorSuelo.position, radioSuelo);
    }
}
