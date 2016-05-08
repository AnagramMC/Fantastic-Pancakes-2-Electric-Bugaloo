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
    private bool hasAttacked = false;

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

        iTween.MoveTo(gameObject, iTween.Hash("path", myWaypoints, "speed", velocity, "looptype", iTween.LoopType.none, "oncomplete", "CallProjectile", "easetype", "linear", "orienttopath", true));

        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;

        count = spawnedLocation.rangedSpawn;

        if (hasAttacked)
        {
            Debug.Log("Has Attacked");

            transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypoints.Length - 1], 2.0f * Time.deltaTime);
        }
    }

    void CallProjectile()
    {
        InvokeRepeating("FireProjectile", 1.0f, Random.Range(2.0f, 4.0f));
    }

    void FireProjectile()
    {
        transform.rotation = new Quaternion(0,0,0,0);

        Instantiate(projectile, transform.position, transform.rotation);

        if (myWaypoints == iTweenPath.GetPath("RangedTopRightPath"))
        {
            if (count == 1)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RangedRightPath")[iTweenPath.GetPath("RangedRightPath").Length - 1], myWaypoints.Length);
            }
            if (count == 2)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RangedTopRightPath")[iTweenPath.GetPath("RangedTopRightPath").Length - 1], myWaypoints.Length);
            }
        }
        if (myWaypoints == iTweenPath.GetPath("RangedTopLeftPath"))
        {
            if (count == 1)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RangedLeftPath")[iTweenPath.GetPath("RangedLeftPath").Length - 1], myWaypoints.Length);
            }
            if (count == 2)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RangedTopLeftPath")[iTweenPath.GetPath("RangedTopLeftPath").Length - 1], myWaypoints.Length);
            }
        }
        if (myWaypoints == iTweenPath.GetPath("RangedTopMiddlePath"))
        {
            if (count == 1)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RangedMiddlePath")[iTweenPath.GetPath("RangedMiddlePath").Length - 1], myWaypoints.Length);
            }
            if (count == 2)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RangedTopMiddlePath")[iTweenPath.GetPath("RangedTopMiddlePath").Length - 1], myWaypoints.Length);
            }
        }

        hasAttacked = true;
    }
}
