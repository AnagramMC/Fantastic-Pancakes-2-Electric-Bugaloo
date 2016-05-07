using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas PauseScreen;

    public float time = 10;

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


        if (time > 0)
        {
            time -= Time.deltaTime;
            string minutes = ((int)time / 60).ToString();
            string seconds = ((int)time % 60).ToString();
            TimeText.GetComponent<Text>().text = minutes + ":" + seconds;
        }
        else
        {
            TimeText.GetComponent<Text>().text = "Time: 0";
        }
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
