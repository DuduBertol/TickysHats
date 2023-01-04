using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public bool deadEnemy;
    private ButtonAudioManager buttonAudioManager;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.deadEnemy = true;
            buttonAudioManager.HighScoreSound();
        }
    }
}
