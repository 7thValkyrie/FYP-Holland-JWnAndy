using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {
	
	public GameObject slider;
	bool Movable;
	float minX;
	float maxX;
	float Vol;
	// Use this for initialization
	void Start () {

		this.gameObject.transform.position = new Vector3((AudioManager.masterVol *170f + 550), this.gameObject.transform.position.y, this.gameObject.transform.position.z);// (slider.transform.position.x - 550) / (720 - 550);

		Movable = false;
		minX = 550 / 1280.0f * Screen.width;
		maxX = 720 / 1280.0f * Screen.width;
		GameObject.Find("AudioLibrary").GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		InputUpdate ();
		BindMove ();
		//Debug.Log(this.gameObject.GetComponent<AudioManager>().m_MasterVolume);
		settingVolume ();
	}


	void onGUI ()
	{

	}

	void settingVolume()
	{
		//GameObject.Find ("AudioSettings").GetComponent<AudioManager> ().masterVol() = (slider.transform.position.x - 550) / (720 - 550);
		AudioManager.masterVol = (slider.transform.position.x - 550) / (720 - 550);

		//GameObject.Find("AudioLibrary").GetComponent<AudioSource> ().volume = (slider.transform.position.x - 550) / (720 - 550)* 100/100;//GameObject.Find("AudioSettings").GetComponent<AudioManager> ().m_MasterVolume; 
		}

	// Mouse Click
	void InputUpdate ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			if (PointToSpriteCollision (Input.mousePosition, Camera.main.WorldToScreenPoint (slider.GetComponent<SpriteRenderer> ().transform.position), slider.GetComponent<SpriteRenderer> ().sprite.texture.width / 1280.0f * Screen.width, slider.GetComponent<SpriteRenderer> ().sprite.texture.height / 720.0f * Screen.height, slider.transform.localScale.x , slider.transform.localScale.y)) {
				Movable = true;
					}
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			//DownInput(Input.mousePosition);
			Movable = false;
		}
	}
//	if (PointToSpriteCollision (Input.mousePosition, Camera.main.WorldToScreenPoint (slider.GetComponent<SpriteRenderer> ().transform.position), slider.GetComponent<SpriteRenderer> ().sprite.texture.width / 1280.0f * Screen.width, slider.GetComponent<SpriteRenderer> ().sprite.texture.height / 720.0f * Screen.height, slider.transform.localScale.x , slider.transform.localScale.y)) {
//		BindMove();
//	}
	void BindMove()
	{
		if (Movable == true) {

			if (Input.mousePosition.x >= minX && Input.mousePosition.x <= maxX ) {
							slider.transform.position = new Vector3 (Input.mousePosition.x * 1280.0f / Screen.width, slider.transform.position.y, 0);
					} 
			else if (Input.mousePosition.x < minX)
			{
				slider.transform.position = new Vector3 (550, slider.transform.position.y, 0);
			}
			else if ( Input.mousePosition.x > maxX )
			{
				slider.transform.position = new Vector3 (720, slider.transform.position.y, 0);
			}
			}
	}

	// Checking for Mouse collision
	bool PointToSpriteCollision (Vector3 pointPosition, Vector3 SpritePosition, float width, float height, float ScaleX, float ScaleY) { //Debug.Log (SpritePosition.x+","+pointPosition.x); 
		if(ScaleX > 0) { 
			if (pointPosition.x >= (SpritePosition.x ) && pointPosition.x <= (SpritePosition.x + (width*ScaleX))) { 
				if (pointPosition.y >= (SpritePosition.y - height*(ScaleY)) && pointPosition.y <= (SpritePosition.y)) { 
					return true; }
			} 
		} 
		return false; 
	}

}
