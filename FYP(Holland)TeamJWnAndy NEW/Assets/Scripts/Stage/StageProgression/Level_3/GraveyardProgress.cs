using UnityEngine;
using System.Collections;

public class GraveyardProgress : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(11);
		GameObject.Find("Closet1").GetComponent<SpriteRenderer>().enabled = false;
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Ship_Deck2_Level3")
		{
			Debug.Log ("PreviousShipdeck");
			GameObject.Find("Player").transform.position = new Vector3(635.9985f, 389.1073f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(1, 1, 1);
		}
		
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "River_Level3")
		{
			Debug.Log ("previousriver");
			GameObject.Find("Player").transform.position = new Vector3(988.0263f, 389.1073f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(-1, 1, 1);
		}

		if (GameObject.Find("Closet1").GetComponent<SpriteRenderer>().enabled == true)
		{
			GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().dughole = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
