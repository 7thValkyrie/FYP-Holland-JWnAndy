using UnityEngine;
using System.Collections;

public class SkipSceneController2 : MonoBehaviour {
	public int Current_Scene = 1;
	public int Previous_Scene = 1;

	private string StringHolder = "0";
	private int CurrentInt = 0;

	private bool b_SkipToScene = false;
	private bool b_SkipToMiniGame = false;

	public bool Initialised;
	// Use this for initialization
	void Start () {
		if(GameObject.Find("SkipScenesController").GetComponent<SkipSceneController>().Initialised == true)
		{
			Destroy (this.gameObject);
			Destroy (GameObject.Find("TextForSkipping"));
			Destroy (GameObject.Find("TextForSkippingInput"));
			Destroy (GameObject.Find("BlackScreenForText"));
		}
		Initialised = true;
	}

	void TurnBooleanToFalse () {
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToEurylochus = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().sharpenSword = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().feedLion = false;	//Cyclops kills two of the men in the cave
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().feedWolf = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToHermes = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().combineMolyWithWine = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().swordOnCirce = false;		//STONE DOOR
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part2Completed = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ArmWrestlingCompleted = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStone = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVenison = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetMoly = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine = false;
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = false;

		for (int i = 0; i < 6; i++) {
			if (GameObject.Find("InventoryItem_"+(i+1)) == null) {
				break;
			}
			Destroy (GameObject.Find("InventoryItem_"+(i+1)));
		}
		GameObject.Find ("InventoryBag").GetComponent<Inventory> ().ObjectID = 1;
	}

	bool SkipToScene (int SkipNumber) {
		switch (SkipNumber) {
		case 1 :
			//start game
			TurnBooleanToFalse();
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
			break;
		case 2 :
			//collect spear and sword in odysseus room
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(60);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_OdysseusRoom_Level2";
			break;
		case 3 :
			//collect spear, sword and thread, location shore
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(60);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(61);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2";
			break;
		case 4 :
			//killed deer, sword and thread in inventory, location clearing
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			//GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			//GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(61);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(64);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Clearing_Level2";
			break;
		case 5:
			//sword and deer in inventory, location ship deck
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(65);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
			break;
		case 6:
			//start of part 2
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(67);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(60);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-2";
			break;
		case 7:
			//eurylochus at castle front with veil in inventory
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(67);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(60);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(75);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CastleFront_Level2";
			break;
		case 8:
			//honeycomb in inventory, location cliff
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;


			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(68);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(67);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cliff_Level2-2";
			break;
		case 9:
			//castle front with tea
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;
			
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(73);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CastleFront_Level2";
			break;
		case 10:
			//start of part 3
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToEurylochus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part2Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;
			

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-3";
			break;
		case 11:
			//sharpened sword and talked to hermes, location shore
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToEurylochus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().sharpenSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToHermes = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part2Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStone = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetMoly = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;

			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(82);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-3";
			break;
		case 12:
			//castle front, fed lion and wolf
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToEurylochus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().sharpenSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().feedLion = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().feedWolf = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToHermes = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part2Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStone = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVenison = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetMoly = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(82);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CastleFront_Level2-3";
			break;
		case 13:
			//before using sword on circe
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().helmWithSilk = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToEurylochus = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().sharpenSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().feedLion = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().feedWolf = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToHermes = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().combineMolyWithWine = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part2Completed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetRope  = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetHoneyComb2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWarmTea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStone = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVenison = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetMoly = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(84);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Circe_Room";
			break;
		/*case 14:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(16);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(27);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(28);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 15:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 16:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 17:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CaveTree_CloseUp";
			break;
		case 18:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning";
			break;
		case 19:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 20:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(3);

			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 21:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 22:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 23:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(15);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 24:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ConversationBetweenCyclops = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
			break;
		case 25:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSheeps = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlindCyclop = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
			break;
		case 26: 
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSheeps = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlindCyclop = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetOsierBands = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishCuttingBed = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(12);

			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 27:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSheeps = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlindCyclop = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetOsierBands = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishCuttingBed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishTyingSheeps = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishMenEscape = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishHidingInRam = true;

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
			break;
		case 28:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSheeps = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlindCyclop = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetOsierBands = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishCuttingBed = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishTyingSheeps = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishMenEscape = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishHidingInRam = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Beach";
			break;
		
		default :
			return false;
		}

		return true;
	}

	bool SkipToMiniGame (int SkipNumber) {
		switch (SkipNumber) {
		case 1:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);

			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "12MenMiniGame";
			break;
		case 2:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().StartSharpenMiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "SharpenStickMiniGame";
			break;

		case 3:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoatSkin = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetKey = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetWine_4 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownBush = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CutDownTree = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVines = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetFlint = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().LightedBurntWood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveBlood = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranch = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetTreeBranchFromShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "PokingEyeMiniGame";
		*/	break;

		default:
			return false;
		}

		return true;
	}

