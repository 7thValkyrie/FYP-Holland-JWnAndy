using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < 6; i++) {
		
			Destroy (GameObject.Find("InventoryItem_"+(i+1)));

		}
		if (GameObject.Find ("InventoryBag") != null) {
			Destroy (GameObject.Find ("InventoryBag"));
		}
		if (GameObject.Find ("LevelProgression") != null) {
			Destroy (GameObject.Find ("LevelProgression"));
		}
		if (GameObject.Find ("LevelProgression2") != null) {
			Destroy (GameObject.Find ("LevelProgression2"));
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
