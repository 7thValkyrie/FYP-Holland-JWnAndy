using UnityEngine;
using System.Collections;

public class ClickableObject : MonoBehaviour 
{
	public bool PlayerUpdate;
	public bool b_Interact, b_Observe, b_PickUp;
	public bool PlayerObjectCollided;
	// Use this for initialization
	void Start () 
	{
		CheckGameProgression();
		PlayerUpdate = false;
		PlayerObjectCollided = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.b_Interact = GetComponent<ClickableObject> ().b_Interact;
		this.b_Observe = GetComponent<ClickableObject> ().b_Observe;
		this.b_PickUp = GetComponent<ClickableObject> ().b_PickUp;
		this.PlayerUpdate = GetComponent<ClickableObject> ().PlayerUpdate;
		InputUpdate ();
	}

	void InputUpdate()
	{
		if (Input.GetMouseButtonDown (0))
		{
			//GameObject.Find("/DialogueBox").GetComponent<DialogueBox>().enabled = false;
		}
		if (Input.GetMouseButtonUp (0))
		{
			DownInput(Input.mousePosition);
		}
	}

	void DownInput (Vector3 pointPosition)
	{

		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableObject");
		foreach(GameObject TagObject in TagObjects)
		{				
			//If Mouse position collided with the object
			if(PointToSpriteCollision(pointPosition,Camera.main.WorldToScreenPoint (TagObject.GetComponent<SpriteRenderer>().transform.position),
			TagObject.GetComponent<SpriteRenderer>().sprite.texture.width /TagObject.GetComponent<ObjectInformation>().NumberOfFrame_X /1280.0f * Screen.width, 
			TagObject.GetComponent<SpriteRenderer>().sprite.texture.height / 720.0f * Screen.height) == true)
			{
				if (GameObject.Find("DialogueBox").GetComponent<DialogueBox>().enabled == true || GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == true) {
					TagObject.GetComponent<ClickableObject>().PlayerUpdate = false;
					break; // Checks if there's any current dialogue or description open, if yes, break out of the for loop.
				}

				if (GameObject.Find("Player").GetComponent<PlayerMovement>().enabled == true) {
					if((GameObject.Find("Player").GetComponent<PlayerMovement>().timeLastCalled > 0.2))
						TagObject.GetComponent<ClickableObject>().PlayerUpdate = true;
				}
				else {
					if((GameObject.Find("MasterRam").GetComponent<PlayerMovement>().timeLastCalled > 0.2))
						TagObject.GetComponent<ClickableObject>().PlayerUpdate = true;
				}
			}
			else
			{
				//if((GameObject.Find("Player").GetComponent<PlayerMovement>().timeLastCalled > 0.2))
					TagObject.GetComponent<ClickableObject>().PlayerUpdate = false;
			}
		}
	}

	bool PointToSpriteCollision (Vector3 pointPosition, Vector3 SpritePosition, float width, float height)
	{
		if (pointPosition.x >= (SpritePosition.x ) && pointPosition.x <= (SpritePosition.x + (width)))
		{
			if (pointPosition.y >= (SpritePosition.y - height)  && pointPosition.y <= (SpritePosition.y)) 
			{
				return true;
			}
		}
		return false;
	}

	void CheckGameProgression ()
	{

	}
}
