using UnityEngine;
using System.Collections;

public class CyclopBedroomProgression : MonoBehaviour 
{
	public AudioSource SFXFire;
	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("LevelTransition").GetComponent<LevelTransition> ().Previous_Level == "CaveTree_CloseUp") {
			GameObject.Find("Player").transform.position = new Vector3 ( 535.445f, 509.943f, 0 );
			GameObject.Find("Player").transform.localScale = new Vector3 ( 1, 1, 1 );
		}
		// Initialisation
		if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().LightedBurntWood == true) {
			SFXFire.Play();
		}
		// Burnt Wood
		GameObject.Find ("BurntWood").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [145];
		// Fire On Wood
		GameObject.Find ("FireOnWood").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [153];
		// Osier bed
		GameObject.Find ("CollisionBox_Bed").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [161];
		// Tree
		GameObject.Find ("CollisionBox_Tree").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [177];
	}
	
	// Update is called once per frame
	void Update () 
	{
		LevelProgress levelProgression = GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ();
		//Got Stack of Cheese
		if(levelProgression.GotAllTheCheese == true)
		{
			if (levelProgression.GetFlint == true)
				GameObject.Find("BurntWood").GetComponent<ObjectInformation>().ObjectID = 30;
			GameObject.Find("BurntWood").GetComponent<Observe>().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader>().Description[146];
			GameObject.Find("Man").transform.position = new Vector3 (1100.0f, 600.0f, 0.0f);
		}
		if(levelProgression.LightedBurntWood == true)
		{
			GameObject.Find("BurntWood").GetComponent<ObjectInformation>().ObjectID = 0;
			GameObject.Find("BurntWood").GetComponent<ClickableObject>().enabled = false;
			GameObject.Find("BurntWood").GetComponent<ClickableObject>().b_Observe = false;
			GameObject.Find("BurntWood").GetComponent<Observe>().enabled = false;
			GameObject.Find("BurntWood").tag = null;
			
			GameObject.Find("BurntWood").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[43];
			
			GameObject.Find("FireOnWood").transform.position = new Vector3 (720.0f, 625.0f, 0.0f);
		}
		if(levelProgression.CyclopLeaveCave == true)
		{
			GameObject.Find("Man").GetComponent<CharacterDialogue>().DialogueID = 7;
			GameObject.Find("Elpenor").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Beardy").GetComponent<SpriteRenderer>().enabled = false;
		}
		if(levelProgression.DeleteTreeBranch == true)
		{
			GameObject.Find("Man").transform.position = new Vector3(3000.0f, 3000.0f, 0.0f);
		}
		if (levelProgression.CyclopsAsleep == true && levelProgression.FinishThinkingOfIdea == false) 
		{
			GameObject.Find("Exit").GetComponent<ExitBox>().ExitID = 6;
		}
		
		if (levelProgression.FinishThinkingOfIdea == true) {
			GameObject.Find("Exit").GetComponent<ExitBox>().ExitID = 7;
		}
		if (levelProgression.GetOsierBands == true) 
		{
			GameObject.Find("cut-bed").GetComponent<SpriteRenderer>().enabled = true;
			if(GameObject.Find("osier-bed"))
			{
				GameObject.Find("osier-bed").SetActive(false);
			}
		}
	}
}
