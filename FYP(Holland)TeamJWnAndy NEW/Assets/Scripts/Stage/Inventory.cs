using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
		private ObjectInformation objectInformation;
		private SpriteRenderer spriteRenderer;
		private string Texture_String;
		private Texture2D TempTexture;
		public int SelectedObjectIndex;
		public int InventoryItemIndex;
		public bool isSelected;
		public int ObjectID;
		private bool CheckInventory;
		public Texture2D[] IconTexture = new Texture2D[200];

		public GUIStyle style;
		public Texture2D hoverbackground;
		public Font hoverfont;

		private int current_Level;
		void Awake() {
			current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
		}
		// Use this for initialization
		void Start ()
		{
				//current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
				SetHoverWordInfo ();
				
				switch (current_Level) 
				{
				case 1:
						if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetInventoryBag == true) {
								Destroy (this.gameObject);
						}
						GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetInventoryBag = true;
						break;  
				case 2:
						if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetInventoryBag == true) {
						Destroy (this.gameObject);
					}
						GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetInventoryBag = true;
						break;
				case 3:
						if (GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().GetInventoryBag == true) {
						Destroy (this.gameObject);
					}
						GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().GetInventoryBag = true;
						break;
				}
				
				//ObjectID = 2;
				isSelected = false;
				SelectedObjectIndex = 0;
				InventoryItemIndex = 0;
				CheckInventory = false;
				/*
		for(int i = 0; i < 6; i++)
		{
			AddItemToInventory(i+1);
		}
		*/
		}

		void SetHoverWordInfo () { 
			style.font = hoverfont; 
			style.normal.background = hoverbackground; 
			style.alignment = TextAnchor.MiddleCenter; 
			style.fontSize = (int)(Screen.width*0.016f); 
			style.normal.textColor = Color.white; 
		}

		// Update is called once per frame
		void Update ()
		{
		SetHoverWordInfo ();
				RearrangeInventory ();
				InputUpdate ();

			//if(GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID == 14)
			//{
			//	PlayerMovement.once = true;
			//}
		}

		void InputUpdate ()
		{
				if (Input.GetMouseButtonDown (0) == true) {
						checkMouseToItem ();
				}
		}

	
		
		void OnGUI ()
		{
			Vector3 MouseWorldPosition;
			MouseWorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            if (GameObject.Find("DialogueBox") != null)
            {
                if (GameObject.Find("DialogueBox").GetComponent<DialogueBox>().enabled == false
                    && GameObject.Find("GUITransition").GetComponent<Transition>().isTransition == false)
                {
                    for (int i = 1; i < ObjectID; i++)
                    {
                        if (GameObject.Find("InventoryItem_" + i) == null)
                        {
                            break;
                        }
                        //Mouse is over Item
                        if (PointToSpriteCollision(MouseWorldPosition, GameObject.Find("InventoryItem_" + i).GetComponent<SpriteRenderer>().transform.position, GameObject.Find("InventoryItem_1").GetComponent<SpriteRenderer>().sprite.texture.width, GameObject.Find("InventoryItem_1").GetComponent<SpriteRenderer>().sprite.texture.height) == true)
                        {

                            Vector2 stringSize = style.CalcSize(new GUIContent(GameObject.Find("InventoryItem_" + i).GetComponent<ObjectInformation>().Name));
                            GUI.Label(new Rect((MouseWorldPosition.x + 60) / 1280.0f * Screen.width, (720.0f - (MouseWorldPosition.y - 6)) / 720.0f * Screen.height, stringSize.x + (6 * GameObject.Find("InventoryItem_" + i).GetComponent<ObjectInformation>().Name.Length / 1280f * Screen.width), stringSize.y + (40 / 720f * Screen.height)),
                                       GameObject.Find("InventoryItem_" + i).GetComponent<ObjectInformation>().Name, style);
                        }
                    }
                }
            }
		}
	


		void checkMouseToItem ()
		{
		float iconHeight = 120.0f;
		float iconWidth = 125.0f;

		Vector3 MouseWorldPosition;
		MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		int DidCollided = 0;
		for(int i = 1; i < ObjectID; i++)
		{
			if(GameObject.Find("DialogueBox").GetComponent<DialogueBox>().enabled == false){
			//Clicked on the Icon
			if(PointToSpriteCollision(MouseWorldPosition, GameObject.Find("InventoryItem_" + i).GetComponent<SpriteRenderer>().transform.position, GameObject.Find("InventoryItem_1").GetComponent<SpriteRenderer>().sprite.texture.width,	GameObject.Find("InventoryItem_1").GetComponent<SpriteRenderer>().sprite.texture.height) == true)
			{
				DidCollided ++;
				//Previous Icon Not Selected
				if(isSelected == false)
				{
					GameObject.Find("SelectedBox").transform.position = new Vector3(GameObject.Find("InventoryItem_"+ i).GetComponent<SpriteRenderer>().transform.position.x + iconWidth/2.0f, GameObject.Find("InventoryItem_"+ i).GetComponent<SpriteRenderer>().transform.position.y - iconHeight/2.0f, GameObject.Find("InventoryItem_"+ i).GetComponent<SpriteRenderer>().transform.position.z);
					SelectedObjectIndex = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
					InventoryItemIndex = i;
					isSelected = true;
					GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = i;
					return;
				}
				//Previous Icon Is Selected
				else 
				{
					CombineList(SelectedObjectIndex, GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID, InventoryItemIndex, i);
					SelectedObjectIndex = 0;
					isSelected = false;
					GameObject.Find("SelectedBox").transform.position = new Vector3(10000.0f, 10000.0f, 10000.0f);
				}
				}
			} 
			//Didn't clicked on the Icon
			else
			{
			}
		}
		//Didn't Click on any Icon
		if(DidCollided == 0)
		{
			//***********************************************************************************************
			// WORKING ICON TO OBJECT 
			//***********************************************************************************************
			/*
			//If Previous Icon is Selected
			if(isSelected == true)
			{
				GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableObject");
				foreach(GameObject TagObject in TagObjects)
				{
					SpriteRenderer tempObjRenderer = TagObject.GetComponent<SpriteRenderer>();
					//If Clicked on a Object
					if(PointToSpriteCollision(MouseWorldPosition, tempObjRenderer.transform.position, tempObjRenderer.sprite.texture.width,	tempObjRenderer.sprite.texture.height) == true)
					{
						CombineListEnviromentItem(GameObject.Find("InventoryItem_"+ InventoryItemIndex).GetComponent<ObjectInformation>().ObjectID, TagObject.GetComponent<ObjectInformation>().ObjectID);                        
					}
				}
			}
			*/
			
			//***********************************************************************************************
			// Testing Code 
			//***********************************************************************************************
			if(isSelected == true)
			{
				GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableObject");
				foreach(GameObject TagObject in TagObjects)
				{
					SpriteRenderer tempObjRenderer = TagObject.GetComponent<SpriteRenderer>();
					//If Clicked on a Object
					if(PointToSpriteCollision(MouseWorldPosition, tempObjRenderer.transform.position, tempObjRenderer.sprite.texture.width,	tempObjRenderer.sprite.texture.height) == true)
					{
							CombineListEnviromentItem(GameObject.Find("InventoryItem_"+ InventoryItemIndex).GetComponent<ObjectInformation>().ObjectID, TagObject.GetComponent<ObjectInformation>().ObjectID);                        
					}
				}
			}


			// Don't touch
			isSelected = false;
			SelectedObjectIndex = 0;

			GameObject.Find("SelectedBox").transform.position = new Vector3(10000.0f, 10000.0f, 10000.0f);
		}
	}


	void CombineList (int index_1, int index_2, int InventoryIndex_1, int InventoryIndex_2)
	{
		//Wine with bag
		if ((index_1 == 2 && index_2 == 6 || index_1 == 6 && index_2 == 2) || (index_1 == 2 && index_2 == 7 || index_1 == 7 && index_2 == 2) || (index_1 == 2 && index_2 == 8 || index_1 == 8 && index_2 == 2) || (index_1 == 2 && index_2 == 9 || index_1 == 9 && index_2 == 2)) {
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
		
						ObjectID -= 2;
						if (ObjectID <= 1) {
								ObjectID = 1;
						}
						if (InventoryIndex_1 > InventoryIndex_2) {
								AddItemToInventory (3, InventoryIndex_2);
						} else {
								AddItemToInventory (3, InventoryIndex_1);
						}

						GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [11];
						GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			
						GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
				} 

		//Wine with bag
		else if ((index_1 == 3 && index_2 == 6 || index_1 == 6 && index_2 == 3) || (index_1 == 3 && index_2 == 7 || index_1 == 7 && index_2 == 3) || (index_1 == 3 && index_2 == 8 || index_1 == 8 && index_2 == 3) || (index_1 == 3 && index_2 == 9 || index_1 == 9 && index_2 == 3)) {
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
						ObjectID -= 2;
						if (ObjectID <= 1) {
								ObjectID = 1;
						}
						if (InventoryIndex_1 > InventoryIndex_2) {
								AddItemToInventory (4, InventoryIndex_2);
						} else {
								AddItemToInventory (4, InventoryIndex_1);
						}
			
						GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [12];
						GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			
						GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
				} 

		//Wine with bag
		else if ((index_1 == 4 && index_2 == 6 || index_1 == 6 && index_2 == 4) || (index_1 == 4 && index_2 == 7 || index_1 == 7 && index_2 == 4) || (index_1 == 4 && index_2 == 8 || index_1 == 8 && index_2 == 4) || (index_1 == 4 && index_2 == 9 || index_1 == 9 && index_2 == 4)) {
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
						ObjectID -= 2;
						if (ObjectID <= 1) {
								ObjectID = 1;
						}
						if (InventoryIndex_1 > InventoryIndex_2) {
								AddItemToInventory (5, InventoryIndex_2);
						} else {
								AddItemToInventory (5, InventoryIndex_1);
						}
			
						GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [13];
						GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			
						GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
				} 

		//Empty bag with wine
		else if ((index_1 == 20 && index_2 == 6 || index_1 == 6 && index_2 == 20) || (index_1 == 20 && index_2 == 7 || index_1 == 7 && index_2 == 20) || (index_1 == 20 && index_2 == 8 || index_1 == 8 && index_2 == 20) || (index_1 == 20 && index_2 == 9 || index_1 == 9 && index_2 == 20)) {
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
						Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
						ObjectID -= 2;
						if (ObjectID <= 1) {
								ObjectID = 1;
						}
						if (InventoryIndex_1 > InventoryIndex_2) {
								AddItemToInventory (2, InventoryIndex_2);
						} else {
								AddItemToInventory (2, InventoryIndex_1);
						}
			
						GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [14];
						GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			
						GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
				} 

		//Grass && Thread combine
		else if ((index_1 == 61 && index_2 == 63) || (index_1 == 63 && index_2 == 61)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (64, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (64, InventoryIndex_1);
			}
			
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [24];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetRope = true;

			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
		}

		//Empty helmet & veil combine
		else if ((index_1 == 67 && index_2 == 75) || (index_1 == 75 && index_2 == 67)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (74, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (74, InventoryIndex_1);
			}
			
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [41];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().helmWithSilk = true;
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
		}
		//Helm with warm water & honeycomb combine
		else if ((index_1 == 71 && index_2 == 68) || (index_1 == 68 && index_2 == 71)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (73, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (73, InventoryIndex_1);
			}
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWarmTea = true;
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
		}

		//Helm with water and honeycomb combine
		else if ((index_1 == 68 && index_2 == 70) || (index_1 == 70 && index_2 == 68)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (72, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (72, InventoryIndex_1);
			}
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
		}

		//Sword with stone combine
		else if ((index_1 == 11 && index_2 == 80) || (index_1 == 80 && index_2 == 11)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (11, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (11, InventoryIndex_1);
			}
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().sharpenSword = true;
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [78];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}

		//moly and wine combine
		else if ((index_1 == 82 && index_2 == 84) || (index_1 == 84 && index_2 == 82)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (84, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (84, InventoryIndex_1);
			}
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().combineMolyWithWine = true;
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [72];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}

		//bowl with water and animal glue crystals combine
		else if ((index_1 == 54 && index_2 == 52) || (index_1 == 52 && index_2 == 54)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (55, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (55, InventoryIndex_1);
			}
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
			GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().combinewaterandunheatedanimalglue = true;
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [72];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}

		//stick and heated animal glue combine
		else if ((index_1 == 57 && index_2 == 56) || (index_1 == 56 && index_2 == 57)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (58, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (58, InventoryIndex_1);
			}
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
			GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().combinestickandheatedanimalglue = true;
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [72];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}

		//spade and stick with heated animal glue combine
		else if ((index_1 == 60 && index_2 == 58) || (index_1 == 58 && index_2 == 60)) 
		{
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_1));
			Destroy (GameObject.Find ("InventoryItem_" + InventoryIndex_2));
			
			ObjectID -= 2;
			if (ObjectID <= 1) 
			{
				ObjectID = 1;
			}
			if (InventoryIndex_1 > InventoryIndex_2) 
			{
				AddItemToInventory (59, InventoryIndex_2);
			} 
			else 
			{
				AddItemToInventory (59, InventoryIndex_1);
			}
			GameObject.Find ("SelectedBox").transform.position = new Vector3 (10000.0f, 10000.0f, 10000.0f);
			GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().combinespadeandstickwithheatedanimalglue = true;
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [72];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}

		else if(index_1 != index_2)
		{
			switch(Random.Range(1,11))
			{
			case 1:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[0];
				break;
			case 2:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[1];
				break;
			case 3:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[2];
				break;
			case 4:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[3];
				break;
			case 5:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[4];
				break;
			case 6:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[5];
				break;
			case 7:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[6];
				break;
			case 8:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[7];
				break;
			case 9:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[8];
				break;
			case 10:
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[9];
				break;
			default:
				break;
			}
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
		}
	}

	public void DestoryItemIcon (int ItemIndex)
	{
		int tempID = 0;
		for(int i = 1; i < ObjectID; i++)
		{
			if(GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID == ItemIndex)
			{
				tempID = i;
			}
		}
		Destroy (GameObject.Find("InventoryItem_"+ tempID));
		ObjectID -= 1;
		CheckInventory = true;
	}

	void CombineListEnviromentItem (int Item_Index, int EnviromentItem_Index)
	{
		if(Item_Index == 10 && EnviromentItem_Index == 17)
		{
			//AddItemToInventory(12, ObjectID);
			
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 11 && EnviromentItem_Index == 26)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 1 && EnviromentItem_Index == 30)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if((Item_Index == 16 && EnviromentItem_Index == 31) || (Item_Index == 27 && EnviromentItem_Index == 31) || (Item_Index == 28 && EnviromentItem_Index == 31))
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 11 && EnviromentItem_Index == 34)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 11 && EnviromentItem_Index == 29 && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea == true)
		{
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishCuttingBed = true;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 11 && EnviromentItem_Index == 40)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 44 && EnviromentItem_Index == 41)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}	
		else if(Item_Index == 11 && EnviromentItem_Index == 42)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 12 && EnviromentItem_Index == 50)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 14 && EnviromentItem_Index == 24)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 14 && EnviromentItem_Index ==34) 
		{
			if ( GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep ) {
				GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
				GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
				GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
			}
		}

		else if (Item_Index == 14 && EnviromentItem_Index == 31) {
			if ( GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep ) {
				GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
				GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
				GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
			}
		}

		else if (Item_Index == 15 && EnviromentItem_Index == 34) {
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 5 && EnviromentItem_Index == 34)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 3 && EnviromentItem_Index == 34)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 2 && EnviromentItem_Index == 34)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 60 && EnviromentItem_Index == 62)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 60 && EnviromentItem_Index == 85)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}

		else if(Item_Index == 60 && EnviromentItem_Index == 86)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}

		else if(Item_Index == 11 && EnviromentItem_Index == 63)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 64 && EnviromentItem_Index == 87)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		else if(Item_Index == 65 && EnviromentItem_Index == 66)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//fill water to helm
		else if(Item_Index == 67 && EnviromentItem_Index == 69)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//remove water from helm
		else if(Item_Index == 70 && EnviromentItem_Index == 69)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//remove hot water from helm
		else if(Item_Index == 71 && EnviromentItem_Index == 69)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Spear with beehive
		else if(Item_Index == 60 && EnviromentItem_Index == 68)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//water with ember
		else if(Item_Index == 70 && EnviromentItem_Index == 76)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//tea with ember
		else if(Item_Index == 72 && EnviromentItem_Index == 76)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Meat with lion
		else if(Item_Index == 81 && EnviromentItem_Index == 52)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Meat with wolf
		else if(Item_Index == 81 && EnviromentItem_Index == 53)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Sword with circe
		else if(Item_Index == 11 && EnviromentItem_Index == 83)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Bowl with river
		else if(Item_Index == 53 && EnviromentItem_Index == 351)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Bowl with water with river
		else if(Item_Index == 54 && EnviromentItem_Index == 351)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}
		//Animal glue with firepit
		else if(Item_Index == 55 && EnviromentItem_Index == 352)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
		}

		else if (Item_Index == 59 &&  EnviromentItem_Index == 100) 
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemIconIndex = Item_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().ClickedItemEnviromentIndex = EnviromentItem_Index;
			GameObject.Find("Player").GetComponent<PlayerMovement>().isClickedItemIcon_Enviroment = true;
			GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().dughole = true;
		}
	}

	bool PointToSpriteCollision (Vector3 pointPosition, Vector3 SpritePosition, float width, float height)
	{
		if (pointPosition.x >= (SpritePosition.x ) && pointPosition.x <= (SpritePosition.x + (width)))
		{
			if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
			{
				return true;
			}
		}
		return false;
	}

	public void AddItemToInventory(int ItemIndex)
	{
		Sprite sprite;
		GameObject tempGameObject;
		switch(ObjectID)
		{
		case 1:
			
			sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);

			tempGameObject = new GameObject("InventoryItem_" + ObjectID);
			tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
			tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
			tempGameObject.AddComponent<SaveObject>();
			tempGameObject.transform.position = new Vector3 (43.0f, 133.0f, 0.0f);
			tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
			tempGameObject.tag = "InventoryItem";
			ObjectID ++;
			break;
		case 2:
			
			sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			
			tempGameObject = new GameObject("InventoryItem_" + ObjectID);
			tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
			tempGameObject.transform.position = new Vector3 (201.0f, 133.0f, 0.0f);
			tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
			tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
			tempGameObject.AddComponent<SaveObject>();
			tempGameObject.tag = "InventoryItem";
			ObjectID ++;
			break;
		case 3:
			
			sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			
			tempGameObject = new GameObject("InventoryItem_" + ObjectID);
			tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
			tempGameObject.transform.position = new Vector3 (360.0f, 133.0f, 0.0f);
			tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
			tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
			tempGameObject.AddComponent<SaveObject>();
			tempGameObject.tag = "InventoryItem";
			ObjectID ++;
			break;
		case 4:
			
			sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			
			tempGameObject = new GameObject("InventoryItem_" + ObjectID);
			tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
			tempGameObject.transform.position = new Vector3 (519.0f, 133.0f, 0.0f);
			tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
			tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
			tempGameObject.AddComponent<SaveObject>();
			tempGameObject.tag = "InventoryItem";
			ObjectID ++;
			break;
		case 5:
			
			sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			
			tempGameObject = new GameObject("InventoryItem_" + ObjectID);
			tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
			tempGameObject.transform.position = new Vector3 (676.0f, 133.0f, 0.0f);
			tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
			tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
			tempGameObject.AddComponent<SaveObject>();
			tempGameObject.tag = "InventoryItem";
			ObjectID ++;
			break;
		case 6:
			
			sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			
			tempGameObject = new GameObject("InventoryItem_" + ObjectID);
			tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
			tempGameObject.transform.position = new Vector3 (835.0f, 133.0f, 0.0f);
			tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
			tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
			tempGameObject.AddComponent<SaveObject>();
			tempGameObject.tag = "InventoryItem";
			ObjectID ++;
			break;
		default:
			break;
		}
	}
	
	public void AddItemToInventory(int ItemIndex, int InventoryIndex)
	{
		Sprite sprite;
		GameObject tempGameObject;
		
		sprite = Sprite.Create (IconTexture[ItemIndex-1], new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
		
		tempGameObject = new GameObject("InventoryItem_" + InventoryIndex);
		tempGameObject.AddComponent<SpriteRenderer>().sprite = sprite;
		tempGameObject.AddComponent<ObjectInformation>().ObjectID = ItemIndex;
		tempGameObject.AddComponent<SaveObject>();
		tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
		tempGameObject.tag = "InventoryItem";
		ObjectID ++;
		
		switch(InventoryIndex)
		{
		case 1:
			tempGameObject.transform.position = new Vector3 (43.0f, 133.0f, 0.0f);
			break;
		case 2:
			tempGameObject.transform.position = new Vector3 (201.0f, 133.0f, 0.0f);
			break;
		case 3:
			tempGameObject.transform.position = new Vector3 (360.0f, 133.0f, 0.0f);
			break;
		case 4:
			tempGameObject.transform.position = new Vector3 (519.0f, 133.0f, 0.0f);
			break;
		case 5:
			tempGameObject.transform.position = new Vector3 (676.0f, 133.0f, 0.0f);
			break;
		case 6:
			tempGameObject.transform.position = new Vector3 (835.0f, 133.0f, 0.0f);
			break;
		default:
			break;
		}
		CheckInventory = true;
	}

	void RearrangeInventory ()
	{
		bool isNull = false;

		if(CheckInventory == true)
		{
			for(int i = 1; i < ObjectID; i++)
			{
				if(isNull == true)
				{
					GameObject tempGameObject = new GameObject("InventoryItem_" + i);
					
					tempGameObject.AddComponent<SpriteRenderer>().sprite = GameObject.Find("InventoryItem_" + (i+1)).GetComponent<SpriteRenderer>().sprite;
					tempGameObject.AddComponent<ObjectInformation>().ObjectID = GameObject.Find("InventoryItem_" + (i+1)).GetComponent<ObjectInformation>().ObjectID;
					tempGameObject.AddComponent<SaveObject>();
					tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
					tempGameObject.transform.position = SetIconPosition(i);
					
					Destroy (GameObject.Find("InventoryItem_"+ (i+1)));
				}
				else if(GameObject.Find("InventoryItem_" + i) == null)
				{
					GameObject tempGameObject = new GameObject("InventoryItem_" + i);

					tempGameObject.AddComponent<SpriteRenderer>().sprite = GameObject.Find("InventoryItem_" + (i+1)).GetComponent<SpriteRenderer>().sprite;
					tempGameObject.AddComponent<ObjectInformation>().ObjectID = GameObject.Find("InventoryItem_" + (i+1)).GetComponent<ObjectInformation>().ObjectID;
					tempGameObject.AddComponent<SaveObject>();
					tempGameObject.GetComponent<SpriteRenderer> ().renderer.sortingOrder = 11;
					tempGameObject.transform.position = SetIconPosition(i);

					Destroy (GameObject.Find("InventoryItem_"+ (i+1)));
					isNull = true;
				}
			}
			CheckInventory = false;
		}
	}

	Vector3 SetIconPosition (int Index)
	{
		Vector3 tempVector;
		tempVector = new Vector3 (0.0f, 0.0f, 0.0f);

		if(Index == 1)
		{
			tempVector = new Vector3 (43.0f, 133.0f, 0.0f);
		}
		else if(Index == 2)
		{
			tempVector = new Vector3 (201.0f, 133.0f, 0.0f);
		}
		else if(Index == 3)
		{
			tempVector = new Vector3 (360.0f, 133.0f, 0.0f);
		}
		else if(Index == 4)
		{
			tempVector = new Vector3 (519.0f, 133.0f, 0.0f);
		}
		else if(Index == 5)
		{
			tempVector = new Vector3 (676.0f, 133.0f, 0.0f);
		}
		else if(Index == 6)
		{
			tempVector = new Vector3 (835.0f, 133.0f, 0.0f);
		}
		return tempVector;
	}
}
