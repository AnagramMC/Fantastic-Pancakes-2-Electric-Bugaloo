using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int score = 0;

    public float time = 0;

    public int hitStreak = 0;
    public int multiplyer = 0;

    private float timeExtenderScore = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("score " + timeExtenderScore);

        if(timeExtenderScore >= 100)
        {
            time += 30;
            timeExtenderScore = 0;
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
            GetComponent<HUDManager>().Fade(false);
        }

        if (hitStreak < 5)
        {
            multiplyer = 1;
        }
        else if (hitStreak < 10)
        {
            multiplyer = 2;
        }
        else if (hitStreak < 15)
        {
            multiplyer = 4;
        }
        else if (hitStreak < 25)
        {
            multiplyer = 6;
        }
        else if (hitStreak < 40)
        {
            multiplyer = 8;
        }
        else
        {
            multiplyer = 10;
        }
    }

    public void AddScore(int points)
    {
        score += (points * multiplyer);
        timeExtenderScore += (points * multiplyer);
    }
}
