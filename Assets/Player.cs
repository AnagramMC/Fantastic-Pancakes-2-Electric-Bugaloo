using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int health = 10;
    public float stabTime = 0.5f;
    public float movementThresholdPX = 10.0f; 

    private enum curLane {Lane1, Lane2, Lane3 };
    private enum curState {Idle, MoveRight, MoveLeft, HSlash, Stab, Super };

    private curLane playerPosition;
    private curState playerState;

	// Use this for initialization
	void Start () {
        playerPosition = curLane.Lane3;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            InputCheck(Time.time, Input.mousePosition.x);
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
                break;
            case curState.Stab:
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

    void InputCheck(float mouseDownTime, float oldMousePosition)
    {
        if (Input.GetMouseButtonUp(0))
            {
                float newMousePosition = Input.mousePosition.x;
                Debug.Log(newMousePosition);
                Debug.Log(oldMousePosition);
                if (newMousePosition > oldMousePosition)
                {
                    float movement = newMousePosition - oldMousePosition;
                    CheckMovement(movement, true, mouseDownTime, Time.time);
                }
                else if (newMousePosition < oldMousePosition)
                {
                    float movement = oldMousePosition - newMousePosition;
                    CheckMovement(movement, false, mouseDownTime, Time.time);
                }
            }
    }

    void CheckMovement (float movement, bool isRight, float mouseDownTime, float mouseUpTime)
    {
        if (movement > movementThresholdPX)
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
        else
        {
            CheckAttack(mouseDownTime, mouseUpTime);
        }
    }

    void CheckAttack(float mouseDownTime, float mouseUpTime)
    {
        float deltaMouseTime = mouseUpTime - mouseDownTime;
        if (deltaMouseTime > stabTime)
        {
            playerState = curState.Stab;
        }
        else
        {
            playerState = curState.HSlash;
        }
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
