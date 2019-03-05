using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	public void HorizontalMove (Rigidbody2D rb, float speed)
    {
        rb.AddForce(Vector2.right * rb.mass * speed);
    }

    public void VerticalMove (Rigidbody2D rb, float speed)
    {
        rb.AddForce(Vector2.up * rb.mass * speed);
    }
}
