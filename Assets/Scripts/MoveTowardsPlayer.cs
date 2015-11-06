using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

	AsteroidHealth enemyHealth;        // Reference to this enemy's health.
	public int damageFromAsteroids = 25;
	public int damageFromLasers = 20;
	public int damageFromBullets = 10;
	
	private Rigidbody rb;
	public int speed;

	public GameObject explosion;
	public GameObject playerExplosion;
    public GameObject PickUpToDrop;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();	
		enemyHealth = GetComponent<AsteroidHealth> ();
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
			//Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
            Instantiate(PickUpToDrop, transform.position, transform.rotation);
        } else if (other.gameObject.CompareTag ("Bullet")) {
			enemyHealth.TakeDamage (damageFromBullets);
			Destroy (other.gameObject);					//destroy bullet
			//Destroy (gameObject);						//destroy what is being hit
			Instantiate (explosion, transform.position, transform.rotation);
			if(enemyHealth.isDead)
			{
            	Instantiate(PickUpToDrop, transform.position, transform.rotation);
			}
        } else if (other.tag == "Player") {
			Destroy (gameObject);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		} else if (other.gameObject.CompareTag("Health Pick Up")) {
			return;
		}
		else if (other.gameObject.CompareTag("Shoot Pick Up")) {
			return;
		}
		else if (other.gameObject.CompareTag("Particle")) {
			return;
		}
		else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
