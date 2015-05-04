using UnityEngine;
using System.Collections;

public class OptionMenu_DutchSelection : MonoBehaviour 
{	
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;
	public AudioSource SFXCredit;
	public bool isSelected;
	
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
			//Credit Page Button	
			if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - 150.0f/720.0f*Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), "")) 
			{
				SFXCredit.Play();
				GameObject.Find("Indicator").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find ("Indicator2").GetComponent<SpriteRenderer> ().enabled = true;
				PlayerPrefs.SetInt("Language",2);
			}
			
		}
		else
		{
			//Credit Page Button	
			if (GUI.Button (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - 150.0f/720.0f*Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), "")) 
			{
			}
		}
		
		
	}
}
