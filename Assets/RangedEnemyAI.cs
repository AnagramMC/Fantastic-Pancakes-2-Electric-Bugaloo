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
    private Animator myAnimator;

    public GameObject FrontPos;

    // Use this for initialization
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();

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

            FrontPos = GameObject.Find("Center Front");

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

            FrontPos = GameObject.Find("Left Front");

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

            FrontPos = GameObject.Find("Right Front");

            Debug.Log("Right");
        }

        myAnimator.SetBool("IsMoving", true);
        myAnimator.SetBool("IsAttacking", false);
        myAnimator.SetBool("IsStanding", false);
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

            if (FrontPos.GetComponent<FrontCheck>().isFront == false)
            {
                myAnimator.SetBool("IsMoving", true);
                myAnimator.SetBool("IsAttacking", false);
                myAnimator.SetBool("IsStanding", false);

                transform.position = Vector3.MoveTowards(transform.position, FrontPos.transform.position, 2.0f * Time.deltaTime);
            }
            myAnimator.SetBool("IsMoving", false);
            myAnimator.SetBool("IsAttacking", false);
            myAnimator.SetBool("IsStanding", true);
        }
    }

    void CallProjectile()
    {
        myAnimator.SetBool("IsMoving", false);
        myAnimator.SetBool("IsAttacking", false);
        myAnimator.SetBool("IsStanding", true);

        InvokeRepeating("FireProjectile", 1.0f, Random.Range(2.0f, 4.0f));
    }

    void FireProjectile()
    {
        transform.rotation = new Quaternion(0,0,0,0);

        myAnimator.SetBool("IsMoving", false);
        myAnimator.SetBool("IsAttacking", true);
        myAnimator.SetBool("IsStanding", false);

        Instantiate(projectile, transform.position, transform.rotation);

        hasAttacked = true;
    }
}
