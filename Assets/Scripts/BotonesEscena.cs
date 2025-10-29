using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesEscena : MonoBehaviour
{
    public void IrA(string nombreEscena) => SceneManager.LoadScene(nombreEscena);
}
