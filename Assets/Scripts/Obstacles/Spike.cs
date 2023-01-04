using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    private Player player;
    private ButtonAudioManager buttonAudioManager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.isDeath = true; 
            Destroy(this.gameObject);
            buttonAudioManager.HighScoreSound();          
        }
    }
}
