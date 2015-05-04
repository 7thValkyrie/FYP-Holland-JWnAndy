using UnityEngine;
using System.Collections;

public class LevelSelect_Level2 : MonoBehaviour 
{
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;
	public AudioSource SFXLevel_2;
	private Rect rect;
	public bool hovered;
	public bool touched;
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
		if (Application.platform == RuntimePlatform.Android) 
		{
			GameObject.Find ("Chapter2_Button").GetComponent<SpriteRenderer> ().enabled = true;
			//Ray ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
			Ray ray1 = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit1;
			if (Physics.Raycast (ray1, out hit1)) 
			{
				//if (Input.GetMouseButtonDown (0)) 
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
				{
					if (hit1.collider.name == "Level2_buttonActivate") 
					{
						if (GameObject.Find ("DropDownMenu").GetComponent<DropDownMenu> ().Droppeddown == true) 
						{
							SFXLevel_2.Play ();
							GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
							GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Chapter2StartCutScene";
							GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level = 2;
						}
					}
				}
			}
						
			
				//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
					//if (Input.GetMouseButtonDown (0)) 
					if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
				{
						if (hit.collider.name == "Level2_button") 
					{
							SetInfo ();
							//hovered = true;
							touched = true;
							//GameObject.Find("DropDownMenu").GetComponent<DropDownMenu>().MoveInfo();
							GameObject.Find ("Level1_buttonActivate").GetComponent<BoxCollider> ().enabled = false;
							GameObject.Find ("Level2_buttonActivate").GetComponent<BoxCollider> ().enabled = true;
							GameObject.Find ("Level1_button").GetComponent<BoxCollider> ().enabled = true;
							GameObject.Find ("Level2_button").GetComponent<BoxCollider> ().enabled = false; 
					}			
				}			
			}

				
		}
	}
	
	void OnGUI ()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
						if (GameObject.Find ("TestGreyout").GetComponent<LevelSelect> ().testgrey >= 2) {
								Dropdown ();
								GUI.skin = guiSkin;
				
								//Set the current level to 2
								if (GUI.Button (rect, "")) {
										SFXLevel_2.Play ();
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Chapter2StartCutScene";
										GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level = 2;
								}
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