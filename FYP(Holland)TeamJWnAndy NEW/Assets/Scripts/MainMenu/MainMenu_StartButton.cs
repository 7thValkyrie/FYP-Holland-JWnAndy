using UnityEngine;
using System.Collections;

public class MainMenu_StartButton : MonoBehaviour 
{
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;
	public AudioSource SFXStart;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void OnGUI ()
	{
		GUI.skin = guiSkin;
		if (GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition == false)
		{
			//Start game Button
			if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), Button_Name)) 
			{
				SFXStart.Play();
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
			}
		}
		else
		{
			if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), Button_Name)) 
			{
			}
		}
	}
}