using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject rangedEnemy;
    public int spawnCount = 0;
    public int rangedSpawn = 0;

    private float timer = 0.0f;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer < 0.0f)
        {
            float randNum = Random.Range(0.0f, 100.0f);

            if (randNum > 25.0f)
            {
                if (spawnCount < 3)
                {
                    Instantiate(enemy, transform.position, transform.rotation);
                    spawnCount++;

                    Debug.Log(this.name + " " + this.spawnCount);
                }
            }

            if (randNum <= 25.0f)
            {
                if (rangedSpawn < 2)
                {
                    Instantiate(rangedEnemy, transform.position, transform.rotation);
                    rangedSpawn++;

                    Debug.Log(this.name + " " + this.rangedSpawn);
                }
            }

            timer = 1.0f;
        }
    }
}
