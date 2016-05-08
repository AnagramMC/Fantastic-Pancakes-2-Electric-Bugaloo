using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

    public Canvas PauseScreen;
    public GameObject SuperButton;
    public GameObject ComboImage;
    public GameObject ComboText;

    public float time = 10;

    GameObject ScoreText;
    GameObject TimeText;

    GameObject ScoreRef;


	// Use this for initialization
	void Start () {
        
        PauseScreen.enabled = false;
        SuperButton.SetActive(false);

        ScoreText = GameObject.Find("ScoreText");
        TimeText = GameObject.Find("TimeText");
        ScoreRef = GameObject.Find("MasterSystem");
	}
	
	// Update is called once per frame
	void Update () {

        
            ScoreText.GetComponent<Text>().text = "Score: " + ScoreRef.GetComponent<GameManager>().score;

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

    public void Menu()
    {

    }

    public void Restart()
    {

    }
}
