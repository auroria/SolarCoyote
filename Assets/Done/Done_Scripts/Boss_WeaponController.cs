using UnityEngine;
using System.Collections;

public class Boss_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public Transform player;
	public float projectileSpeed = 10.0f;

	void Start ()
	{
		InvokeRepeating("Fire", delay, fireRate);
	}

	void Update()
	{
		transform.LookAt(player);
//		InvokeRepeating("Fire", delay, fireRate);
	}
/*
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			//store Player position
			player = col.gameObject;
			InvokeRepeating("Fire", delay, fireRate);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			//remove player loc
			player = null;
			CancelInvoke("Shoot");
		}
	}
*/


	void Fire ()
	{
		GameObject shoot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		shoot.GetComponent<Rigidbody>().velocity = (player.transform.position - transform.position).normalized * projectileSpeed;
		//GetComponent<AudioSource>().Play();
	}
}
