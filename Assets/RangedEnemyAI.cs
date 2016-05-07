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

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.rangedSpawn;
        if (spawner.transform.position == new Vector3(4.72f, 22.0f, -39.55f))
        {
            if (count == 1)
            {
                myWaypoints = iTweenPath.GetPath("RangedMiddlePath");
            }
            if (count == 2)
            {
                myWaypoints = iTweenPath.GetPath("RangedTopMiddlePath");
            }

            Debug.Log("Middle");
        }
        if (spawner.transform.position == new Vector3(2.077f, 19.898f, -38.11f))
        {
            if (count == 1)
            {
                myWaypoints = iTweenPath.GetPath("RangedLeftPath");
            }
            if (count == 2)
            {
                myWaypoints = iTweenPath.GetPath("RangedTopLeftPath");
            }

            Debug.Log("Left");
        }
        if (spawner.transform.position == new Vector3(-8.38f, 19.181f, -32.69f))
        {
            if (count == 1)
            {
                myWaypoints = iTweenPath.GetPath("RangedRightPath");
            }
            if (count == 2)
            {
                myWaypoints = iTweenPath.GetPath("RangedTopRightPath");
            }

            Debug.Log("Right");
        }

        iTween.MoveTo(gameObject, iTween.Hash("path", myWaypoints, "speed", velocity, "looptype", iTween.LoopType.none, "oncomplete", "FireProjectile", "easetype", "linear"));

        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;
    }

    void FireProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
