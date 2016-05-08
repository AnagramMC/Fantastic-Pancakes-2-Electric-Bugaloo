using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed = 1.0f;
    public float timer = 3.0f;
    public GameObject AttackCollider;
    public GameObject animMesh;

    private Vector3[] myWaypoints;
    private float clock;
    private GameObject spawner;
    private float velocity;
    private EnemySpawner spawnedLocation;
    private int count;
    private bool hasAttacked = false;
    private Animator myAnimator;

    // Use this for initialization
    void Start () {
        myAnimator = animMesh.GetComponent<Animator>();

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

        myAnimator.SetBool("IsMoving", true);
        myAnimator.SetBool("IsAttacking", false);
        myAnimator.SetBool("IsStanding", false);
        iTween.MoveTo(gameObject, iTween.Hash("path", myWaypoints, "speed", velocity, "looptype", iTween.LoopType.none, "oncomplete", "CallAttack", "easetype", "linear", "orienttopath", true));
    }

    // Update is called once per frame
    void Update () {
        clock -= Time.deltaTime;

        count = spawnedLocation.spawnCount;

        if (hasAttacked)
        {
            Debug.Log("List " + myWaypoints.Length);

            myAnimator.SetBool("IsMoving", true);
            myAnimator.SetBool("IsAttacking", false);
            myAnimator.SetBool("IsStanding", false);
            transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypoints.Length - 1], 3.0f * Time.deltaTime);

            if (myAnimator.GetBool("IsMoving"))
            {
                myAnimator.SetBool("IsMoving", false);
                myAnimator.SetBool("IsAttacking", false);
                myAnimator.SetBool("IsStanding", true);
            }
        }
    }

    void CallAttack()
    {
        myAnimator.SetBool("IsMoving", false);
        myAnimator.SetBool("IsAttacking", false);
        myAnimator.SetBool("IsStanding", true);

        InvokeRepeating("Attack", 1.0f, Random.Range(2.0f, 4.0f));
    }

    void Attack()
    {
        myAnimator.SetBool("IsMoving", false);
        myAnimator.SetBool("IsAttacking", true);
        myAnimator.SetBool("IsStanding", false);

        Instantiate(AttackCollider, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0f), transform.rotation);

        hasAttacked = true;
    }
}
