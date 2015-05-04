using UnityEngine;
using System.Collections;

public class IslandSunShoreProgress : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
		GameObject.Find("Closet1").GetComponent<SpriteRenderer>().enabled = false;

		for (int i = 0; i < 6; i++)
		{
			GameObject.Find("InventoryItem_" + (i + 1)).GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		LevelProgress3 levelProgress3 = GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ();
		
		if((levelProgress3.talkfirstman == true) && (levelProgress3.talksecondman == true))
		{
			GameObject.Find("Exit_to_deck").transform.position = new Vector3(1.753586f, 466.2748f, 0.0f);
		}
	}
}
