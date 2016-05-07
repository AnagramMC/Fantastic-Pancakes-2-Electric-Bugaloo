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

	// Use this for initialization
	void Start () {
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

        iTween.MoveTo(gameObject, iTween.Hash("path", myWaypoints, "speed", velocity, "looptype", iTween.LoopType.none, "oncomplete", "Attack"));

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        count = spawnedLocation.spawnCount;
    }
	
	// Update is called once per frame
	void Update () {
        clock -= Time.deltaTime;

        RaycastHit ray;

        if (Physics.Raycast(transform.position, Vector3.forward, out ray, 10.0f))
        {
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

    void Attack()
    {

    }
}
