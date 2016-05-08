using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float stabTime = 0.5f;
    public float movementThresholdPX = Screen.width / 3;
    public GameObject[] HSlashCollider;
    public GameObject[] StabCollider;

    public enum curLane {Lane1, Lane2, Lane3 };
    public enum curState {Idle, MoveRight, MoveLeft, HSlash, StabWind, Stab, Super };

    public curLane playerPosition;
    public curState playerState;

    public GameObject sword;

    private AudioSource sfxSource;
    public AudioClip moveSound;
    public AudioClip hslashSound;
    public AudioClip stapSound;
    public AudioClip superSound;
    public bool isMouseDown;

    float timer = 0.25f;
    float AttackTimer = 0.25f;

    float ResetAttack;
    float clock;

    private Animator playerAnims;
    public int ComboCount;

    private AnimatorStateInfo AnimInfo;

    private float mouseDownTime;
    private float mouseXPosition;
    private float mouseUpTime;
    private float newMouseXPosition;
	// Use this for initialization
	void Start () {
        clock = timer;
        playerPosition = curLane.Lane2;
        playerState = curState.Idle;
        sfxSource = GetComponent<AudioSource>();
        movementThresholdPX = Screen.width / 5;
        playerAnims = sword.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        playerAnims.SetInteger("ComboCount", ComboCount);

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            mouseDownTime = Time.time;
            mouseXPosition = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            mouseUpTime = Time.time;
            newMouseXPosition = Input.mousePosition.x;
            InputCheck();
        }

        switch (playerState)
        {
            case curState.Idle:
                HSlashCollider[0].SetActive(false);
                HSlashCollider[1].SetActive(false);
                HSlashCollider[2].SetActive(false);
                StabCollider[0].SetActive(false);
                StabCollider[1].SetActive(false);
                StabCollider[2].SetActive(false);
                break;
            case curState.MoveLeft:
                if (playerPosition == curLane.Lane2)
                {
                    playerPosition = curLane.Lane1;
                    //playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                else if (playerPosition == curLane. Lane3)
                {
                    playerPosition = curLane.Lane2;
                    //playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                break;
            case curState.MoveRight:
                if (playerPosition == curLane.Lane1)
                {
                    playerPosition = curLane.Lane2;
                    //playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                else if (playerPosition == curLane.Lane2)
                {
                    playerPosition = curLane.Lane3;
                    //playerState = curState.Idle;

                    PlaySound(moveSound);
                }
                break;
            case curState.HSlash:
                Debug.Log("heavy slash");

                break;
            case curState.StabWind:
                break;
            case curState.Stab:
                Debug.Log("stab");

                switch (playerPosition)
                {
                    case curLane.Lane1:
                        StabCollider[0].SetActive(true);
                        GameObject.Find("Left Front").GetComponent<FrontCheck>().isFront = false;
                        break;
                    case curLane.Lane2:
                        StabCollider[1].SetActive(true);
                        GameObject.Find("Center Front").GetComponent<FrontCheck>().isFront = false;
                        break;
                    case curLane.Lane3:
                        StabCollider[2].SetActive(true);
                        GameObject.Find("Right Front").GetComponent<FrontCheck>().isFront = false;
                        break;
                }
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

    public void ResetAnimations()
    {
        ComboCount = 0;
        playerAnims.SetBool("isStabbing", false);
        playerAnims.SetBool("releaseStab", false);
        playerAnims.SetBool("ReturnToIdle", false);
        //playerAnims.SetBool("", false);
        //playerAnims.SetBool("", false);
        //playerAnims.SetBool("", false);
    }

    public void Attack(int curAttack)
    {
        HSlashCollider[curAttack].SetActive(true);
    }

    public void StopAttack ()
    {
        ComboCount = 0;
        HSlashCollider[0].SetActive(false);
        HSlashCollider[1].SetActive(false);
        HSlashCollider[2].SetActive(false);
        StabCollider[0].SetActive(false);
        StabCollider[1].SetActive(false);
        StabCollider[2].SetActive(false);
    }

    public void ReturnToIdle ()
    {
        playerAnims.SetBool("ReturnToIdle", true);
        StopAttack();
    }

    public void KeepAttacking ()
    {
        playerAnims.SetInteger("ComboCount", ComboCount);
    }

    void InputCheck()
    {
        if (newMouseXPosition > mouseXPosition)
        {
            float movement = newMouseXPosition - mouseXPosition;
            CheckMovement(movement, true);
        }
        else if (newMouseXPosition < mouseXPosition)
        {
            float movement = mouseXPosition - newMouseXPosition;
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
        else
        {
            CheckAttack();
        } 
    }

    void CheckAttack()
    {
        float deltaMouseTime = mouseUpTime - mouseDownTime;
        if (deltaMouseTime >= stabTime)
        {
            if (isMouseDown)
            {
                playerAnims.SetBool("isStabbing", true);
                playerAnims.SetBool("releaseStab", false);
            }
        }
        else
        {
            ComboCount++;
        }
    }

    void PlaySound(AudioClip sound)
    {
        sfxSource.clip = sound;
        sfxSource.Play();
    }
}