	void PrintData () {
		if (b_SkipToScene == true) {
			GameObject.Find ("TextForSkipping").GetComponent<GUIText> ().text = 
				"1: Ships' Deck(Normal) \n" +
				"2: Odysseus room(w/ spear and sword in inventory) \n" +
				"3: Shore (w/ spear, sword and thread) \n" +
				"4: Clearing (w/ deer killed, sword and thread in inventory) \n" +
				"5: Ships' Deck (w/ sword and deer in inventory) \n" +
				"6: Shore (Normal (part 2)) \n" +
				"7: Castle Front (w/ veil in inventory (part 2)) \n" +
				"8: Cliff (w/ honeycomb in inventory (part 2)) \n" +
				"9: Castle front (w/ Tea in inventory (part 2)) \n" +
				"10: Shore (Normal (part 3)) \n" +
				"11: Shore (w/ sharpened sword and talked to hermes (part 3)) \n" +
				"12: Castle front (w/ wolf and lion fed (part 3)) \n" +
				"13: Circe room (before using sword on circe (part 3) \n";
		}

		if (b_SkipToMiniGame) {
			GameObject.Find ("TextForSkipping").GetComponent<GUIText> ().text = "1: Mini Game 1 (12 Men) \n" +
				"2: Mini Game 2 (Sharpening Stick) \n" +
				"3: Mini Game 3 (Poking Eye) \n";
		}
	}
	
	// Update is called once per frame
	void Update () {
        //if (StringHolder != "") {
        //    //Debug.Log (StringHolder);
        //}
		if (Input.GetKey(KeyCode.S)) {
			GameObject.Find("BlackScreenForText").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("TextForSkippingInput").GetComponent<GUIText>().enabled = true;
			b_SkipToScene = true;
			PrintData();
			if (Input.inputString != "s" && Input.inputString != "") {
				bool isDigit = char.IsDigit(Input.inputString[0]);
				if (isDigit == true) {
					if (StringHolder == "0") {
						StringHolder = "";
					}
					StringHolder += Input.inputString;
					GameObject.Find("TextForSkippingInput").GetComponent<GUIText>().text = "Skip to Scene \n" + StringHolder.ToString();
				}
			}
		}

		else if (Input.GetKey(KeyCode.M)) {
			GameObject.Find("BlackScreenForText").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("TextForSkippingInput").GetComponent<GUIText>().enabled = true;
			b_SkipToMiniGame = true;
			PrintData();
			if (Input.inputString != "m" && Input.inputString != "") {
				bool isDigit = char.IsDigit(Input.inputString[0]);
				if (isDigit == true) {
					if (StringHolder == "0") {
						StringHolder = "";
					}
					StringHolder += Input.inputString;
					GameObject.Find("TextForSkippingInput").GetComponent<GUIText>().text = "Skip to Scene \n" + StringHolder.ToString();
				}
			}
		}

		else {
			GameObject.Find("BlackScreenForText").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("TextForSkipping").GetComponent<GUIText>().text = "";
			GameObject.Find("TextForSkippingInput").GetComponent<GUIText>().text = "Skip to Scene";
			GameObject.Find("TextForSkippingInput").GetComponent<GUIText>().enabled = false;
			CurrentInt = int.Parse(StringHolder.ToString());
			StringHolder = "0";
			if (b_SkipToScene == true) {
				SkipToScene(CurrentInt);
			}

			if (b_SkipToMiniGame == true) {
			//	SkipToMiniGame(CurrentInt);
			}

			b_SkipToScene = false;
			b_SkipToMiniGame = false;
		}
	}
}
