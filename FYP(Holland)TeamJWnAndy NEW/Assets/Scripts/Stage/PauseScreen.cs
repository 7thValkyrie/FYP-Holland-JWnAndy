using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour 
{
	public Texture Background;
	public float Button_Width, Button_Height;
	public float Resume_Width, Resume_Height;
	public string Button_Name;
	public GUISkin guiSkin;
	public GUISkin guiResume;
	public GUISkin guiMainMenu;
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

		GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Background);
		GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);		
	
		GUI.Label(new Rect(this.transform.position.x*1.1f/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height +  Button_Height/2.5f/ 720.0f * Screen.height - Resume_Height / 720.0f * Screen.height) * -1 , Button_Width / 1280.0f * Screen.width,  Button_Height / 720.0f * Screen.height), "");
		GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Resume_Width / 1280.0f * Screen.width,  Resume_Height / 720.0f * Screen.height), "");
		
		GUI.skin = guiResume;
		//Resume
		if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width + Resume_Width/2.1f / 1280.0f * Screen.width - 262.0f/2.0f / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - Resume_Height/1.5f / 720.0f * Screen.height) * -1, 262.0f / 1280.0f * Screen.width, 72.0f / 720.0f * Screen.height), "")) 
		{
			this.enabled = false;
		}
		GUI.skin = guiMainMenu;
		//Exit
		if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width + Button_Width / 1280.0f * Screen.width/2.0f - 244.0f/3.0f / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - 150.0f/720.0f*Screen.height -  Button_Height *1.5f / 720.0f * Screen.height) * -1, 244.0f / 1280.0f * Screen.width, 105.0f / 720.0f * Screen.height), "")) 
		{
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "MainMenu";
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
		}

	}
}
