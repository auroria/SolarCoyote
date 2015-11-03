using UnityEngine;
using System.Collections;

public class ProjectileShoot : MonoBehaviour {
	public Transform bolt;							
	//public int damagePerShot = 20;                  // The damage inflicted by each bullet.
	public float timeBetweenBullets = 0.25f;        // The time between each shot.
	public float range = 100f;                      // The distance the gun can fire.
	
	float timer;                                    // A timer to determine when to fire.
	AudioSource gunAudio;                           // Reference to the audio source.
	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

	// Use this for initialization
	void Awake (){
		// Set up the references.
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		//if space is pressed and not in delay, fire
		if(Input.GetButton ("Fire2") && timer >= timeBetweenBullets){
			Shoot();
		}

		// If the timer has exceeded the proportion of timeBetweenBullets
		if (timer >= timeBetweenBullets * effectsDisplayTime){
			// ... disable the effects.
			DisableEffects ();
		}
	}

	void Shoot(){
		// Reset the timer.
		timer = 0f;
		
		// Play the gun shot audioclip.
		gunAudio.Play ();
		
		// Enable the light.
		gunLight.enabled = true;

		// Create a bolt at player position/rotation
		Instantiate (bolt, transform.position, transform.rotation);

	}
	public void DisableEffects ()
	{
		// Disable light
		gunLight.enabled = false;
	}
}
