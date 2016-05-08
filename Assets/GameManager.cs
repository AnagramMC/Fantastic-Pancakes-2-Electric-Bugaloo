using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int score = 0;

    public float time = 0;

    public int hitStreak = 0;

    private float timeExtenderScore = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("score " + score);

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
    }

    public void AddScore(int points)
    {
        if(hitStreak < 10)
        {
            score += points;
        }
        else if (hitStreak < 20)
        {
            score += (points * 2);
        }
        else if (hitStreak < 30)
        {
            score += (points * 4);
        }
        else if (hitStreak < 40)
        {
            score += (points * 6);
        }
        else if (hitStreak < 50)
        {
            score += (points * 8);
        }
        else
        {
            score += (points * 10);
        }
    }
}
