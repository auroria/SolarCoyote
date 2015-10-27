using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {
	
	public int healAmount = 10;
	public float speed;
    public float tilt;
    public Boundary bound;
	private Rigidbody rb;
	public PlayerHealth playerHealth;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement;
		if (Input.GetKey ("z")) {
			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		} 
		else 
		{
			
			movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		}
		
		rb.velocity = (movement * speed);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, bound.xMin, bound.xMax), Mathf.Clamp(rb.position.y, bound.yMin, bound.yMax), rb.position.z);

        rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt, 0.0f, rb.velocity.x * -tilt);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Health Pick Up"))
		{
			playerHealth.HealPlayer(healAmount);
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("Shoot Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
	}
}
