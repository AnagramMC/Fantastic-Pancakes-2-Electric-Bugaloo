using UnityEngine;
using System.Collections;

public class RangedEnemyAI : MonoBehaviour {
    public float speed = 1.0f;
    public float timer = 3.0f;
    public GameObject projectile;

    private Vector3[] myWaypoints;
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
        if (spawner.transform.position == new Vector3(4.72f, 22.0f, -39.55f))
        {
            myWaypoints = iTweenPath.GetPath("MiddlePath");

            Debug.Log("Middle");
        }
        if (spawner.transform.position == new Vector3(2.077f, 19.898f, -38.11f))
        {
            myWaypoints = iTweenPath.GetPath("LeftPath");

            Debug.Log("Left");
        }
        if (spawner.transform.position == new Vector3(-8.38f, 19.181f, -32.69f))
        {
            myWaypoints = iTweenPath.GetPath("RightPath");

            Debug.Log("Right");
        }

        iTween.MoveTo(gameObject, iTween.Hash("path", myWaypoints, "speed", velocity, "looptype", iTween.LoopType.none, "oncomplete", "FireProjectile"));

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.rangedSpawn;

        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;
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

    void FireProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
