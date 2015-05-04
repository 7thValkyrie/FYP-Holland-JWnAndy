using UnityEngine;
using System.Collections;

public class DropDownMenu : MonoBehaviour {

	public bool drawinfo;
	public bool Droppeddown;
	public bool IsUp;

	// Use this for initialization
	void Start () {
	
	}

	/*public void MoveInfo()
	{
		if (Droppeddown == true && transform.position.y <= 870) 
		{
			Droppeddown = false;
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (1400 * Time.deltaTime), this.transform.position.z);
			if (transform.position.y > 1600) {
				this.transform.position = new Vector3 (this.transform.position.x, 1600, this.transform.position.z);
			}
			print ("qwe");
		}
		if (Droppeddown == false) 
		{
			GameObject.Find ("Level_1 Script").GetComponent<LevelSelect_Level1> ().hovered = false;
			GameObject.Find ("Level_2 Script").GetComponent<LevelSelect_Level2> ().hovered = false;
			//if (transform.position.y > 870) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - (1400 * Time.deltaTime), this.transform.position.z);
			//this.transform.position = new Vector3 (this.transform.position.x, 870, this.transform.position.z);
				//drawinfo = false;
				print ("qwe");
			//}
			if(transform.position.y < 870) {
				this.transform.position = new Vector3 (this.transform.position.x, 870, this.transform.position.z);
			}
		}
	}*/
	
	// Update is called once per frame
	void Update () {
//		GameObject[] TagSelect = GameObject.FindGameObjectsWithTag ("Greyout");
//
//		foreach (GameObject TagObject in TagSelect) 
//		{
//			if(TagObject.GetComponentInChildren<level
//		}
		if (Application.platform == RuntimePlatform.Android) {
						if (GameObject.Find ("Level_1 Script").GetComponent<LevelSelect_Level1> ().touched == true ||
								GameObject.Find ("Level_2 Script").GetComponent<LevelSelect_Level2> ().touched == true) {
								this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - (1400 * Time.deltaTime), this.transform.position.z);
								//this.transform.position = new Vector3 (this.transform.position.x, 870, this.transform.position.z);
								if (transform.position.y < 870) {
										this.transform.position = new Vector3 (this.transform.position.x, 870, this.transform.position.z);
										//GameObject.Find ("Level_1 Script").GetComponent<LevelSelect_Level1> ().touched = false;
										//GameObject.Find ("Level_2 Script").GetComponent<LevelSelect_Level2> ().touched = false;
										drawinfo = true;
										Droppeddown = true;
								} 
						}
				}

		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
						if (GameObject.Find ("Level_1 Script").GetComponent<LevelSelect_Level1> ().hovered == true ||
								GameObject.Find ("Level_2 Script").GetComponent<LevelSelect_Level2> ().hovered == true ||
								GameObject.Find ("Level_3 Script").GetComponent<LevelSelect_Level3> ().hovered == true ||
								GameObject.Find ("Level_4 Script").GetComponent<LevelSelect_Level4> ().hovered == true ||
								GameObject.Find ("Level_5 Script").GetComponent<LevelSelect_Level5> ().hovered == true) {


								if (transform.position.y > 870) {
										this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - (1400 * Time.deltaTime), this.transform.position.z);
										//drawinfo = false;
								} else if (transform.position.y < 870) {
										this.transform.position = new Vector3 (this.transform.position.x, 870, this.transform.position.z);
								} else {
										drawinfo = true;
										Droppeddown = true;
								}
						} else {
								drawinfo = false;
								//Droppeddown = false;
								if (transform.position.y < 1600) {
									this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (1400 * Time.deltaTime), this.transform.position.z);
									}
								if (transform.position.y > 1600) {
									this.transform.position = new Vector3 (this.transform.position.x, 1600, this.transform.position.z);
								}
						}
				

		//if(GameObject.Find("Level_2 Script").GetComponent<LevelSelect_Level2>().hovered == true)

		//this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 5, this.transform.position.z);

		}
	}
}
