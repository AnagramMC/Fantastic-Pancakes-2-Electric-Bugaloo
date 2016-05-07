using UnityEngine;
using System.Collections;

public class StabCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collider target)
    {
        if (target.gameObject.tag == "RangedEnemy")
        {
            Destroy(target.gameObject.transform.parent);
        }
    }
}
