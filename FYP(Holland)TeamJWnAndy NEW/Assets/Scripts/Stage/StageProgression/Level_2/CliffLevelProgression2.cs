using UnityEngine;
using System.Collections;

public class CliffLevelProgression2 : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

        GameObject.Find("Bee_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[53];
		GameObject.Find("Maze_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[18];
		GameObject.Find("Castle_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[21];

		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().killedDeer == false && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().tiedDeer == false)
		{
			GameObject.Find ("DeadDeer_Collision").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find ("Deer_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [22];
		} 
		else if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().killedDeer == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().tiedDeer == false)
		{
            if (GameObject.Find("Deer") != null)
            {
                GameObject.Find("Deer").SetActive(false);
            }
            if (GameObject.Find("DeadDeer") != null)
            {
                GameObject.Find("DeadDeer").GetComponent<SpriteRenderer>().enabled = true;
            }
            if (GameObject.Find("DeerDeer_Collision") != null)
            {
                GameObject.Find("DeadDeer_Collision").GetComponent<SpriteRenderer>().enabled = true;
            }
            if (GameObject.Find("Deer_Collision") != null)
            {
                GameObject.Find("Deer_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[15];
            }
		}

		if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().tiedDeer == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().killedDeer == true) 
		{
            if (GameObject.Find("DeadDeer") != null)
            {
                GameObject.Find("DeadDeer").GetComponent<SpriteRenderer>().enabled = false;
            }
            if (GameObject.Find("Deer") != null)
            {
                GameObject.Find("Deer").SetActive(false);
            }
            if (GameObject.Find("Deer_Collision") != null)
            {
                GameObject.Find("Deer_Collision").GetComponent<SpriteRenderer>().enabled = false;
            }
            if (GameObject.Find("DeadDeer_Collision") != null)
            {
                GameObject.Find("DeadDeer_Collision").GetComponent<SpriteRenderer>().enabled = false;
            }
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}