using UnityEngine;
using System.Collections;

public class ShipDeckProgress2 : MonoBehaviour 
{
	public Texture2D Background;
	
	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Shore_Level2")
		{
			GameObject.Find("Player").transform.position = new Vector3(1133.22f, 474.489f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(-1, 1, 1);
		}
		
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().swordOnCirce == true) 
		{
			GameObject.Find("Eurylochus").GetComponent<SpriteRenderer>().enabled = true;
		}
		
		// Initialisation of the Object's values
		// Bag with thread
		GameObject.Find ("BagOfThread").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [6];
		
		//Got thread
		if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetThread == true)
		{
			Destroy (GameObject.Find("BagOfThread"));
		}
		//Dead deer
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().tiedDeer == false) 
		{
			GameObject.Find("ChefEnding").SetActive(false);
		}
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().tiedDeer == true) 
		{
			GameObject.Find("Chef").SetActive(false);
			GameObject.Find("ChefEnding").SetActive(true);
		}
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().swordOnCirce == true) 
		{
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(35);
		}
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().ArmWrestlingCompleted == true)
		{
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(36);
		}

	}
	
	void Update () 
	{
		
	}
	
}

