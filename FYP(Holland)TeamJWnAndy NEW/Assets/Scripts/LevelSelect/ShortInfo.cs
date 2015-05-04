using UnityEngine;
using System.Collections;

public class ShortInfo : MonoBehaviour {
	public GUIStyle style;
	public GUISkin skin;
	public float Dialogue_Width, Dialogue_Height;
	public string Display;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		style.fontSize = (int)(Screen.width * 0.019);
	}

	void OnGUI() {
		if (GameObject.Find ("DropDownMenu").GetComponent<DropDownMenu> ().drawinfo == true) {
						GUI.Box (new Rect (this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height) * -1, Dialogue_Width / 1280.0f * Screen.width, Dialogue_Height / 720.0f * Screen.height), Display, style);
				}
		}
}
