using UnityEngine;
using System.Collections;

public class ShipDeckProgress3 : MonoBehaviour 
	{
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
			if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Underworld_Level3")
			{
				Debug.Log("FROMUNDERWORLD");
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
				GameObject.Find("People").SetActive(false);
				GameObject.Find ("Chef").SetActive(false);
			}
		}
		
		void Update () 
		{
			
		}
		
	}
