using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public void GameOver() 
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("_MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
