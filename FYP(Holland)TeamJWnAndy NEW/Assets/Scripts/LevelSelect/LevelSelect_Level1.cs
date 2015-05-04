using UnityEngine;
using System.Collections;

public class LevelSelect_Level1 : MonoBehaviour 
{
	public string Button_Name;
	public float Button_Width, Button_Height;
	public GUISkin guiSkin;
	public AudioSource SFXLevel_1;
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
				if (Application.platform == RuntimePlatform.Android) {
						GameObject.Find ("Chapter1_Button").GetComponent<SpriteRenderer> ().enabled = true;
						//Ray ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
						Ray ray1 = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
						RaycastHit hit1;
						if (Physics.Raycast (ray1, out hit1)) {
								if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) { 
			//if (Input.GetMouseButtonDown (0))
										if (hit1.collider.name == "Level1_buttonActivate") {
												if (GameObject.Find ("DropDownMenu").GetComponent<DropDownMenu> ().Droppeddown == true) { 
														SFXLevel_1.Play ();
														GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
														GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Chapter1StartCutScene";
												}
										}
								}
						}
			
						//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit)) { 
								if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) { 
			//if (Input.GetMouseButtonDown (0))
										if (hit.collider.name == "Level1_button") {
												SetInfo ();
												touched = true;
												GameObject.Find ("Level1_buttonActivate").GetComponent<BoxCollider> ().enabled = true;
												GameObject.Find ("Level2_buttonActivate").GetComponent<BoxCollider> ().enabled = false;
												GameObject.Find ("Level1_button").GetComponent<BoxCollider> ().enabled = false;
												GameObject.Find ("Level2_button").GetComponent<BoxCollider> ().enabled = true;
										}
								}
						}
				}
		}

	
	void OnGUI ()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
						if (GameObject.Find ("TestGreyout").GetComponent<LevelSelect> ().testgrey >= 1) {
								Dropdown ();
						
						
								GUI.skin = guiSkin;
								//Quit Button	
								if (GUI.Button (rect, "")) {
										SFXLevel_1.Play ();
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Chapter1StartCutScene";
								}
						}
				}

						

				//if (Application.platform == RuntimePlatform.Android) {
						/*GameObject.Find ("Chapter1_Button").GetComponent<SpriteRenderer> ().enabled = true;
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit)) {
								if (Input.GetMouseButtonDown(0)) {
										if (hit.collider.name == "Level1_button") {
												SetInfo ();
												hovered = true;
												touched = true;
					Debug.Log ("asd");
					print("asd");
												GameObject.Find ("Level1_buttonActivate").GetComponent<BoxCollider> ().enabled = true;
												GameObject.Find ("Level2_buttonActivate").GetComponent<BoxCollider> ().enabled = false;
										}
								}
						}
			Ray ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit1;
						if (Physics.Raycast (ray, out hit1)) {
				if (Input.GetMouseButtonDown(0)) {
										if (hit1.collider.name == "Level1_buttonActivate") {
												hovered = false;
					print("asd");
												SFXLevel_1.Play ();
												GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
												GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Chapter1StartCutScene";
										}
								}
						}*/
				//}
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
		GameObject.Find ("CoinInfo").GetComponent<Title> ().Display = GameObject.Find ("SaveData").GetComponent<SaveData> ().Level1_Coin + " / 3";
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
