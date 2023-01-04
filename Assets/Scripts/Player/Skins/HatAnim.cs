using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatAnim : MonoBehaviour
{
    private Animator anim;
    private Player player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        OnRun();
        OnJump();
    }

    private void OnRun()
    {
        if(player.isRunning && !gameManager.isPaused)
        {
            anim.SetInteger("transition", 1);
        }
    }

    private void OnJump()
    {
        if(player.isJumping && !gameManager.isPaused)
        {
            anim.SetInteger("transition", 2);
        }
    }
}
