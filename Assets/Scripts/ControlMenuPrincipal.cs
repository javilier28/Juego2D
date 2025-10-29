using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuPrincipal : MonoBehaviour
{
    public void Jugar(){ GestorJuego.I.ReiniciarPuntuacion(); SceneManager.LoadScene("Nivel"); }
    public void Creditos(){ SceneManager.LoadScene("Creditos"); }
    public void Salir(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
