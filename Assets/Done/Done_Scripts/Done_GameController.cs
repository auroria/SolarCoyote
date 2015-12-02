using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float changeLevelAtScore = 500.0f;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private static int score = 0;
	int beginningScore;
	
	void Start ()
	{
		beginningScore = score;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel ("Done_Main");
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		if (score-beginningScore >= changeLevelAtScore) 
		{
			//yield return new WaitForSeconds(5);
			if(Application.loadedLevelName=="Done_Main")
            {
				Application.LoadLevel("Done_Scene1");

			}
			else if(Application.loadedLevelName == "Done_Scene1")
            {
				Application.LoadLevel("Done_Scene2");
			}
            else if (Application.loadedLevelName == "Done_Scene2")
            {
                Application.LoadLevel("Done_Scene3");
            }
            else if (Application.loadedLevelName == "Done_Scene3")
            {
                Application.LoadLevel("Done_Scene4");
            }
            else
            {
                Application.LoadLevel("Done_Main");
            }
        }
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}