using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        // Carrega a primeira cena 
        SceneManager.LoadScene("telaPrincipal");
    }
}
