using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
         SceneManager.LoadScene("Level0");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif




    }

    public void ToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
   
}
