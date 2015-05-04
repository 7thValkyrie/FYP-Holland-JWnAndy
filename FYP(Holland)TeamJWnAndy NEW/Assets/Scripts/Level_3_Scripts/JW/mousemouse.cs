using UnityEngine;
using System.Collections;

public class mousemouse : MonoBehaviour {
 
	public Texture2D talk;
	public Texture2D inspect;
	public Transform mum;

	public Texture2D hi;
	public Texture2D bye;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.guiTexture.texture = bye;
		//curImage = cursorImage; //sets drawing texture back to default
		Vector2 mousePos = Input.mousePosition;
	//	toilet = new Rect (Input.mousePosition.x - guiTexture.pixelInset.width/2, Input.mousePosition.y - guiTexture.pixelInset.height/2, guiTexture.pixelInset.width, guiTexture.pixelInset.height);
		guiTexture.pixelInset = new Rect(Input.mousePosition.x - guiTexture.pixelInset.width/2, Input.mousePosition.y - guiTexture.pixelInset.height/2, guiTexture.pixelInset.width, guiTexture.pixelInset.height);//MousePos;
		//Vector2 Dir = (mousePos - mum.transform.position);
		Vector3 FacingDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)) -  mum.transform.position;
		RaycastHit2D hit = Physics2D.Raycast (FacingDir, mum.transform.position);
		Debug.DrawLine (mum.transform.position,FacingDir);
		if (hit.collider.tag == "mother") {
						//this.GetComponent<GUITexture>().texture = hi;
			Debug.Log ("Blaze it 402");
			 
						//GUI.DrawTexture(new Rect(Input.mousePosition.x - guiTexture.pixelInset.width/2, Input.mousePosition.y - guiTexture.pixelInset.height/2, guiTexture.pixelInset.width, guiTexture.pixelInset.height), talk);
			this.guiTexture.texture = inspect;		

		}

		//if (hit.collider.tag != "mother")

	}
	void  OnGUI () {
		//GUI.DrawTexture(toilet, toiletTexture);
	}
}
