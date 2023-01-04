using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public List<Transform> paths = new List<Transform>();
    public int index;
    private Animator anim;
    private Player player;
    private AchievementsManager achievementsManager;

    public KillZone killZone;
    public DeathZone deathZone;
    private ButtonAudioManager buttonAudioManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        achievementsManager = FindObjectOfType<AchievementsManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.3f)
        {
            if(index < 1)
            {
                index = 1;
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;

        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(killZone.killEnemy)
        {
            Destroy(this.gameObject);
        }

        if(deathZone.deadEnemy)
        {
            player.isDeath = true;
            Destroy(this.gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Bullet"))
        {
            achievementsManager.allLongEnemies++;
            buttonAudioManager.BulletDamageSound();
            Destroy(this.gameObject, 0.01f);
        }
    }

    
}
