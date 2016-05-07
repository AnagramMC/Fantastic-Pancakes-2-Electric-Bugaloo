using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    public int health = 10;

	// Use this for initialization
	void Start () {
	
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
                Debug.Log(health);
            }

            Destroy(target.gameObject);
        }
    }
}
