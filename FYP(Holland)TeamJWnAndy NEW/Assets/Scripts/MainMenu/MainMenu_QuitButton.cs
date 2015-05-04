using UnityEngine;
using System.Collections;

public class MainMenu_QuitButton : MonoBehaviour
{
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;
	public AudioSource SFXQuit;
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
			//Quit Button	
			if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - 300.0f/720.0f*Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), "")) 
			{
				SFXQuit.Play();
				Application.Quit();
			}
		}
		else
		{
			//Quit Button	
			if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - 300.0f/720.0f*Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), "")) 
			{
			}
		}
		
		
	}
}
