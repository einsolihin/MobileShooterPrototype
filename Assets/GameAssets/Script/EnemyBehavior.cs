using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    enum Behavior {Move,Retreat,Attack,Fly,Duck}
    CharacterScript charScript;
    RaycastHit2D hit;
    Behavior enemAction;
	// Use this for initialization
	void Start () {
        enemAction = Behavior.Move;
        charScript = GetComponent<CharacterScript>();
	}
	
	// Update is called once per frame
	void Update () {

		switch(enemAction)
        {
            case Behavior.Move:
                //apply fuzzy logic
                break;
            case Behavior.Retreat:
                //if health low
                break;
            case Behavior.Attack:
                break;
            case Behavior.Fly:
                break;
            case Behavior.Duck:
                break;
        }
	}

    void boxCast()
    {
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(charScript.transform.position, 1f);
    }
    bool checkRange(float radius,Vector2 b)
    {
        return Physics2D.CircleCast(transform.position,radius,transform.position);
    }
}
