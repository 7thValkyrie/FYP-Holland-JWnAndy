using UnityEngine;
using System.Collections;

public class Cinematic_Controller : MonoBehaviour {
	protected Animator animator;
	private bool stopper;

	public Texture2D[] Cinematics = new Texture2D[7];
	float time;
	int i;

	// Use this for initialization
	void Start () {
		stopper = false;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			if(Input.GetKeyDown(KeyCode.Space) || (time > 6.0f))
			{
				if (i < Cinematics.Length - 1)
				{
					time = 0.0f;
					i += 1;
				}
				GetComponent<SpriteRenderer>().sprite = Sprite.Create(Cinematics[i], new Rect(0, 0, 1024, 567), new Vector2(0.5f, 0.5f));
				GetComponent<SpriteRenderer>().sprite.name = Cinematics[i].name;
				GetComponent<SpriteRenderer>().transform.localScale = new Vector3(125.0f, 128.0f);
			}
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			if((Input.touchCount > 0 && Input.touchCount <= 1) || (time > 6.0f))
			{
				switch (Input.GetTouch(0).phase)
				{
					case TouchPhase.Began:
					{
						if (i < Cinematics.Length - 1)
						{
							time = 0.0f;
							i += 1;
						}
						GetComponent<SpriteRenderer>().sprite = Sprite.Create(Cinematics[i], new Rect(0, 0, 1024, 567), new Vector2(0.5f, 0.5f));
						GetComponent<SpriteRenderer>().sprite.name = Cinematics[i].name;
						GetComponent<SpriteRenderer>().transform.localScale = new Vector3(125.0f, 128.0f);
					}
					break;
				}
			}
		}

		if (Application.loadedLevel == 10) {
			if (time > 6.0f  || Input.GetKey(KeyCode.Escape))
			{
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7" || Input.GetKey(KeyCode.Escape)) {
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
				else if (Application.platform == RuntimePlatform.Android)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7") {
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
			}
		}

		else if(Application.loadedLevel == 43)
		{
			if (time > 6.0f  || Input.GetKey(KeyCode.Escape))
			{
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer>().sprite.name == "opening_6" || Input.GetKey(KeyCode.Escape)) {
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
				else if (Application.platform == RuntimePlatform.Android)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer>().sprite.name == "opening_6") {
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
			}
		}

		else if (Application.loadedLevel == 9) {
			if (time > 6.0f  || Input.GetKey(KeyCode.Escape))
			{
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "closing 6"  || Input.GetKey(KeyCode.Escape)) 
					{
						if(stopper == false && GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock < 5)
						{
							//GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock++;
							stopper = true;
						}
		                if (GameObject.Find("CoinCounter") != null)
		                {
		                    if (GameObject.Find("CoinCounter").GetComponent<CoinCounter>().level1coincount > GameObject.Find("SaveData").GetComponent<SaveData>().Level1_Coin)
		                    {
		                        PlayerPrefs.SetInt("Level1Coin", GameObject.Find("CoinCounter").GetComponent<CoinCounter>().level1coincount);
		                    }
		                    GameObject.Find("CoinCounter").SetActive(false);
		                }

						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
				else if (Application.platform == RuntimePlatform.Android)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "closing 6") 
					{
						if(stopper == false && GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock < 5)
						{
							//GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock++;
							stopper = true;
						}
						if (GameObject.Find("CoinCounter") != null)
						{
							if (GameObject.Find("CoinCounter").GetComponent<CoinCounter>().level1coincount > GameObject.Find("SaveData").GetComponent<SaveData>().Level1_Coin)
							{
								PlayerPrefs.SetInt("Level1Coin", GameObject.Find("CoinCounter").GetComponent<CoinCounter>().level1coincount);
							}
							GameObject.Find("CoinCounter").SetActive(false);
						}
						
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
					
				}
			}
		}
		
		else if(Application.loadedLevel == 41)
		{
			if (time > 6.0f  || Input.GetKey(KeyCode.Escape))
			{
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "5" || Input.GetKey(KeyCode.Escape)) {
						if(stopper == false && GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock < 5)
						{
							//GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock++;
							stopper = true;
						}
						
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
				else if (Application.platform == RuntimePlatform.Android)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "5") {
						if(stopper == false && GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock < 5)
						{
							//GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock++;
							stopper = true;
						}
						
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
			}
		}
		if (Application.loadedLevel == 45) {
			if (time > 6.0f  || Input.GetKey(KeyCode.Escape))
			{
				//print (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name);
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7" || Input.GetKey(KeyCode.Escape)) {
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level3";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
				else if (Application.platform == RuntimePlatform.Android)
				{
					if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7") {
						GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level3";
						GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					}
				}
			}
		}
		if (Application.loadedLevel == 49)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7" || Input.GetKey(KeyCode.Escape)) {
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck2_Level3";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7") {
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck2_Level3";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
		}

		if (Application.loadedLevel == 54)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7" || Input.GetKey(KeyCode.Escape)) {
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "IslandSunShore_Level3";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7") {
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "IslandSunShore_Level3";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
		}

		
		if (Application.loadedLevel == 56)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7" || Input.GetKey(KeyCode.Escape)) {
					if(stopper == false && GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock < 5)
					{
						//GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock++;
						stopper = true;
					}
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				if (GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite.name == "opening 7") {
					if(stopper == false && GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock < 5)
					{
						//GameObject.Find("SaveData").GetComponent<SaveData>().Level_Unlock++;
						stopper = true;
					}
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "LevelSelect";
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				}
			}
		}
	}
}
