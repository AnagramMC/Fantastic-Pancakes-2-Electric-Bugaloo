using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
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
            if (health < 0)
            {
                Destroy(this.gameObject);
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
