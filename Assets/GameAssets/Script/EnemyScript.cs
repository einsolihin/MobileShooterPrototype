using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    Rigidbody2D EnemRB;
    SpriteRenderer EnemSR;
    BoxCollider2D EnemBC;
    Animator EnemAnim;

    public float speed;
    public float health;
    public float damage;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(gameObject);
	}

    public void DamageRecieve(float damage)
    {
        health -= damage;
    }
}
