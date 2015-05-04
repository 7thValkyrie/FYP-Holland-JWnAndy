using UnityEngine;
using System.Collections;

public class CastleFrontProgression : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
        if (GameObject.Find("Circe_Collision") != null)
        {
            GameObject.Find("Circe_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[68];
        }
		GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().mazeCompleted = true;
        if (GameObject.Find("Veil") != null)
        {
            GameObject.Find("Veil").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[63];
        }

		//Got veil
		if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetVeil == true)
		{
			Destroy (GameObject.Find("Veil"));
		}

			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
