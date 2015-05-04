using UnityEngine;
using System.Collections;

public class CaveNightLevelProgression : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//Initialisation
		// Brain and Blood
		GameObject.Find("CollisonBox_BrainAndBlood").GetComponent<Observe>().English_Dialogue =  GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[208];
		// Cyclops
		GameObject.Find("Cyclops").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[216];
		// Cyclops_FullyDrunk
		GameObject.Find("CollisionBox").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[226];
		// SheepShit
		GameObject.Find("SheepShit").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[113];
		// Sheep Shit with Stick
		GameObject.Find("SheepShitWithStick").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[121];
		// Slab
		GameObject.Find("slab").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[130];

		LevelProgress levelProgression = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		if(levelProgression.SharpenBranchInShit == true && levelProgression.CyclopsAsleep == false)
		{
			GameObject.Find("SheepShit").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("SheepShitWithStick").GetComponent<SpriteRenderer>().enabled = true;
		}

		if (levelProgression.CyclopsAsleep == true) {
			GameObject.Find("Cyclops").SetActive(false);
			GameObject.Find("Cyclops_FullyDrunk").renderer.enabled = true;
			GameObject.Find("Player").renderer.enabled = true;
			GameObject.Find("Player").GetComponent<Animator>().enabled = true;
			GameObject.Find("Player").GetComponent<PlayerMovement>().Speed = 250;
			GameObject.Find("PlayerImage").renderer.enabled = false;

			//GameObject.Find ("Cyclops_FullyDrunk").GetComponent<Observe>().English_Dialogue = "He's asleep! Now's my chance!";
			GameObject.Find("CollisionBox").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("UsedGoatSkin").GetComponent<SpriteRenderer>().enabled = true;

			GameObject.Find("SheepShit").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("SheepShitWithStick").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("SheepShitWithStick").GetComponent<ClickableObject>().b_PickUp = true;

			GameObject.Find("ExitToBedroom").GetComponent<SpriteRenderer>().enabled = true;
		}

		if (levelProgression.ConversationBetweenCyclops == true) {
			GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(21);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		LevelProgress levelProgression = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		//Got Stack of Cheese
		if(levelProgression.FinishedCyclopsFirstKilling == false)
		{
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(5);
			levelProgression.FinishedCyclopsFirstKilling = true;
			
			//Delete away one feta cheese
			int tempID = 0;
			for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
			{
				int tempStroage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
				if(tempStroage == 16 || tempStroage == 27 || tempStroage == 28)
				{
					tempID = tempStroage;
				}
			}
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
		}
		
		
		if(levelProgression.FinishAllTask_CaveNight == false)
		{
			if(levelProgression.ObserveCyclops == true && levelProgression.ObserveGiantSlab == true && levelProgression.UseSwordOnCyclops == true)
			{
				levelProgression.FinishAllTask_CaveNight = true;
				GameObject.Find ("Man").GetComponent<CharacterDialogue>().DialogueID = 6;
			}
		}

		if (levelProgression.FinishAllTask_CaveNight == true && levelProgression.CyclopsAsleep == false) {
			if(levelProgression.SharpenBranchInShit == true) {
				GameObject.Find("Cyclops").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader>().Description[218];
				if (levelProgression.UseWineOnCyclopsOnce) {
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_CloseUp";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
		}

		if (levelProgression.GetTreeBranchFromShit == true) {
			GameObject.Find("SheepShit").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("SheepShit").GetComponent<ObjectInformation> ().enabled = true;
			GameObject.Find ("SheepShit").GetComponent<ClickableObject> ().enabled = true;
			//GameObject.Find ("SheepShit").GetComponent<Observe> ().enabled = true;
			GameObject.Find("SheepShitWithStick").GetComponent<SpriteRenderer>().enabled = false;
		}
	
	}
}
