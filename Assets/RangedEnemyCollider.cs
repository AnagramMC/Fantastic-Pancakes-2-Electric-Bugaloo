using UnityEngine;
using System.Collections;

public class RangedEnemyCollider : MonoBehaviour {
    private GameObject spawner;
    private EnemySpawner spawnedLocation;
    private GameManager managerScript;

    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "PlayerAttack")
        {
            spawnedLocation.rangedSpawn--;
            managerScript.score += 2;

            Debug.Log("RangedHit");

            Destroy(transform.parent.gameObject);
        }
    }
}
