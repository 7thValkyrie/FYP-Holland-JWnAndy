using UnityEngine;
using System.Collections;

public class BeachProgress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Forest") {
			GameObject.Find("Player").transform.position = new Vector3 ( 946.637f, 381.829f, 0.0f );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}

		if (GameObject.Find ("Bush").GetComponent<SpriteRenderer> ().enabled == true)
			GameObject.Find ("Bush_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [256];
		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().CutDownBush == true) {
			GameObject.Find ("Bush").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find("ExitToForest").GetComponent<ExitBox>().enabled = true;
			GameObject.Find ("Bush_Collision").SetActive(false);
		}
		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishHidingInRam == true) {
			GameObject.Find("Elpenor").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("MasterRam").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("MasterRam").GetComponent<PlayerMovement>().enabled = true;
			GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Shadow").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Shadow_2").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
			GameObject.Find("ExitToDeck").GetComponent<ExitBox>().ExitID = 8;
			GameObject.Find("Tied_Sheeps").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("SheepShadow").GetComponent<SpriteRenderer>().enabled = true;
		}

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishGetting12Men) {
			GameObject.Find("Elpenor").SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (GameObject.Find("LevelProgression").GetComponent<LevelProgress> ().ObserveBush == true) {
//			GameObject.Find("Objective").GetComponent<Objective_Controller>().DisplayObjective(1);
//		}
	}
}
