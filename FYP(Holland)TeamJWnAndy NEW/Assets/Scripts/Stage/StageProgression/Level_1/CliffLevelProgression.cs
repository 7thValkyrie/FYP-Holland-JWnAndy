using UnityEngine;
using System.Collections;

public class CliffLevelProgression : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines == false)
			GameObject.Find ("Vines_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [272];
		else { 
			GameObject.Find("Vines").GetComponent<SpriteRenderer>().enabled = false;

		}
			//GameObject.Find ("Vines_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [273];
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
		if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines == true && GameObject.Find("Vines_Collision"))
			GameObject.Find("Vines_Collision").SetActive(false);
	}
}
