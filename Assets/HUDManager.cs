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
    public GameObject MultiplyerText;

    public Slider HealthBar;
    public GameObject HealthRef;

    public Image FadeImage;

    public float fadeSpeed = 1.5f;

    private bool fadeOut = false;
    private bool death = false;
    private bool timeUp = false;

    private GameObject ScoreText;
    private GameObject TimeText;
    private string minutes;
    private string seconds;

    


	// Use this for initialization
	void Start () {
        
        PauseScreen.enabled = false;
        DeathScreen.enabled = false;
        TimeUpScreen.enabled = false;
        FadeImage.enabled = false;

        ComboImage.SetActive(false);
        ComboText.SetActive(false);
        MultiplyerText.SetActive(false);

        ScoreText = GameObject.Find("ScoreText");
        TimeText = GameObject.Find("TimeText");
	}
	
	// Update is called once per frame
	void Update () {

        
            ScoreText.GetComponent<Text>().text = GetComponent<GameManager>().score.ToString();

            
                
                 minutes = ((int)GetComponent<GameManager>().time / 60).ToString();
                 seconds = ((int)GetComponent<GameManager>().time % 60).ToString();
                 TimeText.GetComponent<Text>().text = minutes + ":" + seconds;
           

        HealthBar.value = HealthRef.GetComponent<PlayerCollision>().health;

        if(HealthBar.value <= 0)
        {
            Fade(true);
        }

        if(GetComponent<GameManager>().hitStreak > 0)
        {
            ComboImage.SetActive(true);
            ComboText.SetActive(true);
            MultiplyerText.SetActive(true);
            ComboText.GetComponent<Text>().text = GetComponent<GameManager>().hitStreak.ToString();
            MultiplyerText.GetComponent<Text>().text = "X" + GetComponent<GameManager>().multiplyer.ToString();
        }
        else
        {
            ComboImage.SetActive(false);
            ComboText.SetActive(false);
            MultiplyerText.SetActive(false);
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
