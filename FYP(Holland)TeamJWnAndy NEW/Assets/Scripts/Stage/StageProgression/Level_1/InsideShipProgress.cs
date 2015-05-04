using UnityEngine;
using System.Collections;

public class InsideShipProgress : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		// Initialisation of the Object's values
		// Goatskin
		GameObject.Find ("GoatSkin").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [25];
		// Key
		GameObject.Find ("Key").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [65];
		// Sword
		GameObject.Find ("PlaqueWithSword").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [9];
		// Closet
		GameObject.Find ("Closet").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[73];
		GameObject.Find ("Closet").GetComponent<Interact> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[76];

		//Got Goat Skin
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoatSkin == true)
		{
			Destroy (GameObject.Find ("GoatSkin"));
			if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey == false)
			{
				GameObject.Find("Key").transform.position = new Vector3(1162.0f, 180.0f, 0.0f);
			}
		}
		//Got Key
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetKey == true)
		{
			Destroy (GameObject.Find("Key"));
		}
		//Got Sword
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetSword == true)
		{
			Destroy (GameObject.Find("PlaqueWithSword"));
		}
		//Use Key On Closet
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset == true)
		{
			Sprite sprite;
			sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			GameObject.Find("Closet").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("Closet").GetComponent<Interact>().InteractID = 2;
			GameObject.Find("Closet").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader>().Description[74];
		}
		
		//Got All the Wine
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 == true && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 == true && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 == true && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 == true)
		{
			Sprite sprite;
			sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[18], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			GameObject.Find("Closet").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("Closet").GetComponent<Interact>().InteractID = 2;
			GameObject.Find("Closet").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader>().Description[75];
			//GameObject.Find("Closet").GetComponent<ClickableObject>().b_Interact = false;
			//GameObject.Find("Closet").GetComponent<Interact>().enabled = false;
		}

		//Place player close to the closet
		if(GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ExitFromCloset == true)
		{
			GameObject.Find("Player").transform.position =  new Vector3(420.0f, 380.0f, 0.0f);
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
