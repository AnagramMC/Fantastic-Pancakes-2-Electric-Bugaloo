using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {
    public GameObject splats;

    private GameObject spawner;
    private EnemySpawner spawnedLocation;
    private GameManager managerScript;
    private GameObject mySplat;
    private bool foundSplat = false;
    
    // Use this for initialization
    void Start()
    {
        splats = GameObject.Find("ObjectPool Splat");
        spawner = GameObject.FindGameObjectWithTag("Spawner");

        spawnedLocation = spawner.GetComponent<EnemySpawner>();

        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "PlayerAttack")
        {
            spawnedLocation.spawnCount--;
            managerScript.score++;

            //if (splats)
            //{
            //    while (!foundSplat)
            //    {
            //        int randNum = Random.Range(0, splats.GetComponent<ObjectPoolManagement>().splats.Length - 1);

            //        if (!splats.GetComponent<ObjectPoolManagement>().splats[randNum].activeInHierarchy)
            //        {
            //            GameObject[] otherEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                        
            //            for (int i = 0; i < otherEnemies.Length; i++)
            //            {
            //                if (otherEnemies[i] && splats.GetComponent<ObjectPoolManagement>().splats[randNum] != otherEnemies[i].GetComponentInChildren<EnemyCollider>().mySplat)
            //                {
            //                    mySplat = splats.GetComponent<ObjectPoolManagement>().splats[randNum];
            //                    mySplat.transform.position = transform.parent.position;

            //                    mySplat.SetActive(true);
            //                    foundSplat = true;
            //                }
            //                else
            //                {
            //                    foundSplat = false;
            //                }
            //            }
            //        }
            //    }
            //}
            
            Destroy(transform.parent.gameObject);
        }
    }
}
