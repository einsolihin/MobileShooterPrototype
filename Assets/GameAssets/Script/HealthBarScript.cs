using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public GameObject player;
    Image healthBar;
    CharacterScript charScript;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        charScript = player.GetComponent<CharacterScript>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = charScript.getHealth() / charScript.getMaxHealth();
    }
}
