using UnityEngine;
using System.Collections;

public class LineToStab : MonoBehaviour {

    public GameObject player;
    private Player playerScript;

	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerScript.playerState == Player.curState.Stab)
        {
            switch (playerScript.playerPosition)
            {
                case Player.curLane.Lane1:
                    Debug.DrawLine(transform.position, playerScript.StabCollider[0].transform.position);
                    break;
                case Player.curLane.Lane2:
                    Debug.DrawLine(transform.position, playerScript.StabCollider[1].transform.position);
                    break;
                case Player.curLane.Lane3:
                    Debug.DrawLine(transform.position, playerScript.StabCollider[2].transform.position);
                    break;
            }
        }
	}
}
