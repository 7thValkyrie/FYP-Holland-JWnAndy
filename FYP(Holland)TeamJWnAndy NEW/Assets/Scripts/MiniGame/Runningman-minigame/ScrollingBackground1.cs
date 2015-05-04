using UnityEngine;
using System.Collections;

public class ScrollingBackground1 : MonoBehaviour {
	private float overflow;
	public bool stop = false;
	// Use this for initialization
	void Start () {
		overflow = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.stop == true) {
			return;
		}
		if (GameObject.Find ("Continue").GetComponent<TutorialTextScript1> ().Ready == false)
			return;
		transform.position = new Vector3(transform.position.x + GameObject.Find("Tree1").GetComponent<Tree_Controller>().movement, transform.position.y,0);
		if (transform.position.x >= 1300) 
			//450
		{
			//overflow = transform.position.x - 1500;
			if (this.name == "Background3")
			{
				print ("asd");
				transform.position = new Vector3(GameObject.Find("Background4").transform.position.x-2309 + GameObject.Find("Tree1").GetComponent<Tree_Controller>().movement + overflow, transform.position.y,0);
			}
			else
			{
				transform.position = new Vector3(GameObject.Find("Background3").transform.position.x-2309 + GameObject.Find("Tree1").GetComponent<Tree_Controller>().movement + overflow, transform.position.y,0);
			}
		}
	}
}
