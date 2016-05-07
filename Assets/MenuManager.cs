using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Canvas creditsPage;

    void Start()
    { 
        creditsPage.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("StartGame");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }

    public void CreditsOn()
    {
        if (creditsPage)
        {
            creditsPage.enabled = true;
        }
    }


    public void CreditsOff()
    {
        if (creditsPage)
        {
            creditsPage.enabled = false;
        }
    }

    
}
