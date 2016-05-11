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
        Debug.Log("score " + score);

        if(timeExtenderScore >= 50)
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

        if (hitStreak < 10)
        {
            multiplyer = 1;
        }
        else if (hitStreak < 20)
        {
            multiplyer = 2;
        }
        else if (hitStreak < 30)
        {
            multiplyer = 4;
        }
        else if (hitStreak < 40)
        {
            multiplyer = 6;
        }
        else if (hitStreak < 50)
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
        timeExtenderScore += points;
    }
}
