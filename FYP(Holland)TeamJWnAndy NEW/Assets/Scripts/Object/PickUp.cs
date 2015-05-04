using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
	PlayerMovement playermovement;

	public string ButtonText;
	public string English_Dialogue;
	public string Dutch_Dialogue;
	public float Button_Width, Button_Height;
	public GUISkin guiskin;
	private SpriteRenderer spriteRenderer;
	private Vector3 ScreenPosition;
	public bool MoveDown;

	private int current_Level;
	void Awake() {
		current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
	}
	// Use this for initialization
	void Start () 
	{
		//Convert World to Screen coordinate
		ScreenPosition = Camera.main.WorldToScreenPoint (new Vector3 (this.transform.position.x, -1.0f*this.transform.position.y, this.transform.position.z));
		spriteRenderer = GetComponent<SpriteRenderer> ();
		MoveDown = false;
		//ScreenPosition = new Vector3 (ScreenPosition.x, -ScreenPosition.y, ScreenPosition.z);
		playermovement = GetComponent<PlayerMovement>();
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
		GUI.skin.button.fontSize = (int)(Screen.width*0.01f);
		//GUI.Button(new Rect (ScreenPosition.x - (spriteRenderer.sprite.texture.width / SpritePerRow / 4.0f) - Button_Width, ScreenPosition.y  - (spriteRenderer.sprite.texture.height / SpritePerColumn / 4.0f), Button_Width, Button_Height), ButtonText, "Button");
		//if (GUI.Button (new Rect (ScreenPosition.x  - Button_Width / 1280.0f * Screen.width, (ScreenPosition.y - Screen.height + Button_Height/720.0f * Screen.height) * -1 , Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ButtonText, "Button")) 
		float RectLeft = ScreenPosition.x - Button_Width / 1280.0f * Screen.width + spriteRenderer.sprite.texture.width / 2.0f / 1280.0f * Screen.width - GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;
		float RectTop = (ScreenPosition.y - Screen.height + Button_Height/720.0f * Screen.height) * -1;
		float RectWidth = Button_Width / 1280.0f * Screen.width;
		float RectHeight = Button_Height / 720.0f * Screen.height;

		if(RectLeft <= 0)
		{
			RectLeft = ScreenPosition.x + spriteRenderer.sprite.texture.width / 2.0f / 1280.0f * Screen.width + GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;
			RectTop = (ScreenPosition.y - Screen.height + Button_Height/2.0f /720.0f * Screen.height) * -1;
			this.GetComponent<Observe>().MoveUp = true;
		}
		else if(this.GetComponent<Observe>().MoveUp == true)
		{
			this.GetComponent<Observe>().MoveUp = false;
		}

		if(MoveDown == true)
		{
			RectTop = (ScreenPosition.y - Screen.height + Button_Height/2.0f /720.0f * Screen.height) * -1;
		}
		
		/*
		if(RectTop <= (720.0f - 690.0f)/720.0f*Screen.height)
		{
			RectTop = (((720.0f - 690.0f)/720.0f*Screen.height) - Button_Height/720.0f*1.5f * Screen.height) * -1;
		}
*/
		if (GUI.Button (new Rect (RectLeft, RectTop, RectWidth, RectHeight), ButtonText)) 
		//if (GUI.Button (new Rect (ScreenPosition.x + spriteRenderer.sprite.texture.width/2.0f/1280.0f * Screen.width - GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().sprite.texture.width/2.0f/1280.0f*Screen.width, (ScreenPosition.y - Screen.height + Button_Height/720.0f * Screen.height) * -1 , Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ButtonText, "Button")) 
		{
			if(GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID >= 7)
			{
				GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[41];
			}
			else 
			{
				//if (GetComponent<ObjectInformation>().ObjectID == 14)
					//PlayerMovement.once = true;

				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(GetComponent<ObjectInformation>().ObjectID);
				SetLevelProgress(GetComponent<ObjectInformation>().ObjectID);
				this.transform.position = new Vector3 (10000.0f, 10000.0f, 0.0f);
			}
			GameObject.Find("Player").GetComponent<PlayerMovement>().PlayerObjectMovement = false;

            if (GameObject.Find("Exit") != null)
            {
                GameObject.Find("Exit").GetComponent<ExitBox>().CheckButtonIsClicked = true;
            }
		}
		//GUI.Button(new Rect (ScreenPosition.x , ScreenPosition.y, Button_Width, Button_Height), ButtonText, "Button");
	}

	void SetLevelProgress (int ObjectID)
	{
		//Chapter 1
		if (current_Level == 1) {
						switch (ObjectID) {
						case 6:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetWine_1 = true;
								break;
						case 7:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetWine_2 = true;
								break;
						case 8:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetWine_3 = true;
								break;
						case 9:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetWine_4 = true;
								break;
						case 10:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetKey = true;
								break;
						case 11:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetSword = true;
								break;
						case 13:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetTreeBranch = true;
				//GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishThinkingOfIdeaForStick = true;
				//GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(20);
								GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
								GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [42];
								break;
						case 14:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetTreeBranchFromShit = true;
								break;
						case 16:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetStackCheese_1 = true;
								break;
						case 20:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetGoatSkin = true;
								GameObject.Find ("Key").transform.position = new Vector3 (1162.0f, 370.0f, 0.0f);
								GameObject.Find ("Key").GetComponent<ObjectMovement> ().enabled = true;
								break;
						case 27:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetStackCheese_2 = true;
								break;
						case 28:
								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetStackCheese_3 = true;
								break;
						default:
								break;
						}
				}
		//Chapter 3
		else if (current_Level == 3) {
						switch (ObjectID) {

						case 11:
								GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().GetSword = true;
								break;
						case 52:
								GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getanimalgluecrystal = true;
								break;
						case 53:
								GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getbowl = true;
								break;
						case 54:
								GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getbowlwithwater = true;
								break;
						case 60:
								GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getspade = true;
								break;
						case 57:
								GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getstick = true;
								break;
						
						}


		}

		//Chapter 2
		else if(current_Level == 2)
		{
			switch(ObjectID)
			{
			case 11:
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
				break;
			
			case 60:
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
				break;

			case 61:
				GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [7];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				break;
			case 75:
				GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
				break;


			case 68:
				GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
				GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb = true;
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [64];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				break;
           

            case 73:
                GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = true;
                GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[82];
                GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
                break;

			case 80:
				GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStone = true;
				GameObject.Find("BlingBling").SetActive(false);
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [83];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				break;
			case 84:
				GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWine = true;
				break;

			}
		}
	}

	Rect ScreenRect (float coord_x, float coord_y, float coord_width, float coord_height)
	{
		float f_x, f_y, f_width, f_height;
		
		f_x = coord_x * Screen.width;
		f_y = coord_y * Screen.height;
		f_width = coord_width * Screen.width;
		f_height = coord_height * Screen.height;

		return new Rect (f_x, f_y, f_width, f_height);
	}
}
