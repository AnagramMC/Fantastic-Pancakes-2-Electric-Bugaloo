using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed = 1.0f;
    public float timer = 3.0f;
    public GameObject AttackCollider;

    private Vector3[] myWaypoints;
    private float clock;
    private GameObject spawner;
    private float velocity;
    private EnemySpawner spawnedLocation;
    private int count;
    private bool hasAttacked = false;

	// Use this for initialization
	void Start () {
        clock = timer;

        velocity = speed * Time.deltaTime;

        spawner = GameObject.FindGameObjectWithTag("Spawner");
        
        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.spawnCount;
        if (spawner.transform.position == new Vector3(4.72f, 22.0f, -39.55f))
        {
            if (count == 1)
            {
                myWaypoints = iTweenPath.GetPath("MiddlePath");
            }
            if (count == 2)
            {
                myWaypoints = iTweenPath.GetPath("MidMiddlePath");
            }
            if (count == 3)
            {
                myWaypoints = iTweenPath.GetPath("BackMiddlePath");
            }

            Debug.Log("Middle");
        }
        if (spawner.transform.position == new Vector3(2.077f, 19.898f, -38.11f))
        {
            if (count == 1)
            {
                myWaypoints = iTweenPath.GetPath("LeftPath");
            }
            if (count == 2)
            {
                myWaypoints = iTweenPath.GetPath("MidLeftPath");
            }
            if (count == 3)
            {
                myWaypoints = iTweenPath.GetPath("BackLeftPath");
            }

            Debug.Log("Left");
        }
        if (spawner.transform.position == new Vector3(-8.38f, 19.181f, -32.69f))
        {
            if (count == 1)
            {
                myWaypoints = iTweenPath.GetPath("RightPath");
            }
            if (count == 2)
            {
                myWaypoints = iTweenPath.GetPath("MidRightPath");
            }
            if (count == 3)
            {
                myWaypoints = iTweenPath.GetPath("BackRightPath");
            }

            Debug.Log("Right");
        }

        iTween.MoveTo(gameObject, iTween.Hash("path", myWaypoints, "speed", velocity, "looptype", iTween.LoopType.none, "oncomplete", "CallAttack", "easetype", "linear", "orienttopath", true));
    }

    // Update is called once per frame
    void Update () {
        clock -= Time.deltaTime;

        count = spawnedLocation.spawnCount;

        if (hasAttacked)
        {
            Debug.Log("List " + myWaypoints.Length);

            transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypoints.Length - 1], 3.0f * Time.deltaTime);
        }
    }

    void CallAttack()
    {
        InvokeRepeating("Attack", 1.0f, Random.Range(2.0f, 4.0f));
    }

    void Attack()
    {
        Instantiate(AttackCollider, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f), transform.rotation);

        if (myWaypoints == iTweenPath.GetPath("MidRightPath") || myWaypoints == iTweenPath.GetPath("BackRightPath"))
        {
            if (count == 1)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("RightPath")[iTweenPath.GetPath("RightPath").Length - 1], myWaypoints.Length);
            }
            if (count == 2)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("MidRightPath")[iTweenPath.GetPath("MidRightPath").Length - 1], myWaypoints.Length);
            }
            if (count == 3)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("BackRightPath")[iTweenPath.GetPath("BackRightPath").Length - 1], myWaypoints.Length);
            }
        }
        if (myWaypoints == iTweenPath.GetPath("MidLeftPath") || myWaypoints == iTweenPath.GetPath("BackLeftPath"))
        {
            if (count == 1)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("LeftPath")[iTweenPath.GetPath("LeftPath").Length - 1], myWaypoints.Length);
            }
            if (count == 2)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("MidLeftPath")[iTweenPath.GetPath("MidLeftPath").Length - 1], myWaypoints.Length);
            }
            if (count == 3)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("BackLeftPath")[iTweenPath.GetPath("BackLeftPath").Length - 1], myWaypoints.Length);
            }
        }
        if (myWaypoints == iTweenPath.GetPath("MidMiddlePath") || myWaypoints == iTweenPath.GetPath("BackMiddlePath"))
        {
            if (count == 1)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("MiddlePath")[iTweenPath.GetPath("MiddlePath").Length - 1], myWaypoints.Length);
            }
            if (count == 2)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("MidMiddlePath")[iTweenPath.GetPath("MidMiddlePath").Length - 1], myWaypoints.Length);
            }
            if (count == 3)
            {
                myWaypoints.SetValue(iTweenPath.GetPath("BackMiddlePath")[iTweenPath.GetPath("BackMiddlePath").Length - 1], myWaypoints.Length);
            }
        }

        hasAttacked = true;
    }
}
