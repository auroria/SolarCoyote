using UnityEngine;
using System.Collections;

public class BossEvasiveManeuver : MonoBehaviour
{
		public Boundary boundary;
		public float tilt;
		public float dodge;
		public float smoothing;
		public float rotationX;
		public float rotationY;
		public Vector2 startWait;
		public Vector2 maneuverTime;
		public Vector2 maneuverWait;
		private float targetManeuver;

		void Start ()
		{
				StartCoroutine (Evade ());
		}
	
		IEnumerator Evade ()
		{
				yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
				while (true) {
						targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
						yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
						targetManeuver = 0;
						yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
				}
		}
	
		void FixedUpdate ()
		{
				float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
				GetComponent<Rigidbody>().velocity = new Vector3 (newManeuver, 0.0f, GetComponent<Rigidbody>().velocity.z);
				GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax) /*0.0f*/, 
			GetComponent<Rigidbody>().position.z
				);
		
				GetComponent<Rigidbody>().rotation = Quaternion.Euler (rotationX, rotationY, GetComponent<Rigidbody>().velocity.x * -tilt);
				
		}
}
