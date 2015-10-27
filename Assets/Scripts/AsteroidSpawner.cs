using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject[] asteroids;
	public Vector3 spawnValues;
	public int amountOfAsteroids;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	void Start()
	{
		StartCoroutine(SpawnParticles());
	}
	
	IEnumerator SpawnParticles()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for(int i = 0; i < amountOfAsteroids; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				foreach(var item in asteroids)
				{
					Instantiate(item, spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
