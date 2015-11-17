using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	private Done_HealthBar hb;
	public float speedToIncreaseShootFrequency = .1f;
	public GameObject[] pickUps;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}
		
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
			//Destroy (other.gameObject);
			Destroy (gameObject);
		}

		
		if (other.tag == "Player") {
			hb = other.GetComponent<Done_HealthBar> ();
			//if player collides with health pick up
			if (this.tag == "Health Pick Up") {
				hb.setPlayerHealth (hb.getPlayerHealth () + 10);
				hb.SetCurrentHealth (hb.getPlayerHealth ());
			}
			else if(this.tag == "Shoot Pick Up")
			{
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Done_PlayerController>()
					.fireRate -= speedToIncreaseShootFrequency;
			}
			else
			{ //player collides with hazard
				hb.setPlayerHealth (hb.getPlayerHealth () - 10);
				hb.SetCurrentHealth (hb.getPlayerHealth ());
			}
			//check if game is over
			if (hb.getPlayerHealth () < 0) {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
				Destroy (other.gameObject);
			}
		} else {
			if(this.tag == "Health Pick Up" && (other.tag == "Bullet" || other.tag == "Laser"))
			{
				hb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Done_HealthBar> ();
				if(hb.getPlayerHealth() < 100)
				{
					hb.setPlayerHealth (hb.getPlayerHealth () + 10);
					hb.SetCurrentHealth (hb.getPlayerHealth ());
				}
			}
			if(this.tag == "Shoot Pick Up" && (other.tag == "Bullet" || other.tag == "Laser"))
			{
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Done_PlayerController>()
					.fireRate -= speedToIncreaseShootFrequency;
			}

			int objectIndex = Random.Range (0, pickUps.Length+1);
			gameController.AddScore (scoreValue);
			if(objectIndex < pickUps.Length)
			{
				Instantiate(pickUps[objectIndex], transform.position, transform.rotation);
			}
		}
	}


}