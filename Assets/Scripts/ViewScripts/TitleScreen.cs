using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject titlePanel;
    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.skipTitleScreen)
        {
            titlePanel.SetActive(false);
            GameManager.instance.StartGame();
        }
    }
    public void StartGame()
    {
        titlePanel.SetActive(false);
        GameManager.instance.StartGame();
    }
}
