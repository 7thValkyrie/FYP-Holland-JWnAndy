using UnityEngine;
using System.Collections;

public class cinematiclanguagecontroller : MonoBehaviour {

	public Texture2D[] CinematicsDialogue = new Texture2D[7];
	public Texture2D[] DutchCinematicsDialogue = new Texture2D[7];
	float time;
	int i;

	// Use this for initialization
	void Start () {
		//this.GetComponent<Animator>().SetInteger("current_lan",PlayerPrefs.GetInt("Language"));
		if (PlayerPrefs.GetInt("Language") == 1)
		{
			GetComponent<SpriteRenderer>().sprite = Sprite.Create(CinematicsDialogue[0], new Rect(0, 0, CinematicsDialogue[i].width, CinematicsDialogue[i].height), new Vector2(0.5f, 0.5f));
		}
		else if (PlayerPrefs.GetInt("Language") == 2)
		{
			GetComponent<SpriteRenderer>().sprite = Sprite.Create(DutchCinematicsDialogue[0], new Rect(0, 0, DutchCinematicsDialogue[i].width, DutchCinematicsDialogue[i].height), new Vector2(0.5f, 0.5f));
		}
 	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (PlayerPrefs.GetInt("Language") == 1)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if(Input.GetKeyDown(KeyCode.Space) || (time > 6.0f))
				{
					if (i < CinematicsDialogue.Length - 1)
					{
						time = 0.0f;
						i += 1;
					}
					
					GetComponent<SpriteRenderer>().sprite = Sprite.Create(CinematicsDialogue[i], new Rect(0, 0, CinematicsDialogue[i].width, CinematicsDialogue[i].height), new Vector2(0.5f, 0.5f));
				}
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				if(((Input.touchCount > 0 && Input.touchCount <= 1)) || (time > 6.0f))
				{
					switch (Input.GetTouch(0).phase)
					{
						case TouchPhase.Began:
						{
							if (i < CinematicsDialogue.Length - 1)
							{
								time = 0.0f;
								i += 1;
							}
						}
						break;
					}
					
					GetComponent<SpriteRenderer>().sprite = Sprite.Create(CinematicsDialogue[i], new Rect(0, 0, CinematicsDialogue[i].width, CinematicsDialogue[i].height), new Vector2(0.5f, 0.5f));
				}
			}
		}
		else if (PlayerPrefs.GetInt("Language") == 2)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if(Input.GetKeyDown(KeyCode.Space) || (time > 6.0f))
				{
					if (i < DutchCinematicsDialogue.Length - 1)
					{
						time = 0.0f;
						i += 1;
					}
					
					GetComponent<SpriteRenderer>().sprite = Sprite.Create(DutchCinematicsDialogue[i], new Rect(0, 0, DutchCinematicsDialogue[i].width, DutchCinematicsDialogue[i].height), new Vector2(0.5f, 0.5f));
				}
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				if(((Input.touchCount > 0 && Input.touchCount <= 1)) || (time > 6.0f))
				{
					switch (Input.GetTouch(0).phase)
					{
						case TouchPhase.Began:
						{
							if (i < DutchCinematicsDialogue.Length - 1)
							{
								time = 0.0f;
								i += 1;
							}
						}
						break;
					}
					
					GetComponent<SpriteRenderer>().sprite = Sprite.Create(DutchCinematicsDialogue[i], new Rect(0, 0, DutchCinematicsDialogue[i].width, DutchCinematicsDialogue[i].height), new Vector2(0.5f, 0.5f));
				}
			}
		}
	}
}
