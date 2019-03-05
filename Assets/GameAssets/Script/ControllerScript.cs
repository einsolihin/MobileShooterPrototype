using GestureRecognizer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {
    public Joystick joystick;
    RecognitionResult draw;
    public GameObject aim;
    public List<GameObject> ability = new List<GameObject>();
    private CharacterScript charScript;
    float time = 0;
    float setTime = 3;

    // Use this for initialization
    void Start () {
        ability[3].SetActive(false);
        charScript = GetComponent<CharacterScript>();
        charScript.setAmmo(ability[0]);
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (joystick.Horizontal > 0.75 || joystick.Horizontal < -0.75)
        {
            charScript.AddForceMove(joystick.Horizontal);
        }

        if (ability[3].active)
        {
            time += Time.deltaTime;
        }

        if (time > setTime)
        {
            ability[3].SetActive(false);
            time = 0;
        }
    }

    

    #region DrawingInput
    public void setDraw(RecognitionResult draw)
    {
        if (draw != null)
            this.draw = draw;
    }

    public void getDraw()
    {
        if (draw != null)
        {
            Debug.Log(draw.gesture.id);
            switch (draw.gesture.id)
            {
                case "ClusterBullet":
                    charScript.setAmmo(ability[1]);
                    break;
                case "Bullet":
                    charScript.setAmmo(ability[0]);
                    break;
                case "PierceBullet":
                    charScript.setAmmo(ability[2]);
                    break;
                case "ForceField":
                    break;
                case "HintEye":
                    ability[3].SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}
