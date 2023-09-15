using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadNextScene : MonoBehaviour
{
     

    private void Start()
    {
        
    }

    private void LoadScene()
    {
        
    }


     public void PlayGame()
     {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
     

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }

     public void ReturnToMenuFromControls()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    public void MenuToControls()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +3);
    }
    
    public void ReturnToMenuFromWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    } 
    
    public void QuitGame()
    {
        
        Application.Quit();
        print("Quit");
    }


}
