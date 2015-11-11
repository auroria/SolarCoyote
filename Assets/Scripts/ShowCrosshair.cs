using UnityEngine;
using System.Collections;

public class ShowCrosshair : MonoBehaviour {
	public Texture2D cursorImage;
	public int cursorWidth = 32;
	public int cursorHeight = 32;
	void Start()
	{
		Cursor.visible = false;
	}
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
	}
}