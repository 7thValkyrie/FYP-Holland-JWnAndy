using UnityEngine;
using System.Collections;

public class TurnOff_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 6; i++) {
			GameObject.Find("InventoryItem_"+(i+1)).GetComponent<SpriteRenderer>().enabled = false;	
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LateUpdate () {
		if (GameObject.Find("GUITransition").GetComponent<Transition>().isTransition == true) {
			for (int i = 0; i < 6; i++) {
				GameObject.Find("InventoryItem_"+(i+1)).GetComponent<SpriteRenderer>().enabled = true;	
			}
		}
	}
}
