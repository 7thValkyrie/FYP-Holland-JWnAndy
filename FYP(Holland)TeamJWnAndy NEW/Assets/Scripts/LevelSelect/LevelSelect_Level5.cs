using UnityEngine;
using System.Collections;

public class LevelSelect_Level5 : MonoBehaviour 
{
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;
	public AudioSource SFXLevel_5;
	private Rect rect;
	public bool hovered;
	public Sprite background;
	public string englishshort;
	public string dutchshort;
	public string englishtitle;
	public string dutchtitle;

	// Use this for initialization
	void Start () 
	{
		rect = new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height - 300.0f / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height);
		hovered = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void OnGUI ()
	{
		if (GameObject.Find ("TestGreyout").GetComponent<LevelSelect> ().testgrey >= 5) {
			Dropdown ();
						GUI.skin = guiSkin;
								//Quit Button	
			if (GUI.Button (rect, "")) {
					SFXLevel_5.Play();
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
								}
						}
	}

	void Dropdown()
	{
		Event e = Event.current;
		
		if (rect.Contains (e.mousePosition)) {
			SetInfo();
			hovered = true;
		} else {
			hovered = false;
		}
	}
	
	void SetInfo()
	{
		GameObject.Find ("PlankPicture").GetComponent<SpriteRenderer> ().sprite = background;
		if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 1)
		{
			GameObject.Find ("ShortInfo").GetComponent<ShortInfo> ().Display = englishshort;
			GameObject.Find ("Title").GetComponent<Title> ().Display = englishtitle;
		}
		else if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 2)
		{
			GameObject.Find ("ShortInfo").GetComponent<ShortInfo> ().Display = dutchshort;
			GameObject.Find ("Title").GetComponent<Title> ().Display = dutchtitle;
		}
		
	}

}
