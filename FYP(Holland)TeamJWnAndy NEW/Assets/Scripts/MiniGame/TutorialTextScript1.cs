using UnityEngine;
using System.Collections;

public class TutorialTextScript1 : MonoBehaviour {
	public GUIStyle style;
	public GUISkin skin;
	public float Dialogue_Width, Dialogue_Height;
	// For window Editor
	public string English_Display;
	public string Dutch_Display;
	// For Android
	public string English_Display_2;
	public string Dutch_Display_2;

	public bool Ready;


	// Use this for initialization
	void Start () {
		Ready = false;


	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			//arrowkey.GetComponent<SpriteRenderer>().enabled = true;
			//tabletkey.GetComponent<SpriteRenderer>().enabled = false;

			if (Input.GetKeyUp ("space") == true) {
				Ready = true;
			}
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			//tabletkey.GetComponent<SpriteRenderer>().enabled = true;
			//arrowkey.GetComponent<SpriteRenderer>().enabled = false;

			if (Input.touchCount > 0 && Input.touchCount <= 1)
			{
				Ready = true;
			}
		}
	}

	void OnGUI() {
		if (Ready == false) {
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if(PlayerPrefs.GetInt("Language") == 1)
				{
				GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Dialogue_Width / 1280.0f * Screen.width,  Dialogue_Height / 720.0f * Screen.height),English_Display, style);
				}
				else if(PlayerPrefs.GetInt("Language") == 2)
				{
					GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Dialogue_Width / 1280.0f * Screen.width,  Dialogue_Height / 720.0f * Screen.height),Dutch_Display, style);
				}
			}
			else if (Application.platform == RuntimePlatform.Android)
			{
				if(PlayerPrefs.GetInt("Language") == 1)
				{
					GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Dialogue_Width / 1280.0f * Screen.width,  Dialogue_Height / 720.0f * Screen.height),English_Display_2, style);
				}
				else if(PlayerPrefs.GetInt("Language") == 2)
				{
					GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Dialogue_Width / 1280.0f * Screen.width,  Dialogue_Height / 720.0f * Screen.height),Dutch_Display_2, style);
				}
			}
		}
		else {
			GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Instructions").GetComponent<SpriteRenderer>().enabled = false;
			//GameObject.Find("Background").GetComponent<SpriteRenderer>().color = Color.white;
			GUI.enabled = false;
		}
	}
}
