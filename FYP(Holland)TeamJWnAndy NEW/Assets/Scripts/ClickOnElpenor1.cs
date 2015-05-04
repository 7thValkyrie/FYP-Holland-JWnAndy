using UnityEngine;
using System.Collections;

public class ClickOnElpenor1 : MonoBehaviour {
	
	public int DialogueID;
	public int NumberOfFrame_X;
	public bool isClicked;
	// Use this for initialization
	void Start () 
	{
		isClicked = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputUpdate ();
	}
	
	void InputUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			DownInput(Input.mousePosition);
		}
	}
	
	void DownInput(Vector3 pointPosition)
	{
		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableCharacter");
		foreach(GameObject TagObject in TagObjects)
		{				
			if(PointToSpriteCollision(pointPosition,Camera.main.WorldToScreenPoint (TagObject.GetComponent<SpriteRenderer>().transform.position), TagObject.GetComponent<SpriteRenderer>().sprite.texture.width/1280.0f * Screen.width, TagObject.GetComponent<SpriteRenderer>().sprite.texture.height / 720.0f * Screen.height, TagObject.transform.localScale.x) == true)
			{
				TagObject.GetComponent<ClickOnElpenor1>().isClicked = true;
			}
			else
			{
				TagObject.GetComponent<ClickOnElpenor1>().isClicked = false;
			}
		}
	}
	
	bool PointToSpriteCollision (Vector3 pointPosition, Vector3 SpritePosition, float width, float height, float ScaleX)
	{
		width = width / NumberOfFrame_X;
		if(ScaleX > 0)
		{
			if (pointPosition.x >= (SpritePosition.x ) && pointPosition.x <= (SpritePosition.x + (width)))
			{
				if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
				{
					return true;
				}
			}
		}
		else
		{
			if (pointPosition.x >= (SpritePosition.x- (width)) && pointPosition.x <= (SpritePosition.x ))
			{
				if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
				{
					return true;
				}
			}
		}
		return false;
	}
}
