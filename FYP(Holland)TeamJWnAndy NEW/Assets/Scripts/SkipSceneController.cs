using UnityEngine;
using System.Collections;

public class SkipSceneController : MonoBehaviour {
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
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ExitFromCloset = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ReachedBeach = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = false;	//Cyclops kills two of the men in the cave
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = false;		//STONE DOOR
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsTwice = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsThird = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdeaForStick = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishTyingSheeps = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishMenEscape = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishHidingInRam = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkingWithCyclopsInRam = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveFireWood = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishCuttingBed = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().StartSharpenMiniGame = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToElpenor = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBush = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetHeatedTreeBranch = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetOsierBands = false;
		GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = false;

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
			TurnBooleanToFalse();
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck";

			break;
		case 2 :
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_OdysseusRoom";
			break;
		case 3 :
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck";
			break;
		case 4 :
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Beach";
			break;
		case 5:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Beach";
			break;
		case 6:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Forest";
			break;
		case 7:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cliff";
			break;
		case 8:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;


			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(44);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cliff";
			break;
		case 9:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Forest";
			break;
		case 10:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "OutsideCave_Enviroment";
			break;
		case 11:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "OutsideCave_Enviroment";
			break;
		case 12:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning";
			break;
		case 13:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(16);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(27);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(28);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning";
			break;
		case 14:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			
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
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 16:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 17:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CaveTree_CloseUp";
			break;
		case 18:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning";
			break;
		case 19:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 20:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(3);

			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 21:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 22:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 23:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(15);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
			break;
		case 24:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
			break;
		case 25:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
			break;
		case 26: 
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetOsierBands = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishCuttingBed = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(12);

			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
			break;
		case 27:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetOsierBands = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishCuttingBed = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishTyingSheeps = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishMenEscape = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishHidingInRam = true;

			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
			break;
		case 28:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSheeps = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlindCyclop = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetOsierBands = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishCuttingBed = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishTyingSheeps = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishMenEscape = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishHidingInRam = true;
			
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
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);

			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "12MenMiniGame";
			break;
		case 2:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().StartSharpenMiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(5);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "SharpenStickMiniGame";
			break;

		case 3:
			TurnBooleanToFalse();
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishGetting12Men = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_1 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_2 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GotAllTheCheese = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToMen = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishedCyclopsFirstKilling = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveBlood = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveGiantSlab = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishAllTask_CaveNight = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ObserveSleepingCyclops = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranchFromShit = true;
			
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(1);
			
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "PokingEyeMiniGame";
			break;

		default:
			return false;
		}

		return true;
	}

	void PrintData () {
		if (b_SkipToScene == true) {
			GameObject.Find ("TextForSkipping").GetComponent<GUIText> ().text = "1: Ships' Deck(Normal) \n" +
				"2: Ship's Room (w/ All item in Inventory) \n" +
				"3: Ship's Deck (w/ Only Chef onboard) \n" +
				"4: Beach (Normal) \n" +
				"5: Beach (w/ Bush Cleared) \n" +
				"6: Forest (Normal) \n" +
				"7: Cliff (Normal) \n" +
				"8: CLiff (w/ Vines Obtained) \n" +
				"9: Forest (w/ Tree path created) \n" +
				"10: Outside Cave (Normal) \n" +
				"11: Outside Cave (Normal + Access to Cave) \n" +
				"12: Cave Morning (Normal) \n" +
				"13: Cave Morning (Normal + 3 Cheese Obtained + Talked to NPC) \n" +
				"14: Cyclops Bedroom (w/ Flint Obtained) \n" +
				"15: Cave Night (Normal) \n" +
				"16: Cyclops Bedroom (Normal - 2nd Day) \n" +
				"17: CaveTree CloseUp (w/Stick) \n" +
				"18: Cave Morning (Normal - 2nd Day w/Stick) \n" +
				"19: Cave Night (Normal - 2nd Day \n" +
				"20: Cave Night (Drunk Scene) \n" +
				"21: Cave Night (Normal - 2nd Day, After Drunk Scene) \n" +
				"22: Cyclops Bedroom (Normal - 2nd Day, After Drunk Scene w/ Stick) \n" +
				"23: Cave Night (Normal - 2nd Day, After Drunk Scene w/Flame Stick) \n" +
				"24: Cave Morning w/Cyclops (Normal) \n" +
				"25: Cave Morning w/Cyclops (Normal + Cleared all Conditions) \n" +
				"26: Cyclops Bedroom (Normal - 2nd Day + Cut out Osier Bands) \n" +
				"27: Cave Morning w/Cyclops (Normal + Player turned into sheep) \n" +
				"28: Beach (2nd Day + Player turned into sheep) \n";
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
				SkipToMiniGame(CurrentInt);
			}

			b_SkipToScene = false;
			b_SkipToMiniGame = false;
		}
	}
}
