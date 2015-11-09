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
	public PlayerShooting[] playerShooting;
	public int damageFromAsteroids;
	public int damageToIncreaseBullet;
	public float speedToIncreaseLaserFrequency;
	public MoveTowardsPlayer[] moveToPlayer;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		foreach (var item in moveToPlayer) 
		{
			item.damageFromBullets = 5;
		}
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
			foreach(var item in playerShooting)
			{
				item.timeBetweenBullets-= speedToIncreaseLaserFrequency;
			}

			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag ("Asteroid")) 
		{
			playerHealth.TakeDamage(damageFromAsteroids);
			//other.gameObject.SetActive(false);
		}
		if (other.gameObject.CompareTag ("Bullet Pick Up"))
		{
			foreach(var item in moveToPlayer)
			{
				item.damageFromBullets += damageToIncreaseBullet;
			}
			other.gameObject.SetActive (false);
		}
	}
}
