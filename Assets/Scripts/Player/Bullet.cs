using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D bulletRig;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bulletRig.velocity = new Vector2 (bulletSpeed , 0);
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
