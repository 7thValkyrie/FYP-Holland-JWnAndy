using UnityEngine;
using System.Collections;

public class RiverProgression : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
		GameObject.Find("River_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[59];
		
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().killedDeer == false)
		{	
			GameObject.Find("DeadDeer").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find ("Deer_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [12];
		} 
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().killedDeer == true)
		{
			if (GameObject.Find("Deer") != null)
			{
				GameObject.Find("Deer").SetActive(false);
			}
			if (GameObject.Find("DeadDeer") != null)
			{
				GameObject.Find("DeadDeer").SetActive(true);
				GameObject.Find("DeadDeer").GetComponent<SpriteRenderer>().enabled = true;
			}
			GameObject.Find("Deer_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[15];
		}
		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().tiedDeer == true)
		{
			if (GameObject.Find("DeadDeer") != null)
			{
				GameObject.Find("DeadDeer").SetActive(false);
			}
			if (GameObject.Find("Deer") != null)
			{
				GameObject.Find("Deer").SetActive(false);
			}
			//GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[84];
			//GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
