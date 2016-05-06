using UnityEngine;
using System.Collections;

public class RangedEnemyAI : MonoBehaviour {
    public float speed = 1.0f;
    public float timer = 3.0f;
    public GameObject projectile;

    private float clock;
    private GameObject spawner;
    private float velocity;
    private EnemySpawner spawnedLocation;
    private int count;

    // Use this for initialization
    void Start()
    {
        clock = timer;

        velocity = speed * Time.deltaTime;

        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.rangedSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;

        if (spawnedLocation)
        {
            if (count == 1)
            {
                if (transform.position.y >= 2.5)
                {
                    transform.Translate(0, -velocity, 0);
                }
            }
            if (count == 2)
            {
                if (transform.position.y >= 4)
                {
                    transform.Translate(0, -velocity, 0);
                }
            }
        }

        if (clock < 0.0f)
        {
            Instantiate(projectile, transform.position, transform.rotation);

            clock = timer;
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            spawnedLocation.rangedSpawn--;

            Destroy(this.gameObject);
        }
    }
}
