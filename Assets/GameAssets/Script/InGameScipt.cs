using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScipt : MonoBehaviour {

    GameObject gameObject;
	// Use this for initialization
	void Start () {
        gameObject = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gameObjectEnable()
    {
        gameObject.SetActive(false);
    }
}
