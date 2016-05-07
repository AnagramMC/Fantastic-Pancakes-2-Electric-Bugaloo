using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float stabTime = 0.5f;
    public float movementThresholdPX = 10.0f;
    public GameObject HSlashCollider;
    public GameObject[] StabCollider;

    public enum curLane {Lane1, Lane2, Lane3 };
    public enum curState {Idle, MoveRight, MoveLeft, HSlash, Stab, Super };

    public curLane playerPosition;
    public curState playerState;

    public GameObject sword;

    private AudioSource sfxSource;
    public AudioClip moveSound;
    public AudioClip hslashSound;
    public AudioClip stapSound;
    public AudioClip superSound;


    float timer = 1.0f;
    float clock;

    private float mouseDownTime;
    private float mouseXPosition;
    private float mouseUpTime;
    private float newMouseXPoisiton;
	// Use this for initialization
	void Start () {
        clock = timer;
        playerPosition = curLane.Lane2;
        sfxSource = GetComponent<AudioSource>();
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
                HSlashCollider.SetActive(false);
                //StabCollider.SetActive(false);
                break;
            case curState.MoveLeft:
                if (playerPosition == curLane.Lane2)
                {
                    playerPosition = curLane.Lane1;
                    playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                else if (playerPosition == curLane. Lane3)
                {
                    playerPosition = curLane.Lane2;
                    playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                break;
            case curState.MoveRight:
                if (playerPosition == curLane.Lane1)
                {
                    playerPosition = curLane.Lane2;
                    playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                else if (playerPosition == curLane.Lane2)
                {
                    playerPosition = curLane.Lane3;
                    playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                break;
            case curState.HSlash:
                Debug.Log("heavy slash");
                HSlashCollider.SetActive(true);

                clock -= Time.deltaTime;

                if (clock < 0.0f)
                {
                    playerState = curState.Idle;
                    clock = timer;
                }

                PlaySound(hslashSound);

                break;
            case curState.Stab:
                Debug.Log("stab");

                switch (playerPosition)
                {
                    case curLane.Lane1:
                        Debug.DrawLine(sword.transform.position, StabCollider[0].transform.position, Color.red, 1.0f);
                        break;
                    case curLane.Lane2:
                        Debug.DrawLine(sword.transform.position, StabCollider[1].transform.position, Color.red, 1.0f);
                        break;
                    case curLane.Lane3:
                        Debug.DrawLine(sword.transform.position, StabCollider[2].transform.position, Color.red, 1.0f);
                        break;
                }
                clock -= Time.deltaTime;

                if (clock < 0.0f)
                {
                    playerState = curState.Idle;
                    clock = timer;
                }

                PlaySound(stapSound);

                break;
            case curState.Super:

                PlaySound(superSound);

                break;
        }

        switch (playerPosition)
        {
            case curLane.Lane1:
                transform.position = new Vector3(4.41f, 6.14f, 26.45f);
                sword.transform.position = new Vector3(1.45f, 6.33f, 26.51f);
                break;
            case curLane.Lane2:
                transform.position = new Vector3(1.46f, 6.14f, 26.45f);
                sword.transform.position = new Vector3(0.37f, 6.33f, 26.51f);
                break;
            case curLane.Lane3:
                transform.position = new Vector3(-1.34f, 6.14f, 26.45f);
                sword.transform.position = new Vector3(-0.64f, 6.33f, 26.51f);
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

    void PlaySound(AudioClip sound)
    {
        sfxSource.clip = sound;
        sfxSource.Play();
    }
}
