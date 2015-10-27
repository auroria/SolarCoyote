using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
	public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject[] pickUp;                // The enemy prefab to be spawned.
	public float maxSpawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	
	
	void Start ()
	{
		//int spawnTime = Random.Range (0, (int)maxSpawnTime);
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", 0, maxSpawnTime);
	}
	
	
	void Spawn ()
	{
		// If the player has no health left...
		if(playerHealth.currentHealth <= 0f)
		{
			// ... exit the function.
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		int objectIndex = Random.Range (0, pickUp.Length);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (pickUp[objectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
