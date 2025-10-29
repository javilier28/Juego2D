using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 desplazamiento = new Vector3(0f, 1.5f, -10f);

    void LateUpdate()
    {
        if (!objetivo) return;
        transform.position = objetivo.position + desplazamiento;
    }
}
