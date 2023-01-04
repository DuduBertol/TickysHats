using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    
    public bool killEnemy;
    private ButtonAudioManager buttonAudioManager;
    private AchievementsManager achievementsManager;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
        achievementsManager = FindObjectOfType<AchievementsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.killEnemy = true;
            achievementsManager.allLongEnemies++;
            buttonAudioManager.BulletDamageSound();
        }
    }
}
