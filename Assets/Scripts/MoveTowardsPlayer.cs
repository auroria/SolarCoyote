using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

	public AsteroidHealth enemyHealth;        // Reference to this enemy's health.
	public int damageFromAsteroids = 25;
	public int damageFromLasers = 20;
	public int damageFromBullets = 15;
	
	private Rigidbody rb;
	public int speed;

	public GameObject explosion;
	public GameObject playerExplosion;
	
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
		if (other.gameObject.CompareTag ("Laser")) {
			enemyHealth.TakeDamage (damageFromLasers);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		} else if (other.gameObject.CompareTag ("Bullet")) {
			enemyHealth.TakeDamage (damageFromBullets);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		} else if (other.tag == "Player") {
			Destroy (gameObject);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			//PlayerController.GameOver ();
		} else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
