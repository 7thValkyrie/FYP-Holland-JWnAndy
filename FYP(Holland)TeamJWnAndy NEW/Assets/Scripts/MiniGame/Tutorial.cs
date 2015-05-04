using UnityEngine;
using System.Collections;

public class TutorialTextScript : MonoBehaviour {
	public GUIStyle style;
	public GUISkin skin;
	public float Dialogue_Width, Dialogue_Height;
	public string Display;
	public bool Ready;
	// Use this for initialization
	void Start () {
		Ready = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("space") == true) {
			Ready = true;
		}
	}
	
	void OnGUI() {
		if (Ready == false) {
			GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Dialogue_Width / 1280.0f * Screen.width,  Dialogue_Height / 720.0f * Screen.height), Display, style);
		}

	}
}
