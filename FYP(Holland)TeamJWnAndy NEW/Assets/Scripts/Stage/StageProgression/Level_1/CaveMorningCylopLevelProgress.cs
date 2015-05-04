using UnityEngine;
using System.Collections;

public class CaveMorningCylopLevelProgress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "Cyclops_Bedroom") {
			GameObject.Find("Player").transform.position = new Vector3 ( 987.478f, 308.329f, 0 );
			GameObject.Find("Player").transform.localScale = new Vector3 ( 1, 1, 1 );
		}
		// Initialisation
		// Cyclops
		GameObject.Find("Cyclops_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[217];
		// Master Ram
		GameObject.Find("Master_Ram_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[232];
		GameObject.Find("Master_Ram_Collision").GetComponent<Interact>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[235];
		// Sheeps
		GameObject.Find("Sheep_collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[240];
		// Tied Sheeps
		GameObject.Find("Tied_Sheeps").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[248];

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishTyingSheeps == true) {
			GameObject.Find ("Elpenor_1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor_2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor_3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Moustache").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Hairy").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Beardy").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Tied_Sheeps").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Sheep_1").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find ("Sheep_2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find ("Sheep_3").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Sheep_collision").GetComponent<SpriteRenderer>().enabled = false;
		}

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishHidingInRam == true) {
			GameObject.Find("Master_Ram_Collision").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("MasterRam").GetComponent<PlayerMovement>().enabled = true;
			GameObject.Find("MasterRam").GetComponent<Animator>().enabled = true;
			GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
			GameObject.Find("Cyclops_Collision").GetComponent<ClickableObject>().b_Interact = true;
			GameObject.Find("Cyclops_Collision").GetComponent<Interact>().enabled = true;
			Animator CyclopsAnimator = GameObject.Find("CyclopsDialogue").GetComponent<Animator> ();
			CyclopsAnimator.SetBool("isInjured",true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkingWithCyclopsInRam == true) {
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue (17);
			GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkingWithCyclopsInRam = false;
		}

		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ObserveSheeps == true && 
		    GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ObserveBlindCyclop == true && 
		    GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan1 == true && 
		    GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan2 == true && 
		    GameObject.Find("LevelProgression").GetComponent<LevelProgress>().TalkedToMan3 == true &&
		    GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea == false) {
			if (GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == false) {
				GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(16);
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea = true;
			}
		}

//		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetOsierBands == true && GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishTyingSheeps == false) {
//			GameObject.Find ("Sheep_1").GetComponent<Observe>().English_Dialogue = "They're so cute, I want to eat them up. Literally.";
//			GameObject.Find ("Sheep_2").GetComponent<Observe>().English_Dialogue = "They're so cute, I want to eat them up. Literally.";
//			GameObject.Find ("Sheep_3").GetComponent<Observe>().English_Dialogue = "They're so cute, I want to eat them up. Literally.";
//		}
	}
}
