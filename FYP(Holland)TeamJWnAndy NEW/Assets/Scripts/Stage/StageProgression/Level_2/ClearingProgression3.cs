﻿using UnityEngine;
using System.Collections;

public class ClearingProgression3 : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find("LevelTransition").GetComponent<LevelTransition>().Previous_Level == "CastleFront_Level2-3")
		{
			GameObject.Find("Player").transform.position = new Vector3(700.564f, 380.0f, 0.0f);
			GameObject.Find("Player").transform.localScale = new Vector3(1, 1, 1);
		}
		//Got stone
		if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetStone == true)
		{
			GameObject.Find("BlingBling").SetActive(false);
			Destroy (GameObject.Find("River_Collision"));
		}
		
		GameObject.Find ("River_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [59];
		
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().mazeCompleted == true) 
		{
            if (GameObject.Find("ExitToMaze") != null)
            {
                GameObject.Find("ExitToMaze").SetActive(false);
            }

			GameObject.Find ("ExitToCastle").SetActive (true);
		} 
		else if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().mazeCompleted == false) 
		{
			GameObject.Find ("ExitToMaze").SetActive (true);
			GameObject.Find ("ExitToCastle").SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
