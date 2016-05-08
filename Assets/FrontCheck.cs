using UnityEngine;
using System.Collections;

public class FrontCheck : MonoBehaviour {

    public bool isFront = false;

    void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "RangedEnemy")
        {
            isFront = true;
        }
    }
}
