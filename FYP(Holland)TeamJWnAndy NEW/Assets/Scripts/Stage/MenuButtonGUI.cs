using UnityEngine;
using System.Collections;

public class MenuButtonGUI : MonoBehaviour 
{
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiskin;

	public Camera camera;


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
		if(GameObject.Find("DialogueBox").GetComponent<DialogueBox>().enabled == false && GameObject.Find ("PauseScreen").GetComponent<PauseScreen>().enabled == false)
		{
			GUI.skin = guiskin;
			if (camera.aspect > 1.0F && camera.aspect < 1.75f)
			{
				if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width + 20, (this.transform.position.y / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), Button_Name)) 
				{
					GameObject.Find ("PauseScreen").GetComponent<PauseScreen>().enabled = true;
				}
			}
			else if (camera.aspect < 1.8F && camera.aspect > 1.7F)
			{
				if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), Button_Name)) 
				{
					GameObject.Find ("PauseScreen").GetComponent<PauseScreen>().enabled = true;
				}
			}
		}

	}
}
