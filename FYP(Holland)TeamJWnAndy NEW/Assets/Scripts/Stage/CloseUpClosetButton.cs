using UnityEngine;
using System.Collections;

public class CloseUpClosetButton : MonoBehaviour 
{
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()   
	{
		Event e = Event.current;
		Rect rect = new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height);
		
		if (rect.Contains (e.mousePosition)) {
			GameObject.Find ("CustomMouse").GetComponent<CustomMouse> ().hidecursor = true;
		} else {
			GameObject.Find ("CustomMouse").GetComponent<CustomMouse> ().hidecursor = false;
		}
		
		GUI.skin = guiSkin;
		if (GUI.Button( rect, "")) 
		{
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_OdysseusRoom";
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
		}
	}
}
