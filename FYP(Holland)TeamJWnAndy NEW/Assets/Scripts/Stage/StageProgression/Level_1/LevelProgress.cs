using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour 
{
	//Standard variable
	public bool GetLevelProgression;
	public bool GetInventoryBag;

	//Level 1 --------------------------------------------------------------------------------------------------------------------------------------
	//Action Done
	public bool ExitFromCloset;
	public bool UseKeyOnCloset;
	public bool ReachedBeach;
	public bool ChopTreeBranch;
	public bool GotAllTheCheese;
	public bool LightedBurntWood;
	public bool OfferedCheeseToGod;
	public bool OfferedCheeseToMen;
	public bool FinishedCyclopsFirstKilling;	//Cyclops kills two of the men in the cave
	public bool ObserveBlood;
	public bool ObserveCyclops;
	public bool ObserveSleepingCyclops;
	public bool ObserveGiantSlab;		//STONE DOOR
	public bool ObserveSheeps;
	public bool ObserveBlindCyclop;
	public bool UseSwordOnCyclops;
	public bool FinishAllTask_CaveNight;
	public bool CyclopLeaveCave;
	public bool PlayedSharpenWood_MiniGame;
	public bool DeleteTreeBranch;
	public bool SharpenBranchInShit;
	public bool UseWineOnCyclopsOnce;
	public bool UseWineOnCyclopsTwice;
	public bool UseWineOnCyclopsThird;
	public bool CyclopsAsleep;
	public bool ConversationBetweenCyclops;
	public bool TalkedToMan1;
	public bool TalkedToMan2;
	public bool TalkedToMan3;
	public bool FinishThinkingOfIdea;
	public bool FinishThinkingOfIdeaForStick;
	public bool FinishTyingSheeps;
	public bool FinishMenEscape;
	public bool FinishHidingInRam;
	public bool TalkingWithCyclopsInRam;
	public bool CutDownBush;
	public bool CutDownTree;
	public bool ObserveFireWood;
	public bool FinishGetting12Men;
	public bool FinishCuttingBed;
	public bool StartSharpenMiniGame;
	public bool TalkedToElpenor;
	public bool ObserveBush;
	
	
		//Level 1
	//Gotten Object
	public bool GetFlint;
	public bool GetSword;
	public bool GetGoatSkin;
	public bool GetKey;
	public bool GetWine_1;
	public bool GetWine_2;
	public bool GetWine_3;
	public bool GetWine_4;
	public bool GetTreeBranch;
	public bool GetTreeBranchFromShit;
	public bool GetHeatedTreeBranch;
	public bool GetStackCheese_1;
	public bool GetStackCheese_2;
	public bool GetStackCheese_3;
	public bool GetOsierBands;
	public bool GetVines;

	//For Golden Coin
	public bool GetGoldenCoin1;
	public bool GetGoldenCoin2;
	public bool GetGoldenCoin3;
	public bool GetGoldenCoin4;
	public bool GetGoldenCoin5;
	public bool GetGoldenCoin6;
	
	// Use this for initialization
	void Start () 
	{
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetLevelProgression == true)
		{
			Destroy (this.gameObject);
		}
		GetLevelProgression = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
