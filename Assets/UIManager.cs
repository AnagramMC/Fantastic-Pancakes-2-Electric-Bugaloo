using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas PauseScreen;

     GameObject ScoreText;
     GameObject TimeText;
     


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        PauseScreen.enabled = false;

        ScoreText = GameObject.Find("ScoreText");
        TimeText = GameObject.Find("TimeText");
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.GetComponent<Text>().text = "Hello";
        TimeText.GetComponent<Text>().text = "Goodbye";
	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseScreen.enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseScreen.enabled = false;
    }
}
