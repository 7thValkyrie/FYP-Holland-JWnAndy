using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour 
{
	public string ButtonText;
	public string English_Dialogue;
	public string Dutch_Dialogue;
	public float Button_Width, Button_Height;
	public GUISkin guiskin;
	private SpriteRenderer spriteRenderer;
	private Vector3 ScreenPosition;
	public int InteractID;
	float f_x, f_y, f_width, f_height;

	private int current_Level;
	void Awake() {
		current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
	}
	// Use this for initialization
	void Start () 
	{
		//Convert World to Screen coordinate
		ScreenPosition = Camera.main.WorldToScreenPoint (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z));
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ScreenPosition = Camera.main.WorldToScreenPoint (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z));
	}	
	
	void OnGUI()
	{		
		if(GameObject.Find ("PauseScreen").GetComponent<PauseScreen>().enabled == true)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		GUI.skin = guiskin;
		//GUI.Button(new Rect((this.transform.position.x), (this.transform.position.y), Button_Width, Button_Height) , ButtonText, "Button");
		//if(GUI.Button (new Rect (ScreenPosition.x - Button_Width/1280.0f/2.0f * Screen.width + spriteRenderer.sprite.texture.width/2.0f /1280.0f * Screen.width, (ScreenPosition.y - Screen.height + Button_Height*2.0f/720.0f * Screen.height) * -1 /*+ spriteRenderer.sprite.texture.height /720.0f * Screen.height + Button_Height*2.0f/720.0f * Screen.height*/, Button_Width/1280.0f * Screen.width, Button_Height/720.0f * Screen.height), ButtonText, "Button")) 
		//if (GUI.Button (new Rect (ScreenPosition.x  - Button_Width / 1280.0f * Screen.width, (ScreenPosition.y - Screen.height + Button_Height/720.0f * Screen.height) * -1 , Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ButtonText, "Button")) 
		float RectLeft = ScreenPosition.x - Button_Width / 1280.0f * Screen.width + spriteRenderer.sprite.texture.width / 2.0f / 1280.0f * Screen.width - GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;
		float RectTop = (ScreenPosition.y - Screen.height + Button_Height/720.0f * Screen.height) * -1;
		float RectWidth = Button_Width / 1280.0f * Screen.width;
		float RectHeight = Button_Height / 720.0f * Screen.height;

		/*
		if(RectTop <= (720.0f - 690.0f)/720.0f*Screen.height)
		{
			RectTop = (((720.0f - 690.0f)/720.0f*Screen.height) - Button_Height/720.0f*1.5f * Screen.height) * -1;
		}
		*/

		if (GUI.Button (new Rect (RectLeft, RectTop, RectWidth, RectHeight), ButtonText, "Button")) 
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().PlayerObjectMovement = false;
			Interaction(InteractID);

            if (GameObject.Find("Exit") != null)
            {
                GameObject.Find("Exit").GetComponent<ExitBox>().CheckButtonIsClicked = true;
            }
		}
		GUI.skin.button.fontSize = (int)(Screen.width*0.01f);


		/*
		//GUI.Button(new Rect (ScreenPosition.x - Button_Width/2.0f, ScreenPosition.y  - (spriteRenderer.sprite.texture.height/4.0f) - Button_Height*1.05f, Button_Width, Button_Height), ButtonText, "Button");
		float Texture_Width_Ratio =spriteRenderer.sprite.texture.width / 2.0f / Screen.width;
		GUI.skin = guiskin;
		GUI.Button(ScreenRect((this.transform.position.x+9.0f)/18.0f, ((-1*this.transform.position.y)+5.0f)/10.0f, Button_Width, Button_Height) , ButtonText, "Button");
		GUI.skin.button.fontSize = (int)(Screen.width*0.03f);
		*/
	}

	void Interaction (int Index)
	{
		if (current_Level == 1) {
						switch (Index) {
						case 1:
				//Display the text store in this class
								GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
								GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = this.English_Dialogue;
								break;
						case 2:
				//Load level "Closet Close Up" 
								GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Closet_CloseUp";
								GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
								break;
						case 3:
				//Load level "Sheep pen Close Up" 
								GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "SheepPen_CloseUp";
								GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
								break;
						case 4:
				//Load level "Cave Tree Close Up" 
								GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CaveTree_CloseUp";
								GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
								break;
						case 5:
				// Men Hiding in the ram and escaping
								if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishTyingSheeps == true && GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled == false && GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishMenEscape == false) {
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue (26);
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishMenEscape = true;
								}
								break;
						case 6:
				// Odyseey hiding in the ram
								if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishMenEscape == true && GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishHidingInRam == false) {
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishHidingInRam = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue (25);
								} else {
										GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
										GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [45];
								}
								break;
						case 7:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkingWithCyclopsInRam = true;
								break;
						default:
								break;
						}
				}
		else if (current_Level == 2) 
		{
			switch (Index) {
			case 1:
				//Display the text store in this class
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = this.English_Dialogue;
				break;
			case 2:
				//Check if there is warm tea, if there is, start circe dialogue
				if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWarmTea == true)
				{
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue (28);
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part2Completed = true;
				}
				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWarmTea == false)
				{
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue (27);
				}
				break;
			case 3:
				//check if both Lion & Wolf is fed
				if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedLion == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedWolf == true )
				{
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Circe_Room";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedLion != true || GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedWolf != true )
				{
					GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
					GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [80];
				}
					
					break;
			default:
				break;
			}	
		}
		else if (current_Level == 3) 
		{
			switch (Index) {
			case 1:
				//Display the text store in this class
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = this.English_Dialogue;
				break;
			default:
				break;
			}
		}
	}

	Rect ScreenRect (float coord_x, float coord_y, float coord_width, float coord_height)
	{
		f_x = coord_x * Screen.width;
		f_y = coord_y * Screen.height;
		f_width = coord_width * Screen.width;
		f_height = coord_height * Screen.height;
		
		return new Rect (f_x, f_y, f_width, f_height);
	}
}
