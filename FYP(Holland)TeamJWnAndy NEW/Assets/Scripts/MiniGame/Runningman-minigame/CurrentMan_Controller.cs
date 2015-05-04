using UnityEngine;
using System.Collections;

public class CurrentMan_Controller : MonoBehaviour {
	public float minX, maxX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// When the game is still on the instruction page, skip all the codes below
		if (GameObject.Find ("Continue").GetComponent<TutorialTextScript1> ().Ready == false)
			return;

		this.transform.position = new Vector3 (minX + ( ((maxX-minX)/GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().max_distance) * GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().distance), 
		                                               this.transform.position.y, this.transform.position.z);
	}
}
