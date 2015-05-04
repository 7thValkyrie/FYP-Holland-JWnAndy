
using UnityEngine;
using System.Collections;

public class MiniGameController : MonoBehaviour {

	private bool check;
	public GameObject blackscreen;
	public GameObject bar;
	public GameObject branch;
	public GameObject continue_text;
	public GameObject instructionbackground;
	public GameObject instructioninfo;
	public GameObject instructionpicture;
	public GameObject slider;
	public GameObject sword;
	public GameObject targetbar;
	public GameObject title;
	public GameObject ingameinstruction;
	public GameObject ingameinstructionandroid;

	// Use this for initialization
	void Start () {
		for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
		{
			GameObject.Find("InventoryItem_"+i).GetComponent<SpriteRenderer>().enabled = false;
		}
		check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (check) 
		{
			CheckWinCondition ();
		}
		InputUpdate ();
	}

	void InputUpdate () {
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				ActivateGame();
				DisableInstruction();
			}
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			if ((Input.touchCount > 0 && Input.touchCount <= 1)) 
			{
				ActivateGame();
				DisableInstruction();
			}
		}
	}

	void ActivateGame() {
		check = true;
		blackscreen.GetComponent<SpriteRenderer> ().enabled = false;
		bar.SetActive (true);
		branch.SetActive (true);
		slider.SetActive (true);  
		sword.SetActive (true);
		targetbar.SetActive (true);

		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			ingameinstruction.SetActive (true);
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			ingameinstructionandroid.SetActive (true);
		}
	}

	void DisableInstruction() {
		Destroy (continue_text);
		Destroy (instructionbackground);
		Destroy (instructioninfo);
		Destroy (instructionpicture);
		Destroy (title);
		}

	void CheckWinCondition() {
		if (branch.GetComponent<Animator> ().GetInteger ("branch_state") == 7) {
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().PlayedSharpenWood_MiniGame = true;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().StartSharpenMiniGame = false;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CaveTree_CloseUp";
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			//do whatever you want when you win
		}

	}
}
