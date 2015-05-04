using UnityEngine;
using System.Collections;

// Enum to represent the 3 lanes
public enum Position
{
	Top,
	Middle,
	Bottom
};
public class Tree_Controller : MonoBehaviour {
	bool Move;
	public float movement = 3;
	public float max_movement;
	float timer = 0;

	public Position Lane;

	// Use this for initialization
	void Start () {
	
	}

	float AbsValue (float value) {
		if (value < 0)
			return -value;
		else 
			return value;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Continue").GetComponent<TutorialTextScript1> ().Ready == false)
			return;
		if (Random.Range(1,100) == 5 && GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().distance >= 300) {
			Move = true;
			GameObject[] TagObjects = GameObject.FindGameObjectsWithTag ("RunningManTree");
			foreach (GameObject TagObject in TagObjects) {
				if (TagObject.name == this.name || TagObject.transform.position.x == -300)
					continue;
				if ((AbsValue(TagObject.transform.position.x - this.transform.position.x) <= 300) && TagObject.transform.position.x >= transform.position.x) {
					Move = false;
					break;
				}
			}
		}

		if (GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().Hit) {
			movement = 1;
		}

		else if (movement <= 5) { // Until the player speed is back to 5, the tree movement will follow the player's speed. 
			movement = GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().speed;
		}

		timer += Time.deltaTime;
		if (timer > 1) {
			if (GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().speed >= 5) { // Once Running Man's speed reaches 5, allow for increment of movement speed.
				movement += 0.5f;
				if (movement >= max_movement && max_movement != 0) // Limit the movement speed to the max movement speed
					movement = 0;
			}

			if (this.name == "Tree1") {
				if (GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().distance <= 0)
					GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().distance = 0;
				else {
					GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().score += (int)(Mathf.Floor(movement) * 20);
					GameObject.Find("RunningMan").GetComponent<RunningMan_Controller>().distance -= (int)(Mathf.Floor(movement) * 20);
				}
			}
			timer = 0;
		}

		if (Move) {
			this.transform.position = new Vector3 (this.transform.position.x + movement, this.transform.position.y, this.transform.position.z);
			if (this.transform.position.x >= 1400) {
				Move = false;
				this.transform.position = new Vector3 (-300, this.transform.position.y, this.transform.position.z);
			}
		}
		                                   
	}
}
