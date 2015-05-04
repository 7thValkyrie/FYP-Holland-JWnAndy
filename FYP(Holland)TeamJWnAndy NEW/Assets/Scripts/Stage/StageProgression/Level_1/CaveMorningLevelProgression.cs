using UnityEngine;
using System.Collections;

public class CaveMorningLevelProgression : MonoBehaviour 
{
	public Texture2D background1;
	public Texture2D background2;
	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "SheepPen_CloseUp") {
			GameObject.Find("Player").transform.position = new Vector3 ( 830.330f, 497.905f, 0 );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}

		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Cyclops_Bedroom") {
			GameObject.Find("Player").transform.position = new Vector3 ( 987.478f, 308.329f, 0 );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}
		// Initialisation
		// Sheep Pen
		GameObject.Find ("sheep-in-pen").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[105];
		GameObject.Find("SheepShit").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[113];
		GameObject.Find("slab").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[129];
		GameObject.Find("StackOfCheese").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[137];
		// Sheep Shit with Stick
		GameObject.Find("SheepShitWithStick").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[121];

		LevelProgress levelProgression = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		//Got Stack of Cheese
		if(levelProgression.GetStackCheese_1 == true)
		{
			Destroy (GameObject.Find("StackOfCheese"));
		}

		//Got all the Cheese
		if(levelProgression.GetStackCheese_1 == true && levelProgression.GetStackCheese_2 == true && levelProgression.GetStackCheese_3 == true)
		{
			//GameObject.Find("Elpenor_Clone").GetComponent<CharacterDialogue>().DialogueID = 3;
			GameObject.Find("Elpenor").GetComponent<CharacterDialogue>().DialogueID = 3;
		}
		if(levelProgression.SharpenBranchInShit == true)
		{
			//Sprite sprite;
			//sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[35], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[35].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[35].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			//GameObject.Find("SheepShit").GetComponent<SpriteRenderer>().sprite = sprite;
			//GameObject.Find("SheepShit").GetComponent<Observe>().English_Dialogue = "Hehehehe! He will not know where i place the stick!";
			GameObject.Find("SheepShit").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("SheepShitWithStick").GetComponent<SpriteRenderer>().enabled = true;
		}

		if (levelProgression.CyclopLeaveCave == true) {
			Sprite sprite;
			sprite = Sprite.Create (background2, new Rect(0, 0, background2.width, background2.height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("slab_closed").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("slab").SetActive(false);
			GameObject.Find("Elpenor").SetActive(false);
			GameObject.Find("ExitToCave").GetComponent<ExitBox>().enabled = false;
		}
		/*
		if(levelProgression.CyclopLeaveCave == true)
		{
			GameObject.Find("Elpenor").transform.position = new Vector3 (3000.0f, 3000.0f, 3000.0f);
			GameObject.Find("slab").transform.position = new Vector3 (250.0f, 666.0f, 0.0f);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
