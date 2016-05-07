using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {
    private GameObject spawner;
    private EnemySpawner spawnedLocation;

    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();
    }

        void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "PlayerAttack")
        {
            spawnedLocation.spawnCount--;

            Destroy(this.gameObject);
        }
    }
}
