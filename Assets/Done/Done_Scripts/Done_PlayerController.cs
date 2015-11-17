using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public float rollSpeed;
	public float rollTilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

	public Boundary bound;
	private Rigidbody rb;
	private Collider coll;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
	}

	void Update ()
	{
		if (Input.GetButton("Fire2") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		if (Input.GetKey("z"))
		{
			DoBarrelRoll();
		}
		else
		{
			coll.enabled = true;
			
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
			
			rb.velocity = (movement * speed);
			
			rb.position = new Vector3(Mathf.Clamp(rb.position.x, bound.xMin, bound.xMax), Mathf.Clamp(rb.position.y, bound.yMin, bound.yMax), rb.position.z);
			
			rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt, 0.0f, rb.velocity.x * -tilt);
		}
	}

	void DoBarrelRoll()
	{
		coll.enabled = false;
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		
		rb.velocity = (movement * rollSpeed);
		
		rb.position = new Vector3(Mathf.Clamp(rb.position.x, bound.xMin, bound.xMax), Mathf.Clamp(rb.position.y, bound.yMin, bound.yMax), rb.position.z);
		
		rb.AddTorque(0.0f, 0.0f, moveHorizontal * -rollTilt);
	}
}
