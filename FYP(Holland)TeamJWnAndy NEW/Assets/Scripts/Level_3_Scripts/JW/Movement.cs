using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public bool PlayMove = false;
	Vector3 MPosition;
	Vector3 travelDir;
	Vector3 LastMPosition;
	float MovementSpeed = 100.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonUp(0))
			//PlayMove = false; //call this loop once
		
		if (Input.GetMouseButtonDown(0))
		{
			PlayMove = true; //call this loop once
//			
//			//Change Mouse Position on GUI to World Coordinates
			MPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			travelDir = MPosition - transform.position;
			travelDir.Normalize();
			LastMPosition = MPosition;
			LastMPosition.z = 0;
			Debug.Log (LastMPosition.x);
			Debug.Log (LastMPosition.y);
//			Debug.Log (LastMPosition.z);
//			if (Vector2.Distance (LastMPosition, transform.position) > 1) {
//				Debug.Log (" gogogo");
//				transform.position += transform.forward * MovementSpeed * Time.deltaTime;
//			}
			//this.transform.position = new Vector3(Mathf.Lerp(transform.position.x, MPosition.x, Time.time),Mathf.Lerp(transform.position.y, MPosition.y, Time.time), 0 );
			//AudioSource.PlayClipAtPoint(TheDatabase.AllyAudioMale[0].GetComfirmationSFX(), transform.position);
		}// End of Move There Command
		//Vector2 tempmouse = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition;
//		if (transform.position > LastMPosition) {
//						if (Vector2.Distance (LastMPosition, transform.position) > 1) {
//								Debug.Log (" gogogo");
//								transform.position += transform.right * MovementSpeed * Time.deltaTime;
//						}
//				}
		if (transform.position.x != LastMPosition.x && transform.position.y != LastMPosition.y) {
		if ((LastMPosition - this.transform.position).sqrMagnitude > 1.1f && PlayMove == true) {
			this.transform.Translate (travelDir.x,travelDir.y,this.transform.position.z);
		} else if ((LastMPosition - this.transform.position).sqrMagnitude <= 1.1f && PlayMove == true){
			PlayMove = false;
		}
		
		}
		
		//transform.position = Vector3.MoveTowards(transform.position, travelDir, 1);
		if(PlayMove == false)
			LastMPosition = new Vector3 (0, 0, 0);
		
	}

	void playerPosMouse(){

	}
}
