using UnityEngine;
using System.Collections;

public class SetCurrentLevel : MonoBehaviour {

	public int setlevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level = setlevel;

	}
}
