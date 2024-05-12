using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOver() 
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("_MainMenu");
    }
}
