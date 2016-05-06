using UnityEngine;
using System.Collections;

public class SpawnRandomizer : MonoBehaviour {
    public GameObject[] spawnPoint;
    public float timer = 3.0f;

    private float clock;

	// Use this for initialization
	void Start () {
        clock = timer;
	}
	
	// Update is called once per frame
	void Update () {
        clock -= Time.deltaTime;

        if (clock < 0.0f)
        {
            float randNum = Random.Range(0.0f, 100.0f);
            
            if (randNum <= 33.33f)
            {
                spawnPoint[0].SetActive(true);
                spawnPoint[1].SetActive(false);
                spawnPoint[2].SetActive(false);
            }
            if (randNum > 33.33f && randNum <= 66.67f)
            {
                spawnPoint[0].SetActive(false);
                spawnPoint[1].SetActive(true);
                spawnPoint[2].SetActive(false);
            }
            if (randNum > 66.67f && randNum <= 100.0f)
            {
                spawnPoint[0].SetActive(false);
                spawnPoint[1].SetActive(false);
                spawnPoint[2].SetActive(true);
            }

            clock = timer;
        }
    }
}
