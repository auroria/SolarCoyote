using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	private Done_HealthBar hb;
	public GameObject healthPickUp;

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
			}else{ //player collides with hazard
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
			gameController.AddScore (scoreValue);
			Instantiate(healthPickUp, transform.position, transform.rotation);
		}
	}


}