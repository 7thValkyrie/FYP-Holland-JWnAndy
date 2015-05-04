using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MinigameJW_mouse : MonoBehaviour {
	public ObjectManager objectM;
	public Vector3 temptemp;
	public GameObject poofafterdie;

	// Use this for initialization
	void Start () {
	
	}

//	void OnTriggerStay2D (Collider2D col)
//	{
//		if (Input.GetMouseButtonDown(0))
//		{
//			if (col.gameObject.tag == "flyingGhost" && 	objectM.CalcRingRadius < 100 ) 
//			{
//				renderer.material.color = Color.white;
//				//this.GetComponent<GUITexture>().texture = hi;
//				//Debug.Log ("Blaze it 402");
//				ObjectManager.Instance.numberofGhost -= 1;
//				//GUI.DrawTexture(new Rect(Input.mousePosition.x - guiTexture.pixelInset.width/2, Input.mousePosition.y - guiTexture.pixelInset.height/2, guiTexture.pixelInset.width, guiTexture.pixelInset.height), talk);
//				//this.guiTexture.texture = inspect;
//				col.gameObject.transform.localScale = new Vector3(0.1f,0.1f,1);
//				col.gameObject.SetActive(false);
//				Instantiate(poofafterdie,col.transform.position,Quaternion.identity);
//			}
//		}
//	}

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit;
		#if UNITY_ANDROID

		foreach(Touch touch in Input.touches)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
			Vector3 touchDir = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1)) -  objectM.FlyingGhost.position;
			hit = Physics2D.Raycast(touchDir, objectM.FlyingGhost.position);

		}

		#endif
		//Vector3 WorldMousePos =  Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1));
		//transform.position = WorldMousePos;
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1));
		Vector3 FacingDir = transform.position -  objectM.FlyingGhost.position;
		hit = Physics2D.Raycast (FacingDir, objectM.FlyingGhost.position);
//		Debug.DrawLine (transform.position,objectM.FlyingGhost.position);
//		//Debug.Log (objectM.CalcRingRadius);
	
		temptemp = GameObject.FindGameObjectWithTag ("RunningOdyseusMiniGame").transform.position;
		objectM.CalcRingRadius = (temptemp - transform.position).sqrMagnitude;

		if(Input.GetMouseButtonDown(0))
		{

			//renderer.color = Color.white;

			if (hit.collider != null)
			{

				//if (hit.collider.tag == "flyingGhost" && objectM.CalcRingRadius < 100 ) 
				if(hit.collider.tag == "flyingGhost" && Vector2.Distance(temptemp, transform.position) < 100 && hit.collider.gameObject.renderer.material.color.a > 0.8f)
				{
						renderer.material.color = Color.white;
						//this.GetComponent<GUITexture>().texture = hi;
						//Debug.Log ("Blaze it 402");
						ObjectManager.Instance.numberofGhost -= 1;
						//GUI.DrawTexture(new Rect(Input.mousePosition.x - guiTexture.pixelInset.width/2, Input.mousePosition.y - guiTexture.pixelInset.height/2, guiTexture.pixelInset.width, guiTexture.pixelInset.height), talk);
						//this.guiTexture.texture = inspect;
					    hit.collider.gameObject.transform.localScale = new Vector3(0.1f,0.1f,1);
						hit.collider.gameObject.SetActive(false);
						Instantiate(poofafterdie,hit.transform.position,Quaternion.identity);

				}
			}
		}


	}
}
