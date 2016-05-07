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
    private GameManager managerScript;

    // Use this for initialization
    void Start()
    {
        clock = timer;

        velocity = speed * Time.deltaTime;

        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.rangedSpawn;

        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;
        
        if (spawnedLocation)
        {
            if (count == 1)
            {
                if (transform.position.z >= 2.5)
                {
                    transform.Translate(0, 0, -velocity);
                }
            }
            if (count == 2)
            {
                if (transform.position.z >= 4)
                {
                    transform.Translate(0, 0, -velocity);
                }
            }
            
        }

        if (clock < 0.0f)
        {
            Instantiate(projectile, transform.position, transform.rotation);

            clock = Random.Range(2.0f, 4.0f);
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "PlayerAttack")
        {
            spawnedLocation.rangedSpawn--;
            managerScript.score += 2;

            Destroy(this.gameObject);
        }
    }
}
