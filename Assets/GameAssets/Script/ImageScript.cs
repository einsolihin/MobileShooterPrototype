using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    Image image;
    public GameObject Player;
    GameObject bullet;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        getColour();
    }

    void getColour()
    {
        bullet = Player.GetComponent<PlayerScript>().getBullet();
        //image.color = bullet.GetComponent<SpriteRenderer>().color;
    }

    void getImage()
    {
        bullet = Player.GetComponent<PlayerScript>().getBullet();
        image.sprite = bullet.GetComponent<SpriteRenderer>().sprite;
    }
}
