using UnityEngine;
using System.Collections;

public class OutsideCaveProgress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Cave_Morning") {
			GameObject.Find("Player").transform.position = new Vector3 ( 871.056f, 497.879f, 0 );
			GameObject.Find("Player").transform.localScale = new Vector3 ( -1, 1, 1 );
		}

		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Forest") {
			GameObject.Find("MasterRam").transform.position = new Vector3 ( 262.416f, 286.7973f, 0 );
			GameObject.Find("MasterRam").transform.localScale = new Vector3 ( 0.6212594f, 0.621259f, 1 );
		}
		// Initialisation of Object
		// Sleeping sheep
		GameObject.Find("Sleeping_Sheep").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [97];
		GameObject.Find("CaveEntrance").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [288];
		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishHidingInRam == true) {
			GameObject.Find("sheep-idle-sprite_0").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Sleeping_Sheep").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("MasterRam").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("MasterRam").GetComponent<PlayerMovement>().enabled = true;
			GameObject.Find("RamShadow").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
			GameObject.Find("ExitToBeach").GetComponent<ExitBox>().enabled = true;
		}

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishGetting12Men == true) {
			GameObject.Find("CaveEntrance").SetActive(false);
			GameObject.Find("Exit").GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
