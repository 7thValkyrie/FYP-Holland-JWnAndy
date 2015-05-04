
using UnityEngine;
using System.Collections;

public class CyclopCloseUpProgression : MonoBehaviour {
	// Use this for initialization
	void Start () {
		//Initialisation
		// Cyclops One Third Drunk
		GameObject.Find ("Cyclops_OneThirdDrunk").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [224];
		GameObject.Find ("Cyclops_TwoThirdDrunk").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [225];
		GameObject.Find ("Cyclops_FullyDrunk").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [226];
		GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(10);
		GameObject.Find ("SheepShit").GetComponent<ObjectInformation> ().enabled = false;
		GameObject.Find ("SheepShit").GetComponent<ClickableObject> ().enabled = false;
		GameObject.Find ("SheepShit").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("SheepShit").GetComponent<Observe> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		LevelProgress levelProgression = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		GameObject.Find ("SheepShit").GetComponent<ObjectInformation> ().enabled = false;
		GameObject.Find ("SheepShit").GetComponent<ClickableObject> ().enabled = false;
		GameObject.Find ("SheepShit").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("SheepShit").GetComponent<Observe> ().enabled = false;
		if (levelProgression.ObserveSleepingCyclops == true && GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == false) {
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
		}
		if (levelProgression.UseWineOnCyclopsTwice == true) {
			levelProgression.UseWineOnCyclopsTwice = false;
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(11);
		}
		if (levelProgression.UseWineOnCyclopsThird == true ) {
			levelProgression.UseWineOnCyclopsThird = false;
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(12);
			GameObject.Find ("Cyclops_FullyDrunk").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner[44];
			levelProgression.CyclopsAsleep = true;
		}
		
	}
}