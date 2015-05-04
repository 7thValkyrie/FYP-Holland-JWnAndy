using UnityEngine;
using System.Collections;

public class ForestLevelProgression : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Cliff") {
			GameObject.Find("Player").transform.position = new Vector3 ( 1163.77f, 348.202f, 0.0f );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}

		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "OutsideCave_Enviroment") {
			GameObject.Find("Player").transform.position = new Vector3 ( 812.057f, 395.596f, 0.0f );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}

		if (GameObject.Find ("Dead_Tree").GetComponent<SpriteRenderer> ().enabled == true) {
			GameObject.Find ("Dead_Tree_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[264];
		}

		GameObject.Find ("River").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[280];

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().CutDownTree == true) {
			GameObject.Find("Dead_Tree").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Dead_Tree_Collision").SetActive(false);
			GameObject.Find("Fallen_Tree").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("ExitToCave").GetComponent<ExitBox>().enabled = true;
		}

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishHidingInRam == true) {
			GameObject.Find("MasterRam").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("MasterRam").GetComponent<PlayerMovement>().enabled = true;
			GameObject.Find("Shadow_2").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Shadow").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
