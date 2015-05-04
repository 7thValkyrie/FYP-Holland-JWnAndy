using UnityEngine;
using System.Collections;

public class plankpicture : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (GameObject.Find ("DropDownMenu").GetComponent<DropDownMenu> ().drawinfo == true) {
						this.GetComponent<SpriteRenderer> ().enabled = true;
				}
		else {
			this.GetComponent<SpriteRenderer> ().enabled = false;
			}
	}
}
