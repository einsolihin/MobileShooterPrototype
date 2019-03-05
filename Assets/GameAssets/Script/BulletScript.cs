using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    Rigidbody2D bulletRB;
    CircleCollider2D bulletCC;
    SpriteRenderer bulletSR;
    public float direction=1;
    public float speed= 100f;
    public float timeLife=3f;
    public float damage = 20;

	// Use this for initialization
	void Start () {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletCC = GetComponent<CircleCollider2D>();
        bulletSR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        VelocityMove();
        Destroy(gameObject, timeLife);
        
    }

    public void VelocityMove()
    {
        bulletRB.velocity = Vector2.right * speed*direction;
    }

    public void AddForceMove()
    {
        bulletRB.AddForce(Vector2.right * speed * bulletRB.mass * direction);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<EnemyScript>().DamageRecieve(damage);
            Destroy(gameObject);
        }
    }

}
