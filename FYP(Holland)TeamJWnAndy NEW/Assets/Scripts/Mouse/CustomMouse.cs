using UnityEngine;
using System.Collections;

public class CustomMouse : MonoBehaviour
{

		public Texture2D cursorImage; //default texture
		public Texture2D itemImage; //item interaction texture
		public Texture2D exitImage; //scene change texture
		public Texture2D talkImage; //character interaction texture
		public Texture2D combineImage; //item combination texture
		private Texture2D curImage;	//current drawn mouse texture

		private int cursorWidth = 32; //cursor size x
		private int cursorHeight = 32; //cursor size y

		public bool hidecursor;
	
		void Start ()
		{
			Screen.showCursor = false; //disable windows cursor
			//curImage = cursorImage; //set drawing texture to default texture
			hidecursor = false;

			if (Application.platform == RuntimePlatform.Android)
			{
				// cursor when in tablet
				hidecursor = true;
			}
		}
	
	
		void OnGUI ()
		{
		if (hidecursor == false) {
			//renders custom mouse
			GUI.DrawTexture (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), curImage);
			//To make the cursor appear on top of every other GUI elements
			GUI.depth = 0;
			}
		}

		void Update ()
		{
						GameObject dialogue = GameObject.Find ("DialogueBox");

						curImage = cursorImage; //sets drawing texture back to default
			
				
				if (GameObject.Find ("DialogueBox") != null && GameObject.Find("PauseScreen").GetComponent<PauseScreen>().enabled == false) {
						if (dialogue.GetComponent<DialogueBox> ().isSetDialogue == false
								&& GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition == false) {
								GameObject[] TagExits = GameObject.FindGameObjectsWithTag ("InteractableExit");
								GameObject[] TagObjects = GameObject.FindGameObjectsWithTag ("InteractableObject");
								GameObject[] TagCharacters = GameObject.FindGameObjectsWithTag ("InteractableCharacter");
								GameObject[] TagItems = GameObject.FindGameObjectsWithTag ("InventoryItem");

								//checks if mouse is over item and change the drawing texture to item
								foreach (GameObject TagObject in TagObjects) {
										if (TagObject.GetComponent<SpriteRenderer> ().enabled == false)
												continue;
                     if (PointToSpriteCollision(Input.mousePosition, Camera.main.WorldToScreenPoint(TagObject.GetComponent<SpriteRenderer>().transform.position), TagObject.GetComponent<SpriteRenderer>().sprite.texture.width / TagObject.GetComponent<ObjectInformation>().NumberOfFrame_X / 1280.0f * Screen.width, TagObject.GetComponent<SpriteRenderer>().sprite.texture.height / 720.0f * Screen.height, TagObject.transform.localScale.x) == true)
					{
						if(GameObject.Find("InventoryBag").GetComponent<Inventory>().isSelected == false)
						{
												curImage = itemImage;
						}
						else
						{
							curImage = combineImage;
						}
					}
								}

								//checks if mouse is over exit and change the drawing texture to exit
								foreach (GameObject TagObject in TagExits) {
										if (TagObject.GetComponent<SpriteRenderer> ().enabled == false || TagObject.GetComponent<ExitBox> ().enabled == false)
												continue;
										if (PointToSpriteCollision (Input.mousePosition, Camera.main.WorldToScreenPoint (TagObject.GetComponent<SpriteRenderer> ().transform.position), TagObject.GetComponent<SpriteRenderer> ().sprite.texture.width / 1280.0f * Screen.width, TagObject.GetComponent<SpriteRenderer> ().sprite.texture.height / 720.0f * Screen.height, TagObject.transform.localScale.x) == true)
												curImage = exitImage;
								}

								//checks if mouse is over characters and change the drawing texture to characters
								foreach (GameObject TagObject in TagCharacters) {
										if (TagObject.GetComponent<SpriteRenderer> ().enabled == false)
											continue;
										if (PointToSpriteCollision (Input.mousePosition, Camera.main.WorldToScreenPoint (TagObject.GetComponent<SpriteRenderer> ().transform.position), TagObject.GetComponent<SpriteRenderer> ().sprite.texture.width / TagObject.GetComponent<CharacterDialogue> ().NumberOfFrame_X / 1280.0f * Screen.width, TagObject.GetComponent<SpriteRenderer> ().sprite.texture.height / 720.0f * Screen.height, TagObject.transform.localScale.x) == true)
												curImage = talkImage;
								}

							foreach (GameObject TagObject in TagItems) {
								if (GameObject.Find ("InventoryBag").GetComponent<Inventory> ().isSelected && TagObject.name != "InventoryItem_"+ GameObject.Find ("InventoryBag").GetComponent<Inventory>().InventoryItemIndex ) {
									if (PointToSpriteCollision (Input.mousePosition, Camera.main.WorldToScreenPoint (TagObject.GetComponent<SpriteRenderer> ().transform.position), TagObject.GetComponent<SpriteRenderer> ().sprite.texture.width / 1280.0f * Screen.width, TagObject.GetComponent<SpriteRenderer> ().sprite.texture.height / 720.0f * Screen.height, TagObject.transform.localScale.x) == true) {
										curImage = combineImage;
									}
								}
							}
						}
				}
			}
	

	bool PointToSpriteCollision (Vector3 pointPosition, Vector3 SpritePosition, float width, float height, float ScaleX)
	{
		if(ScaleX > 0)
		{
			if (pointPosition.x >= (SpritePosition.x ) && pointPosition.x <= (SpritePosition.x + (width*ScaleX)))
			{
				if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
				{
					return true;
				}
			}
		}
		else
		{
			if (pointPosition.x >= (SpritePosition.x- (-width*ScaleX)) && pointPosition.x <= (SpritePosition.x ))
			{
				if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
				{
					return true;
				}
			}
		}
		return false;
	}

}
