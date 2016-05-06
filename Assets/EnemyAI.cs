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
        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            transform.Translate(0, -velocity, 0);
        }
        else
        {
            RaycastHit ray;

            if (Physics.Raycast(transform.position, Vector3.down, out ray, 1.0f))
            {
                if (ray.collider.gameObject.tag == "RangedEnemy")
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
