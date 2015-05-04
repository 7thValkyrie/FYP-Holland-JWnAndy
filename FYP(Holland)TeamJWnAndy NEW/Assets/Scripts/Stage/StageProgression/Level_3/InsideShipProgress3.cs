using UnityEngine;
using System.Collections;

public class InsideShipProgress3 : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		// Initialisation of the Object's values
		// Spear
		//GameObject.Find ("Spear").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [4];
		
		//GameObject.Find("Closet").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[34];
		// Sword
		GameObject.Find ("PlaqueWithSword").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [2];
		
		//Got Sword
		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().GetSword == true)
		{
			Destroy (GameObject.Find("PlaqueWithSword"));
		}
		
		//Got spear
		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().GetSpear == true)
		{
			Destroy (GameObject.Find("Spear"));
		}

		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getanimalgluecrystal == true)
		{
			Destroy (GameObject.Find("Animalgluecrystal"));
		}
		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getbowl == true)
		{
			Destroy (GameObject.Find("Bowl"));
		}
		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getspade == true)
		{
			Destroy (GameObject.Find("Spade"));
		}
		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().Getstick == true)
		{
			Destroy (GameObject.Find("Stick"));
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
