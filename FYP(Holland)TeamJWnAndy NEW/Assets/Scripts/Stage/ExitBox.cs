using UnityEngine;
using System.Collections;

public class ExitBox : MonoBehaviour 
{
	
	public int ExitID;
	public bool isClicked;
	public bool CheckButtonIsClicked;

	private int current_Level;

	void Awake() {
		current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
	}
	// Use this for initialization
	void Start () 
	{
		isClicked = false;
		CheckButtonIsClicked = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputUpdate ();
	}
	
	void InputUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			if(CheckButtonIsClicked == true)
			{
				CheckButtonIsClicked = false;
			}
			else
			{	
				DownInput(Input.mousePosition);
			}
		}
	}
	
	void DownInput(Vector3 pointPosition)
	{
		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableExit");
		foreach(GameObject TagObject in TagObjects)
		{				
			if(PointToSpriteCollision(pointPosition,Camera.main.WorldToScreenPoint (TagObject.GetComponent<SpriteRenderer>().transform.position), TagObject.GetComponent<SpriteRenderer>().sprite.texture.width/1280.0f * Screen.width, TagObject.GetComponent<SpriteRenderer>().sprite.texture.height / 720.0f * Screen.height, TagObject.transform.localScale.x) == true)
			{
				TagObject.GetComponent<ExitBox>().isClicked = true;
			}
			else
			{
				TagObject.GetComponent<ExitBox>().isClicked = false;
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
			if (pointPosition.x >= (SpritePosition.x- (width)) && pointPosition.x <= (SpritePosition.x ))
			{
				if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
				{
					return true;
				}
			}
		}
		return false;
	}

	
	
	public void ChangeScene (int index)
	{
        if (current_Level == 1)
        {
            //GameObject.Find("Objective").GetComponent<Objective_Controller>().StopDisplayObjective();
            switch (index)
            {
                case 1:
                    if (Application.loadedLevelName == "Beach")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Beach";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Ship_Deck";
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    break;
                case 2:
					if (Application.loadedLevelName == "Ship_Deck_Level")
					{
						GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_Deck_Level";
					}
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Ship_OdysseusRoom";
                    break;
                case 3:
                    if (Application.loadedLevelName == "Forest")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Forest";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Beach";
                    break;
                case 4:
                    if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishHidingInRam == true)
                    {
                        GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
                        GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[32];
                    }

                    else
                    {
                        if (Application.loadedLevelName == "SheepPen_CloseUp")
                        {
                            GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "SheepPen_CloseUp";
                        }

                        if (Application.loadedLevelName == "Cyclops_Bedroom")
                        {
                            GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cyclops_Bedroom";
                        }
                        GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                        GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Cave_Morning";
                    }
                    break;
                case 5:
                    if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishTyingSheeps == true)
                    {
                        GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
                        GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[33];
                    }

                    else
                    {
                        if ((GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 == false ||
                            GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 == false ||
                            GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 == false ||
                            GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop == false ||
                             GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps == false) && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops == true)
                        {
                            GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
                            GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[34];
                        }

                        else
                        {
                            if (Application.loadedLevelName == "CaveTree_CloseUp")
                            {
                                GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "CaveTree_CloseUp";
                            }
                            GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                            GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Cyclops_Bedroom";
                        }
                    }
                    break;
                case 6:
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Cave_Night";
                    break;
                case 7:
                    if (Application.loadedLevelName == "Cyclops_Bedroom")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cyclops_Bedroom";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Cave_Morning_Cyclops";
                    break;
                case 8:
                    for (int i = 0; i < 6; i++)
                    {

                        Destroy(GameObject.Find("InventoryItem_" + (i + 1)));

                    }
                    Destroy(GameObject.Find("InventoryBag"));
                    Destroy(GameObject.Find("LevelProgression"));
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Chapter1EndCutscene";
                    break;
                case 9:
                    if (Application.loadedLevelName == "Forest")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Forest";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Beach";
                    break;
                case 10:
                    if (Application.loadedLevelName == "Cave_Morning")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cave_Morning";
                    }

                    if (Application.loadedLevelName == "Forest")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Forest";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "OutsideCave_Enviroment";
                    break;
                case 11:
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Cliff";
                    break;
                case 12:
                    if (Application.loadedLevelName == "OutsideCave_Enviroment")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "OutsideCave_Enviroment";
                    }

                    if (Application.loadedLevelName == "Cliff")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cliff";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Forest";
                    break;
                default:
                    break;
            }
        } // End of the level 1
		else if (current_Level == 3) {
			LevelProgress3 levelProgress3 = GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ();
			switch(index){
			case 1:
				if (Application.loadedLevelName == "Underworld_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Underworld_Level3";
				}
				Debug.Log ("Entered ShipDeck");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Ship_Deck_Level3";
				if (GameObject.Find("DialogueBox").GetComponent<DialogueBox>().Activate_Elpenor4 == true)
				{
					for (int i = 0; i < 6; i++)
					{
						GameObject.Find("InventoryItem_" + (i + 1)).GetComponent<SpriteRenderer>().enabled = false;
						//Destroy(GameObject.Find("InventoryItem_" + (i + 1)));
						GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
						GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Chapter3SecondCutScene";
						
					}
					//GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
					//GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Chapter3SecondCutScene";
				}
				break;
			case 2:
				if (Application.loadedLevelName == "Ship_Deck_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_Deck_Level3";
				}
				Debug.Log ("Entered OdysseusRoom");
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_OdysseusRoom_Level3";
				break;
			case 3:
				if (Application.loadedLevelName == "Ship_Deck_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_Deck_Level3";
				}
				Debug.Log ("Entered Underworld");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Underworld_Level3";
				break;
			case 4:
				if (Application.loadedLevelName == "Ship_Deck2_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_Deck2_Level3";
				}
				Debug.Log ("Entered Graveyard");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Graveyard_Level3";
				break;
			case 8:
				if (Application.loadedLevelName == "Ship_Deck2_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_Deck2_Level3";
				}
				Debug.Log ("Entered OdysseusRoom2");
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_OdysseusRoom2_Level3";
				break;
			case 9:
				if (Application.loadedLevelName == "Ship_OdysseusRoom2_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_OdysseusRoom2_Level3";
				}
				Debug.Log ("Entered ShipDeck2");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Ship_Deck2_Level3";
				break;
			case 5:
				if (Application.loadedLevelName == "Graveyard_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Graveyard_Level3";
				}
				Debug.Log ("Entered River");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "River_Level3";
				break;
			case 6:
				if (Application.loadedLevelName == "Graveyard_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Graveyard_Level3";
				}
				Debug.Log ("Entered Shipdeck2");
				if(levelProgress3.dughole == true)
				{
					for (int i = 0; i < 6; i++)
					{
						GameObject.Find("InventoryItem_" + (i + 1)).GetComponent<SpriteRenderer>().enabled = false;
						GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
						GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "SirenMinigame";
					}
				}
				else
				{
					GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
					GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Ship_Deck2_Level3";
				}
				break;
			case 7:
				if (Application.loadedLevelName == "River_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "River_Level3";
				}
				Debug.Log ("Entered Graveyard");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Graveyard_Level3";
				break;
			case 10:
				/*if(Application.loadedLevelName == "IslandSunShore_Level3")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "IslandSunShore_Level3";
				}*/
				for (int i = 0; i < 6; i++)
				{
					
					Destroy(GameObject.Find("InventoryItem_" + (i + 1)));
					
				}
				Destroy(GameObject.Find("InventoryBag"));
				Destroy(GameObject.Find("LevelProgression"));
				Debug.Log ("Entered Shipdeck to rest");
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Chapter3FinalCutScene";
				break;
		}
		
	}
	else if (current_Level == 2) {
			switch (index) {
			case 1:
                    if (Application.loadedLevelName == "Shore_Level2")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Shore_Level2";
                    }
                    GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
                    GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Ship_Deck_Level2";
                    break;
            case 2:
				if (Application.loadedLevelName == "Ship_Deck_Level2")
				{
					GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Ship_Deck_Level2";
				}
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_OdysseusRoom_Level2";
				break;
			case 3:
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
                

				if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part1Completed == false)
				{
                    if (Application.loadedLevelName == "Cliff_Level2")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cliff_Level2";
                    }
                    if (Application.loadedLevelName == "Clearing_Level2")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Clearing_Level2";
                    }

					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2";
				}
				else if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part1Completed == true)
				{
                    if (Application.loadedLevelName == "Cliff_Level2-2")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cliff_Level2-2";
                    }
                    if (Application.loadedLevelName == "Clearing_Level2-2")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Clearing_Level2-2";
                    }
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-2";
				}
				break;
			case 4:
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part1Completed == false)
				{
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cliff_Level2";
				}
				else if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part1Completed == true)
				{
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cliff_Level2-2";
				}
				break;
			case 5:
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part1Completed == false)
				{
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Clearing_Level2";				
				}
				else if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part1Completed == true)
				{
                    if (Application.loadedLevelName == "Maze-1")
                    {
                        GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Maze-1";
                    }
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Clearing_Level2-2";
				}
				break;

				//Maze 1
			case 6:
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Maze-1";
				break;
				//Maze 2
			case 7:
                if (Application.loadedLevelName == "Maze-1")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Maze-1";
                }
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Maze-2";
				break;

				//Maze 3
			case 8:
                if (Application.loadedLevelName == "Maze-2")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Maze-2";
                }
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Maze-3";
				break;

				//Maze 4
			case 9:
                if (Application.loadedLevelName == "Maze-3")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Maze-3";
                }
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Maze-4";
				break;

				//Maze 5
			case 10:
                if (Application.loadedLevelName == "Maze-4")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Maze-4";
                }
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Maze-5";
				break;

				//Castle front
			case 11:
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CastleFront_Level2";
				break;

				//Shore part 3
			case 12:
                if (Application.loadedLevelName == "Cliff_Level2-3")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Cliff_Level2-3";
                }
                if (Application.loadedLevelName == "Clearing_Level2-3")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "Clearing_Level2-3";
                }
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-3";
				break;

				//Clearing part 3
			case 13:
                if (Application.loadedLevelName == "CastleFront_Level2-3")
                {
                    GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level = "CastleFront_Level2-3";
                }
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Clearing_Level2-3";
				break;

				//Cliff part 3
			case 14:
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cliff_Level2-3";
				break;

				//Castle front part 3
			case 15:
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CastleFront_Level2-3";
				break;
			default:
				break;
			}
		}
	}
}
