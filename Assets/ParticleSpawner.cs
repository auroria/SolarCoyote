using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {

	public GameObject[] environmentsToSpawn;
	public float maxSpawnTime = 3f;            // How long between each spawn.
	public Transform spawnPoint;         //spawn point the particles can spawn from.
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", 15f, maxSpawnTime);
	}
	
	// Update is called once per frame
	void Spawn()
	{
		int objectIndex = Random.Range (0, environmentsToSpawn.Length);
		Debug.Log (objectIndex);
		Instantiate (environmentsToSpawn[objectIndex], spawnPoint.position, spawnPoint.rotation);
	}
}
