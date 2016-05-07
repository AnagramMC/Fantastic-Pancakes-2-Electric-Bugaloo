using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float stabTime = 0.5f;
    public float movementThresholdPX = 10.0f;
    public GameObject HSlashCollider;
    public GameObject StabCollider;

    private enum curLane {Lane1, Lane2, Lane3 };
    private enum curState {Idle, MoveRight, MoveLeft, HSlash, Stab, Super };

    private curLane playerPosition;
    private curState playerState;

    private float mouseDownTime;
    private float mouseXPosition;
    private float mouseUpTime;
    private float newMouseXPoisiton;
	// Use this for initialization
	void Start () {
        playerPosition = curLane.Lane2;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            mouseDownTime = Time.time;
            mouseXPosition = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseUpTime = Time.time;
            newMouseXPoisiton = Input.mousePosition.x;
            InputCheck();
        }

        switch (playerState)
        {
            case curState.Idle:
                break;
            case curState.MoveLeft:
                if (playerPosition == curLane.Lane2)
                {
                    playerPosition = curLane.Lane1;
                    playerState = curState.Idle;
                }
                else if (playerPosition == curLane. Lane3)
                {
                    playerPosition = curLane.Lane2;
                    playerState = curState.Idle;
                }
                break;
            case curState.MoveRight:
                if (playerPosition == curLane.Lane1)
                {
                    playerPosition = curLane.Lane2;
                    playerState = curState.Idle;
                }
                else if (playerPosition == curLane.Lane2)
                {
                    playerPosition = curLane.Lane3;
                    playerState = curState.Idle;
                }
                break;
            case curState.HSlash:
                Debug.Log("heavy slash");

                break;
            case curState.Stab:
                Debug.Log("stab");
                break;
            case curState.Super:
                break;
        }

        switch (playerPosition)
        {
            case curLane.Lane1:
                transform.position = new Vector3(-5, -5.5f, 0);
                break;
            case curLane.Lane2:
                transform.position = new Vector3(0, -5.5f, 0);
                break;
            case curLane.Lane3:
                transform.position = new Vector3(5, -5.5f, 0);
                break;
        }
	}

    void InputCheck()
    {
        if (newMouseXPoisiton > mouseXPosition)
        {
            float movement = newMouseXPoisiton - mouseXPosition;
            CheckMovement(movement, true);
        }
        else if (newMouseXPoisiton < mouseXPosition)
        {
            float movement = mouseXPosition - newMouseXPoisiton;
            CheckMovement(movement, false);
        }
        else
        {
            CheckAttack();
        }
    }

    void CheckMovement (float movement, bool isRight)
    {
        if (movement >= movementThresholdPX)
        {
            if (isRight)
            {
                playerState = curState.MoveRight;
            }
            else
            {
                playerState = curState.MoveLeft;
            }
        }  
    }

    void CheckAttack()
    {
        float deltaMouseTime = mouseUpTime - mouseDownTime;
        if (deltaMouseTime >= stabTime)
        {
            playerState = curState.Stab;
        }
        else
        {
            playerState = curState.HSlash;
        }
    }
}
