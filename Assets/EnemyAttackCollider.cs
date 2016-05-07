using UnityEngine;
using System.Collections;

public class EnemyAttackCollider : MonoBehaviour {
    public float timer = 1.0f;

    private float clock;

    void Start()
    {
        Debug.Log("EnemyAttacks");

        clock = timer;
    }
    void Update()
    {
        clock--;
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (clock < 0.0f)
            {
                Destroy(this.gameObject);

                clock = timer;
            }
        }
    }
}
