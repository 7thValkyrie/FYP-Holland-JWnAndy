using UnityEngine;
using System.Collections;

public class ShipDeckProgress : MonoBehaviour 
{
	public Texture2D Background;

	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Beach") {
			GameObject.Find("Player").transform.position = new Vector3 ( 1133.22f, 474.489f, 0.0f );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}

		LevelProgress levelProgress = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		//if (levelProgress.TalkedToElpenor == false) {
		//	GameObject.Find ("Objective").GetComponent<Objective_Controller> ().DisplayObjective (0);
		//}
		//if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetFlint == true) {
		//	Destroy(GameObject.Find("InventoryItem_1"));
		//}

		//Got Flint
		//if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint == false)
		//{
		//	GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetFlint = true;
		//}

		if(levelProgress.GetGoatSkin == true &&  levelProgress.GetKey == true &&  levelProgress.GetWine_1 == true &&  levelProgress.GetWine_2 == true &&  levelProgress.GetWine_3 == true && levelProgress.GetWine_4 == true)
		{
			GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ReachedBeach = true;

			Sprite sprite;
			sprite = Sprite.Create (Background, new Rect(0, 0, Background.width, Background.height), new Vector2 (0.0f, 1.0f), 1.0f);

			GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = sprite;
			Destroy(GameObject.Find("Ladder"));
			GameObject.Find("Exit_ToBeach").transform.position = new Vector3(1107.0f, 607.0f, 0.0f);
			GameObject.Find("Elpenor").SetActive(false);
			GameObject.Find("People").SetActive(false);
		}
		
		GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ExitFromCloset = false;

		if (levelProgress.FinishHidingInRam == true) {
			GameObject.Find("MasterRam").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("MasterRam").GetComponent<PlayerMovement>().enabled = true;
			GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
