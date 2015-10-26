using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public int healAmount = 10;
	public float speed;

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
		
		Vector3 movement = new Vector3 (moveHorizontal,0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Health Pick Up"))
		{
			playerHealth.HealPlayer(healAmount);
			other.gameObject.SetActive (false);
		}
	}
}
