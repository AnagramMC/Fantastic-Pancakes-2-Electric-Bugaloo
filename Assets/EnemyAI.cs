using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed = 1.0f;
    public float timer = 3.0f;
    public GameObject AttackCollider;

    private float clock;
    private GameObject spawner;
    private float velocity;
    private EnemySpawner spawnedLocation;
    private int count;

	// Use this for initialization
	void Start () {
        clock = timer;

        velocity = speed * Time.deltaTime;

        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.spawnCount;
    }
	
	// Update is called once per frame
	void Update () {
        clock -= Time.deltaTime;

        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            transform.Translate(0, -velocity, 0);
        }
        else
        {
            RaycastHit ray;

            if (Physics.Raycast(transform.position, Vector3.down, out ray, 1.0f))
            {
                if (ray.collider.gameObject.tag == "RangedEnemy" || ray.collider.gameObject.tag == "PlayerAttack")
                {
                    transform.Translate(0, -velocity, 0);
                }
                if (ray.collider.gameObject.tag == "AttackLine")
                {
                    if (clock < 0.0f)
                    {
                        AttackCollider.SetActive(true);
                        Debug.Log("attack collider on");

                        clock = timer;
                    }
                    else
                    {
                        AttackCollider.SetActive(false);
                        Debug.Log("attack collider off");
                    }
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
