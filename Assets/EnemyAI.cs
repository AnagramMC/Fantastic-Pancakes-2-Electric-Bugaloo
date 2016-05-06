using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed = 1.0f;

    private GameObject spawner;
    private float velocity;
    private EnemySpawner spawnedLocation;
    private int count;

	// Use this for initialization
	void Start () {
        velocity = speed * Time.deltaTime;

        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.spawnCount;
    }
	
	// Update is called once per frame
	void Update () {
        if (spawnedLocation)
        {
            if (count == 1)
            {
                if (transform.position.y >= -2.5)
                {
                    transform.Translate(0, -velocity, 0);
                }
            }
            if (count == 2)
            {
                if (transform.position.y >= -1)
                {
                    transform.Translate(0, -velocity, 0);
                }
            }
            if (count == 3)
            {
                if (transform.position.y >= 0.5)
                {
                    transform.Translate(0, -velocity, 0);
                }
            }
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            spawnedLocation.spawnCount--;

            Destroy(this.gameObject);
        }
    }
}
