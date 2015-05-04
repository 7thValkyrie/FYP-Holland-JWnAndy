using UnityEngine;
using System.Collections;

public class UnderworldProgression : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GameObject.Find ("Elpenor2").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Elpenor3").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Elpenor4").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Shadow2").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Shadow3").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Shadow4").GetComponent<SpriteRenderer> ().enabled = false;
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
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown("i")) 
		if (GameObject.Find("DialogueBox").GetComponent<DialogueBox>().Activate_Elpenor2 == true)	{
			//GameObject.Find ("Elpenor").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Shadow1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor2").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Shadow2").GetComponent<SpriteRenderer> ().enabled = true;
		}
		if (GameObject.Find("DialogueBox").GetComponent<DialogueBox>().Activate_Elpenor3 == true) {
			//GameObject.Find ("Elpenor1").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Shadow2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Shadow3").GetComponent<SpriteRenderer> ().enabled = true;
		}
		if (GameObject.Find("DialogueBox").GetComponent<DialogueBox>().Activate_Elpenor4 == true) {
			//GameObject.Find ("Elpenor2").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Shadow3").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Elpenor4").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Shadow4").GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
