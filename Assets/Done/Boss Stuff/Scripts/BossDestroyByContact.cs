using UnityEngine;
using System.Collections;

public class BossDestroyByContact : MonoBehaviour {
	
	BossHealth enemyHealth;        // Reference to this enemy's health.
	public int damageFromBullets = 10;
	public int  damageFromLasers = 50;

	private Rigidbody rb;
	public int speed;

	public GameObject deathExplosion;
	public GameObject explosion;
	public GameObject playerExplosion;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();	
		enemyHealth = GetComponent<BossHealth> ();
	}

	/*void Update ()
	{
		Vector3 movement = new Vector3 (0.0f, 0.0f, -1.0f);
		rb.velocity = movement * speed;
	}*/
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}
		if (gameObject.CompareTag ("Laser")) {
			enemyHealth.TakeDamage (damageFromLasers);
			//Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			if(enemyHealth.isDead)
			{
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}

		} else if (other.gameObject.CompareTag ("Bullet")) {
			enemyHealth.TakeDamage (damageFromBullets);
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);					//destroy bullet
			//Destroy (gameObject);						//destroy what is being hit

			if(enemyHealth.isDead)
			{
				Instantiate (deathExplosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		else if (other.gameObject.CompareTag ("Laser")) {
			enemyHealth.TakeDamage (damageFromLasers);
			Destroy (other.gameObject);					//destroy bullet
			//Destroy (gameObject);						//destroy what is being hit
			Instantiate (explosion, transform.position, transform.rotation);
			if(enemyHealth.isDead)
			{
				Instantiate (deathExplosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		else if (other.tag == "Player") {
			//Destroy (gameObject);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		} 

		else if (other.gameObject.CompareTag("Enemy")) {
			return;
			//Destroy (gameObject);
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		} 
		else if (other.gameObject.CompareTag("Particle")) {
			return;
		}
		else {
			//Instantiate (explosion, transform.position, transform.rotation);
			//Destroy (other.gameObject);
			//Destroy (gameObject);
		}
	}
}
