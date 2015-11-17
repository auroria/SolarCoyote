using UnityEngine;
using System.Collections;

public class Done_HealthBar : MonoBehaviour
{
	public Vector2 pos;
	public Vector2 size;
	
	private Texture2D fullTex;
	public int minHealth, maxHealth;
	private float healthPercent;

	private int playerHealth;
	
	void Start ()
	{
		fullTex = InitFullTex ();
		playerHealth = 100;
		SetCurrentHealth (playerHealth);
	}

	public int getPlayerHealth()
	{
		return playerHealth;
	}
	public void setPlayerHealth (int health)
	{
		playerHealth = health;
	}

	void OnGUI ()
	{
		float widthOfHealthBar = size.x * healthPercent;
		GUI.BeginGroup (new Rect (pos.x, pos.y, widthOfHealthBar, size.y));
		GUI.DrawTexture (new Rect (0, 0, widthOfHealthBar, size.y), fullTex, ScaleMode.StretchToFill);
		GUI.EndGroup ();
	}
	
	public void SetMinMaxHealth (int minHealth, int maxHealth)
	{
		this.minHealth = minHealth;
		this.maxHealth = maxHealth;
	}
	
	public void SetCurrentHealth (int health)
	{
		healthPercent = health / (float)(maxHealth - minHealth);
	}
	
	private Texture2D InitFullTex ()
	{
		
		Texture2D tex = new Texture2D ((int)size.x, (int)size.y);
		Color[] colors = tex.GetPixels ();
		for (int i = 0; i < colors.Length; i++) {
			//Fully red
			colors [i] = Color.red;
		}
		
		tex.SetPixels (colors);
		tex.Apply ();
		return tex;
	}
}