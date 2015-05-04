using UnityEngine;
using System.Collections;

public class Observe : MonoBehaviour 
{
	public string ButtonText;
	public string English_Dialogue;
	public string Dutch_Dialogue;
	public float Button_Width, Button_Height;
	public GUISkin guiskin;
	private SpriteRenderer spriteRenderer;
	private Vector3 ScreenPosition;
	public bool MoveUp;
	
	void Awake() {
	}

	// Use this for initialization
	void Start () 
	{
		//Convert World to Screen coordinate
		ScreenPosition = Camera.main.WorldToScreenPoint (new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z));
		spriteRenderer = GetComponent<SpriteRenderer> ();
		//ScreenPosition = new Vector3 (ScreenPosition.x, -ScreenPosition.y, ScreenPosition.z);
		MoveUp = false;
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
		
		float RectLeft = ScreenPosition.x + spriteRenderer.sprite.texture.width / 2.0f / 1280.0f * Screen.width + GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;
		if (this.GetComponent<ObjectInformation> ().NumberOfFrame_X > 1) 
		{
			RectLeft = ScreenPosition.x + spriteRenderer.sprite.texture.width/this.GetComponent<ObjectInformation> ().NumberOfFrame_X / 2.0f / 1280.0f * Screen.width + GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;
		}
		float RectTop = (ScreenPosition.y - Screen.height + Button_Height/720.0f* Screen.height) * -1;
		//float RectTop = (((720.0f - 690.0f)/720.0f*Screen.height) - Button_Height/720.0f*1.5f * Screen.height) * -1;
		float RectWidth = Button_Width/1280.0f * Screen.width;
		float RectHeight = Button_Height/720.0f * Screen.height;
		
		
		//if(RectTop <= (720.0f - 690.0f)/720.0f*Screen.height)
		//{
		//	RectTop = (((720.0f - 690.0f)/720.0f*Screen.height) - Button_Height/720.0f*1.5f * Screen.height) * -1;
		//}

		if(RectLeft + RectWidth >= Screen.width)
		{
			if(this.GetComponent<ClickableObject>().b_Interact == true)
			{
				RectLeft = ScreenPosition.x - Button_Width / 1280.0f * Screen.width + spriteRenderer.sprite.texture.width / 2.0f / 1280.0f * Screen.width - GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;			
				RectTop = (ScreenPosition.y - Screen.height + Button_Height/720.0f*1.5f * Screen.height) * -1;
				//this.GetComponent<Interact>().MoveDown = true;
			}
			else if(this.GetComponent<ClickableObject>().b_PickUp == true)
			{
				RectLeft = ScreenPosition.x - Button_Width / 1280.0f * Screen.width + spriteRenderer.sprite.texture.width / 2.0f / 1280.0f * Screen.width - GameObject.Find ("OptionPlacement").GetComponent<SpriteRenderer> ().sprite.texture.width / 2.0f / 1280.0f * Screen.width;			
				RectTop = (ScreenPosition.y - Screen.height + Button_Height/720.0f*1.5f * Screen.height) * -1;
				this.GetComponent<PickUp>().MoveDown = true;
			}
		}
		else
		{
			if(this.GetComponent<ClickableObject>().b_Interact == true)
			{
				/*
				if(this.GetComponent<Interact>().MoveDown == true)
				{
					this.GetComponent<Interact>().MoveDown = false;
				}
				*/
			}
			else if(this.GetComponent<ClickableObject>().b_PickUp == true)
			{
				if(this.GetComponent<PickUp>().MoveDown == true)
				{
					this.GetComponent<PickUp>().MoveDown = false;
				}
			}
		}
		if(MoveUp == true)
		{
			RectTop = (ScreenPosition.y - Screen.height + Button_Height/720.0f*1.5f * Screen.height) * -1;
		}

		//If this icon goes out of screen (Height->Top)

		//if (GUI.Button (new Rect (ScreenPosition.x + spriteRenderer.sprite.texture.width/1280.0f * Screen.width,  (ScreenPosition.y - Screen.height + Button_Height/720.0f * Screen.height) * -1 , Button_Width/1280.0f * Screen.width, Button_Height/720.0f * Screen.height), ButtonText, "Button")) 
		if (GUI.Button (new Rect (RectLeft, RectTop, RectWidth, RectHeight), ButtonText, "Button")) 
		{
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = this.English_Dialogue;
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("Player").GetComponent<PlayerMovement>().PlayerObjectMovement = false;

			if(GameObject.Find ("Exit"))
			{
				GameObject.Find ("Exit").GetComponent<ExitBox>().CheckButtonIsClicked = true;
			}
			ObserveProgression(this.GetComponent<ObjectInformation>().ObjectID);
		}
	}
	
	void ObserveProgression (int Index)
	{
		switch(Index)
		{
		case 32:
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			break;
		case 33:
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			break;
		case 34:
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep) {
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			}
			break;
		case 40:
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBush = true;
			break;
		case 45:
			if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese == true)
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveFireWood = true;
			break;
		case 50:
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps = true;
			break;
		case 51:
			if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops == true) {
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop = true;
			}
			break;
		default:
			break;
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
