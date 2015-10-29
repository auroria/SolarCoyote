using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {
	public float speed = 20f;			//set speed of bullet
	public float bulletLifetime = 1.0f;	//how long the bullet exists after being fired
	float timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
		if (timer > bulletLifetime) {
			Destroy(gameObject);
		}
	}

	//if bullet hits something
	void OnCollisionEnter(Collision collision){
		//delete itself
		Destroy(gameObject);
	}
}