using UnityEngine;
using System.Collections;

public class ShoreProgression3 : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Cliff_Level2-3")
		{
			GameObject.Find("Player").transform.position = new Vector3(635.9985f, 389.1073f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(1, 1, 1);
		}
		
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Clearing_Level2-3")
		{
			GameObject.Find("Player").transform.position = new Vector3(988.0263f, 389.1073f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(-1, 1, 1);
		}
		
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().part2Completed == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().talkedToEurylochus == false) 
		{
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(73);
			GameObject.Find ("InventoryBag").GetComponent<Inventory> ().AddItemToInventory (11);
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue (29);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
