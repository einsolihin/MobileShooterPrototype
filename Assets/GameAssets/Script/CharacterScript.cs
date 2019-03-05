using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public float speed = 50;
    float HorizontalMove;
    Rigidbody2D CharRb;
    BoxCollider2D CharBx;
    Animator CharAnim;
    SpriteRenderer CharSr;
    private GameObject ammo;
    public Transform firePoint;
    public float CharHealth = 10;
    public float maxHealth = 100;
    

    // Use this for initialization
    void Start()
    {

        CharRb = GetComponent<Rigidbody2D>();
        CharBx = GetComponent<BoxCollider2D>();
        CharAnim = GetComponent<Animator>();
        CharSr = GetComponent<SpriteRenderer>();
        setHealth(CharHealth);
    }
    

    #region getCompenent
    public Rigidbody2D GetRigidbody2()
    {
        return CharRb;
    }
    public BoxCollider2D GetBoxCollider2D()
    {
        return CharBx;
    }
    public Animator GetAnimator()
    {
        return CharAnim;
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return CharSr;
    }
    #endregion

    #region Movement
    public void AddForceMove(float input)
    {
        CharRb.AddForce(Vector2.right*input*speed*CharRb.mass);
        if (CharRb.velocity.x < 0 && !CharSr.flipX)
        {
            Flip();
        }
        else if (CharRb.velocity.x > 0 && CharSr.flipX)
        {
            Flip();
        }
    }

    public void VectorMove(float input)
    {
        CharRb.velocity = (Vector2.right*speed*input);
        if (CharRb.velocity.x < 0 && !CharSr.flipX)
        {
            Flip();
        }
        else if (CharRb.velocity.x > 0 && CharSr.flipX)
        {
            Flip();
        }
    }

    
    void Flip ()
    {
        //transform.Rotate(0f, 180f, 0f);
        firePoint.Rotate(0f, 180f, 0f);
        firePoint.localPosition = new Vector2(-firePoint.localPosition.x, firePoint.localPosition.y);
        CharSr.flipX = !CharSr.flipX;
        ammo.GetComponent<BulletScript>().direction = -ammo.GetComponent<BulletScript>().direction;
    }
    #endregion

    #region Attack
    public void setAmmo(GameObject ammo)
    {
        this.ammo = ammo;
    }
    public GameObject getBullet()
    {
        return ammo;
    }
    public void fireBullet()
    {
        Instantiate(ammo, firePoint.position, firePoint.rotation);
    }
    #endregion

    #region Health
    public void setHealth(float CharHealth)
    {
        if (CharHealth > maxHealth)
            CharHealth = maxHealth;

        this.CharHealth = CharHealth;
    }
    public float getHealth()
    {
        return CharHealth;
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
        CharHealth -= damage;
        if (CharHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void HealingKit(float healingKit)
    {
        CharHealth += healingKit;
        if (CharHealth > maxHealth)
            CharHealth = maxHealth;
    }
    #endregion
}
