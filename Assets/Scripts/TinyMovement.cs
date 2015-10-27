using UnityEngine;
using System.Collections;

public class TinyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public int speed;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();	
	}
	
	void FixedUpdate ()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f);
        rb.velocity = movement * speed;
	}
}
