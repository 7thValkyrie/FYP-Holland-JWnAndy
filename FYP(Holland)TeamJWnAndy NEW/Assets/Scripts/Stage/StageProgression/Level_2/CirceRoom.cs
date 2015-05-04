using UnityEngine;
using System.Collections;

public class CirceRoom : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().combineMolyWithWine == false) 
		{
			GameObject.Find("CirceEnd_Collision").tag = "Untagged";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
