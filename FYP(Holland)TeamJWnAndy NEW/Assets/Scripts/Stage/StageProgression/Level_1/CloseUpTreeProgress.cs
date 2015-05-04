using UnityEngine;
using System.Collections;

public class CloseUpTreeProgress : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		//Initialisation
		// Tree
		GameObject.Find("CollisionBoxForTree").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [178];
		GameObject.Find("CollisionBoxForTree").GetComponent<Interact>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [180];
		// Tree Branch
		GameObject.Find("TreeBranch").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [185];
		// Stack Of Cheese
		GameObject.Find("StackOfCheese").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[137];

		//Got Stack of Cheese
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetStackCheese_3 == true)
		{
			Destroy (GameObject.Find("StackOfCheese"));
		}
		
		//If Cyclop haven't leave  cave, the tree does show it branches
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopLeaveCave == false)
		{
			Sprite sprite;
			sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			GameObject.Find("Tree").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("CollisionBoxForTree").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [177];
			GameObject.Find("CollisionBoxForTree").GetComponent<ObjectInformation>().ObjectID = 0;
			GameObject.Find("CollisionBoxForTree").GetComponent<Interact>().enabled = false;
			GameObject.Find("CollisionBoxForTree").GetComponent<ClickableObject>().b_Interact = false;
		}

		//Chop tree branch
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch == true)
		{
			Sprite sprite;
			sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			GameObject.Find("Tree").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("CollisionBoxForTree").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [179];
			GameObject.Find("CollisionBoxForTree").GetComponent<ObjectInformation>().ObjectID = 0;
			GameObject.Find("CollisionBoxForTree").GetComponent<Interact>().enabled = false;
			GameObject.Find("CollisionBoxForTree").GetComponent<ClickableObject>().b_Interact = false;

			GameObject.Find("TreeBranch").transform.position = new Vector3(400.0f, 360.0f, 0.0f);
		}
		//Got Tree branch
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetTreeBranch == true)
		{
			Destroy (GameObject.Find("TreeBranch"));
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ChopTreeBranch == true) {
			GameObject.Find("CollisionBoxForTree").GetComponent<ObjectInformation>().ObjectID = 0;
		}

		//if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().StartSharpenMiniGame == true && GameObject.Find("GUITransition").GetComponent<Transition>().isTransition == false) {
			//GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().StartSharpenMiniGame = false;
		//	GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "SharpenStickMiniGame";
		//	GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
		//}

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishThinkingOfIdeaForStick == true && GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == false && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame == false) {
			GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishThinkingOfIdeaForStick = false;
			GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(23);
			
			//Delete away the tree branch
			int tempID = 0;
			for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
			{
				int tempStroage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
				if(tempStroage == 13)
				{
					tempID = tempStroage;
				}
			}
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
		}

		//After sharpen the tree branch
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame == true)
		{
			//If haven't delete the tree branch and add in the polished branch
			if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch == false && GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == false)
			{
				//GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishThinkingOfIdeaForStick = true;
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().DeleteTreeBranch = true;
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(14);
				GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(8);
				for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
				{
					GameObject.Find("InventoryItem_"+i).GetComponent<SpriteRenderer>().enabled = true;
				}
			}
		}
	
	}
}
