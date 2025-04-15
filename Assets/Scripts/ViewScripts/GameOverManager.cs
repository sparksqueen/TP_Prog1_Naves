using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.instance.skipTitleScreen = true;
        SceneManager.LoadScene("SampleScene");

        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
