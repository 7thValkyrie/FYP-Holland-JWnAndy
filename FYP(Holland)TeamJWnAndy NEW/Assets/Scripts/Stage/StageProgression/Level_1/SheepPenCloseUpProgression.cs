using UnityEngine;
using System.Collections;

public class SheepPenCloseUpProgression : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		// Initialisation of Objects
		// Cheese
		GameObject.Find ("StackOfCheese").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [137];
		// Sheep pens
		GameObject.Find ("SheepPen").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [106];
		LevelProgress levelProgression = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		//Got Stack of Cheese
		if (levelProgression.GetStackCheese_2 == true) {
			Destroy (GameObject.Find ("StackOfCheese"));
		} 
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
