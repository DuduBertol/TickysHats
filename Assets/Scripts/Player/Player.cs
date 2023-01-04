using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Speed")]
    public bool isDeath;
    public float speed;
    [SerializeField] private float inicialspeed;
    public bool isRunning;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float inicialJumpForce;
    [SerializeField] private int jumpTimes;
    public bool isJumping;
    [SerializeField] private float doubleJumpForce;
    [SerializeField] private Rigidbody2D rig;
    public bool isGrounded;
    public bool firstJump;

    [Header("Bullet")]
    public GameObject bullet;
    public Transform gunPos;

    private GameManager gameManager;
    private ButtonAudioManager buttonAudioManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
        isGrounded = true;
        isDeath = false;
        inicialspeed = speed;
        inicialJumpForce = jumpForce;
        firstJump = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        {
            if(!gameManager.isPaused && !isDeath)
            {
                if(firstJump && gameManager.gameStarted)
                {
                    rig.velocity = new Vector2(speed, rig.velocity.y);
                    isRunning = true;
                }
            }
        }
    }

    public void Jump()
    {
        if(jumpTimes > 0)
        {
            if(jumpTimes == 1)
            {
                jumpForce = doubleJumpForce;
            }
            else
            {
                  jumpForce = inicialJumpForce;
            }
            buttonAudioManager.PlayerJumpSound();
            isJumping = true;
            firstJump = true;
            rig.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            jumpTimes--;
        }
    }

    public void OnShot()
        {
            if(firstJump)
            {
                Instantiate<GameObject>(bullet, gunPos.position, Quaternion.identity);
                buttonAudioManager.PlayerShotSound();
            }
        }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
            jumpTimes = 2;
            isJumping = false;
        }
    }

    public void RunSound()
    {
        buttonAudioManager.PlayerRunSound();
    }
}
