using UnityEngine;
using System.Collections;

public class TutorialTextScript2 : MonoBehaviour {
	public GUIStyle style;
	public GUISkin skin;
	public float Dialogue_Width, Dialogue_Height;
	// For window editor
	public string English_Display;
	public string Dutch_Display;
	// For android
	public string English_Display_2;
	public string Dutch_Display_2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (PlayerPrefs.GetInt ("Language") == 1) 
			{
				GUI.Box (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Dialogue_Width / 1280.0f * Screen.width, Dialogue_Height / 720.0f * Screen.height), English_Display, style);
			} 
			else if (PlayerPrefs.GetInt ("Language") == 2) 
			{
				GUI.Box (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Dialogue_Width / 1280.0f * Screen.width, Dialogue_Height / 720.0f * Screen.height), Dutch_Display, style);
			}
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			if (PlayerPrefs.GetInt ("Language") == 1) 
			{
				GUI.Box (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Dialogue_Width / 1280.0f * Screen.width, Dialogue_Height / 720.0f * Screen.height), English_Display_2, style);
			} 
			else if (PlayerPrefs.GetInt ("Language") == 2) 
			{
				GUI.Box (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Dialogue_Width / 1280.0f * Screen.width, Dialogue_Height / 720.0f * Screen.height), Dutch_Display_2, style);
			}
		}
	}
}
