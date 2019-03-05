using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GestureRecognizer;

public class PlayerScript : MonoBehaviour {

    public float speed=50;
    float HorizontalMove;
    Rigidbody2D PlayerRb;
    BoxCollider2D PlayerBx;
    Animator PlayerAnim;
    SpriteRenderer PlayerSr;
    public Joystick joystick;
    RecognitionResult draw;
    public GameObject bullet;
    public GameObject bullectPierce;
    public GameObject bulletCluster;
    public GameObject Vesion;
    private GameObject ammo;
    public float playerHealth = 10;
    private float maxHealth = 100;
    float time = 0;
    float setTime = 3;

	// Use this for initialization
	void Start () {
        Vesion.SetActive(false);
        ammo = bullet;
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerBx = GetComponent<BoxCollider2D>();
        PlayerAnim = GetComponent<Animator>();
        PlayerSr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HorizontalMove = joystick.Horizontal * speed;
        if (joystick.Horizontal > 0.75 || joystick.Horizontal < -0.75)
        {
            PlayerRb.AddForce(Vector2.right * speed * HorizontalMove);
        }
        
        if (PlayerRb.velocity.x < 0 && !PlayerSr.flipX )
        {
            Flip();
        }
        else if (PlayerRb.velocity.x > 0 && PlayerSr.flipX)
        {
            Flip();
        }

        if(Vesion.active)
        {
            time += Time.deltaTime;
        }

        if (time > setTime)
        {
            Vesion.SetActive(false);
            time = 0;
        }
	}
    void Flip()
    {
        PlayerSr.flipX =! PlayerSr.flipX;
        //transform.Rotate(0f, 180, 0f);
    }
    #region DrawingInput
    public void setDraw(RecognitionResult draw)
    {
        if (draw != null)
            this.draw = draw;
    }

    public void getDraw()
    {
        if(draw != null)
        {
            Debug.Log(draw.gesture.id);
            switch (draw.gesture.id)
            {
                case "ClusterBullet":
                    ammo = bulletCluster;
                    break;
                case "Bullet":
                    ammo = bullet;
                    break;
                case "PierceBullet":
                    ammo = bullectPierce;
                    break;
                case "ForceField":
                    break;
                case "HintEye":
                    Vesion.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    #endregion

    public void fireBullet ()
    {
        
        Vector3 bulletPosition = transform.position;
        Instantiate(ammo, bulletPosition, Quaternion.identity);
    }

    public GameObject getBullet()
    {
        return ammo;
    }

    #region Health
    public void setHealth(float playerHealth)
    {
        if (playerHealth > maxHealth)
            playerHealth = maxHealth;

        this.playerHealth = playerHealth;
    }
    public float getHealth()
    {
        return playerHealth;
    }
    public void setMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public float getMaxHealth()
    {
        return maxHealth;
    }
    public void Damage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void HealingKit(float healingKit)
    {
        playerHealth += healingKit;
        if (playerHealth > maxHealth)
            playerHealth = maxHealth;
    }
    #endregion
}
