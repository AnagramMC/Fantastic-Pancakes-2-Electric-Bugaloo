using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    public int health = 10;
    private GameManager managerScript;

    // Use this for initialization
    void Start () {
        managerScript = GameObject.FindGameObjectWithTag("Master").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

        void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "EnemyAttack")
        {
            if (health < 1)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                health--;
                managerScript.hitStreak = 0;
                Debug.Log(health);
            }

            Destroy(target.gameObject);
        }
    }
}
