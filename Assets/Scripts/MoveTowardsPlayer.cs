using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

	public AsteroidHealth enemyHealth;        // Reference to this enemy's health.
	public int damageFromAsteroids = 25;
	public int damageFromLasers = 20;
	
	private Rigidbody rb;
	public int speed;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();	
	}

	
	void Update ()
	{
		Vector3 movement = new Vector3 (0.0f, 0.0f, -1.0f);
		rb.velocity = movement * speed;
	}


	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Laser")) 
		{
			enemyHealth.TakeDamage(damageFromLasers);
            Destroy(gameObject);
		}
	}
}
