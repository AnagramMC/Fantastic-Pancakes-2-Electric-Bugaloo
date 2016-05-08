using UnityEngine;
using System.Collections;

public class PlayerAnimationWrapper : MonoBehaviour {

    private GameObject playerReference;
    public GameObject stabParticle;
    private Player playerScript;

	// Use this for initialization
	void Start () {
        playerReference = transform.parent.gameObject;
        playerScript = playerReference.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StopAttack(int AttackAnim)
    {
        switch (AttackAnim)
        {
            case 0:
                playerScript.StopAttack();
                break;
            case 1:
                if (playerScript.ComboCount > 1)
                {
                    playerScript.KeepAttacking();
                }
                else if (playerScript.ComboCount <= 1)
                {
                    playerScript.ReturnToIdle();
                }
                break;
            case 2:
                if (playerScript.ComboCount > 2)
                {
                    playerScript.KeepAttacking();
                }
                else if (playerScript.ComboCount <= 2)
                {
                    playerScript.ReturnToIdle();
                }
                break;
            case 3:
                playerScript.StopAttack();
                break;
            default:
                break;
        }
        
    }

    public void AttackColliders (int Attack)
    {
        playerScript.Attack(Attack);
    }

    public void ChangeState (string curState)
    {
        switch (curState)
        {
            case "Attack":
                playerScript.playerState = Player.curState.HSlash;
                break;
            case "PullBack":
                playerScript.playerState = Player.curState.StabWind;
                break;
            case "Stab":
                playerScript.playerState = Player.curState.Stab;
                break;
            case "MoveR":
                playerScript.playerState = Player.curState.MoveRight;
                break;
            case "MoveL":
                playerScript.playerState = Player.curState.MoveLeft;
                break;
        }
    }

    public void ActivateEffects ()
    {
        stabParticle.SetActive(true);
    }

    public void ReturnToIdle()
    {
        playerScript.ResetAnimations();
        playerScript.playerState = Player.curState.Idle;
    }


}

