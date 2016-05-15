using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

    public Canvas PauseScreen;
    public Canvas DeathScreen;
    public Canvas TimeUpScreen;
    public GameObject ComboImage;
    public GameObject ComboImage2;
    public GameObject ComboText;
    public GameObject MultiplyerText;

    public Slider HealthBar;
    public GameObject HealthRef;

    public Image FadeImage;

    public float fadeSpeed = 1.5f;

    private bool fadeOut = false;
    private bool death = false;
    private bool timeUp = false;
    private bool isPaused = false;

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
        ComboImage2.SetActive(false);
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
            ComboImage2.SetActive(true);
            ComboText.SetActive(true);
            MultiplyerText.SetActive(true);
            ComboText.GetComponent<Text>().text = GetComponent<GameManager>().hitStreak.ToString();
            MultiplyerText.GetComponent<Text>().text = "X" + GetComponent<GameManager>().multiplyer.ToString();
        }
        else
        {
            ComboImage.SetActive(false);
            ComboImage2.SetActive(false);
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
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        
	}


    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            PauseScreen.enabled = true;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            PauseScreen.enabled = false;
            isPaused = false;
        }
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(1);
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
