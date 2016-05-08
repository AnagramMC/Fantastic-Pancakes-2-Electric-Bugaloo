using UnityEngine;
using System.Collections;

public class FrontCheck : MonoBehaviour {

    public bool isFront = false;

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "RangedEnemy")
        {
            isFront = true;
        }
        if (target.gameObject.tag == "PlayerAttack")
        {
            isFront = false;
        }
    }
}
