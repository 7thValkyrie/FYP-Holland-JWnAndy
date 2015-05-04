using UnityEngine;
using System.Collections;

public class CliffLevelProgression2Part2 : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GameObject.Find ("Bee_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [53];
		GameObject.Find ("BeeHiveDrop").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [57];
        GameObject.Find("Maze_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[18];
        GameObject.Find("Castle_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[21];

		//Beehive
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().shotBeeHive == true) 
		{
			GameObject.Find ("BeeHive").SetActive (false);
           // GameObject.Find("BeeHive").transform.position = new Vector3(1450.0f, 2500.0f, 0.0f);
			GameObject.Find ("BeeHiveDrop").transform.position = new Vector3 (60.6881f, 267.0f, 0.0f);
			GameObject.Find("BeeHiveImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("BeeHiveDrop").GetComponent<SpriteRenderer>().enabled = true;
			
		}
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetHoneyComb2 == true) 
		{
			GameObject.Find ("BeeHiveDrop").SetActive (false);
		} 
		else if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetHoneyComb == false && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().shotBeeHive == true) 
		{
			GameObject.Find("BeeHiveDrop").GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetHoneyComb == true) 
		{
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(74);
			GameObject.Find ("InventoryBag").GetComponent<Inventory> ().AddItemToInventory (67);
		}
		GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetHoneyComb = false;
	}
}
