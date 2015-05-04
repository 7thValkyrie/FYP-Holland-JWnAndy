using UnityEngine;
using System.Collections;

public class ShipDeckProgress3Part1 : MonoBehaviour {

	
	public Texture2D Background;

	// Use this for initialization
	void Start () 
	{
		LevelProgress3 levelProgress3 = GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ();
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Ship_OdysseusRoom_Level3")
		{
			Debug.Log("FROMROOM");
			GameObject.Find("Player").transform.position = new Vector3(308.2664f, 366.2987f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(-1, 1, 1);
		}
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Graveyard_Level3")
		{
			GameObject.Find("Player").transform.position = new Vector3(1133.22f, 474.489f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(-1, 1, 1);
		}
		
		if (GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().swordOnCirce == true) 
		{
			GameObject.Find("Eurylochus").GetComponent<SpriteRenderer>().enabled = true;
		}
		
		// Initialisation of the Object's values
		// Bag with thread
		//GameObject.Find ("BagOfThread").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [6];

		
		if(levelProgress3.GetSword == true)
		{
			//Debug.Log ("HELLO");
			GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().reachedhell = true;
			
			Sprite sprite;
			sprite = Sprite.Create (Background, new Rect(0, 0, Background.width, Background.height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = sprite;
			Destroy(GameObject.Find("Ladder"));
			GameObject.Find("Exit_ToBeach").transform.position = new Vector3(1107.0f, 607.0f, 0.0f);
			//GameObject.Find("Elpenor").SetActive(false);
			//GameObject.Find("People").SetActive(false);
		}

		if(levelProgress3.dughole == true)
		{
			Debug.Log ("hi");
			GameObject.Find ("People").transform.localPosition = new Vector3(-118.4608f, 8.81543f, 0.0f);
			GameObject.Find ("People2").transform.localPosition = new Vector3(29.65393f, 9.884216f, 0.0f);
			GameObject.Find ("People3").transform.localPosition = new Vector3(131.7952f, -181.2202f, 0.0f);
			GameObject.Find("Exit_ToBeach").transform.position = new Vector3(1437.0f, 424.0f, 0.0f);
			GameObject.Find ("Chef").SetActive(false);
		}


		for (int i = 0; i < 6; i++)
		{
			GameObject.Find("InventoryItem_" + (i + 1)).GetComponent<SpriteRenderer>().enabled = true;
		}
		
	}
	
	void Update () 
	{
		LevelProgress3 levelProgress3 = GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ();

		if((levelProgress3.trickfirstman == true) && (levelProgress3.tricksecondman == true) && (levelProgress3.trickthirdman == true) && (levelProgress3.trickfourthman == true)
		   && (levelProgress3.trickfifthman == true) && (levelProgress3.tricksixthman == true))
		{
			Debug.Log ("Tricksuccess");
			for (int i = 0; i < 6; i++)
			{
				GameObject.Find("InventoryItem_" + (i + 1)).GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Chapter3ThirdCutScene";
			}
		}
	}
	
}
