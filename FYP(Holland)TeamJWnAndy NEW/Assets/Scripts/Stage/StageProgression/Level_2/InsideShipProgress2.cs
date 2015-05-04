using UnityEngine;
using System.Collections;

public class InsideShipProgress2 : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		// Initialisation of the Object's values
		// Spear
		GameObject.Find ("Spear").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [4];

        GameObject.Find("Closet").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[34];
		// Sword
		GameObject.Find ("PlaqueWithSword").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [2];

		//Got Sword
		if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSword == true)
		{
			Destroy (GameObject.Find("PlaqueWithSword"));
		}

		//Got spear
		if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetSpear == true)
		{
			Destroy (GameObject.Find("Spear"));
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
