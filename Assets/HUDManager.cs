using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

    public Canvas PauseScreen;
    public Canvas DeathScreen;
    public Canvas TimeUpScreen;
    public GameObject ComboImage;
    public GameObject ComboText;

    public Slider HealthBar;
    public GameObject HealthRef;

    public Image FadeImage;

    public float time = 10;
    public float fadeSpeed = 1.5f;

    private bool fadeOut = false;
    private bool death = false;
    private bool timeUp = false;

    private GameObject ScoreText;
    private GameObject TimeText;

    private GameObject ScoreRef;


	// Use this for initialization
	void Start () {
        
        PauseScreen.enabled = false;
        DeathScreen.enabled = false;
        TimeUpScreen.enabled = false;
        FadeImage.enabled = false;

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
                TimeText.GetComponent<Text>().text = "0:0";
                Fade(false);
            }

        HealthBar.value = HealthRef.GetComponent<PlayerCollision>().health;

        if(HealthBar.value <= 0)
        {
            Fade(true);
        }
        
        if(fadeOut)
        {
            if(FadeImage.color != Color.black)
            {
                FadeImage.color = Color.Lerp(FadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
            }
            else
            {
                Time.timeScale = 0;
                if (death)
                {
                    DeathScreen.enabled = true;
                }
                else if (timeUp)
                {
                    TimeUpScreen.enabled = true;
                }
            }
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
        Debug.Log("Menu");
    }

    public void Restart()
    {
        Debug.Log("Restart");
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Fade(bool dead)
    {
        if (dead)
        {
            death = true;
        }
        else
        {
            timeUp = true;
        }
        
        FadeImage.enabled = true;
        fadeOut = true;
    }

    
}
