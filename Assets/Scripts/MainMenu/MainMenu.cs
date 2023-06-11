using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.LoadScenes("MainDemoScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
