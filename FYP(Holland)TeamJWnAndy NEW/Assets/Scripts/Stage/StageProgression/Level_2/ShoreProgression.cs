using UnityEngine;
using System.Collections;

public class ShoreProgression : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Cliff_Level2")
		{
			GameObject.Find("Player").transform.position = new Vector3(635.9985f, 389.1073f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(1, 1, 1);
		}
		
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "Clearing_Level2")
		{
			GameObject.Find("Player").transform.position = new Vector3(988.0263f, 389.1073f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(-1, 1, 1);
		}
		
		if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass == false)
		{
			GameObject.Find("Grass_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[9];
		}
		if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass == true)
		{
			GameObject.Find("Grass").SetActive(false);
		}
		if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer == true)
		{
			
		}
		//	if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetRope == true) 
		//		{
		//
		//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

