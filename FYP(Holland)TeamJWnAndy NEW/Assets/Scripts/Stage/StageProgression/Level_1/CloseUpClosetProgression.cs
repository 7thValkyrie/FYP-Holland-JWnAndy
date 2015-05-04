using UnityEngine;
using System.Collections;

public class CloseUpClosetProgression : MonoBehaviour 
{
	CustomMouse custommouse;

	// Use this for initialization
	void Start () 
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			custommouse.hidecursor = true;
		}
		//Initialisation of the Objects 
		GameObject.Find ("BottlesOfWine_1").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [89];
		GameObject.Find ("BottlesOfWine_2").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [89];
		GameObject.Find ("BottlesOfWine_3").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [89];
		GameObject.Find ("BottlesOfWine_4").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [89];
		//Got Wine_1
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_1 == true)
		{
			Destroy (GameObject.Find("BottlesOfWine_1"));
		}
		//Got Wine_2
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_2 == true)
		{
			Destroy (GameObject.Find("BottlesOfWine_2"));
		}
		//Got Wine_3
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_3 == true)
		{
			Destroy (GameObject.Find("BottlesOfWine_3"));
		}
		//Got Wine_4
		if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetWine_4 == true)
		{
			Destroy (GameObject.Find("BottlesOfWine_4"));
		}
		GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ExitFromCloset = true;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
