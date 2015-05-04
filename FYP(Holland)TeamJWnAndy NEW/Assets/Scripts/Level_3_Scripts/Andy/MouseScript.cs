using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour 
{
	public bool MenuHover;                  // Detect if mouse is hovering over menu
	public PauseScript PS;                  // Reference from another script
	public bool UnwalkableHover = false;    // Detect if player enter an unwalkable region

	public enum MouseType
	{
		MT_DEFAULT, 	// 0 - Nothing
		MT_DOOR, 		// 1 - Door
		MT_INTERACT, 	// 2 - Object Interaction
		MT_NPC, 		// 3 - NPC Interaction
		MT_COMBINE 		// 4 - Combining item
	} public MouseType M_Type;

	public Sprite[] MouseTex;                                   // Render the sprite image of the mouse (size according to the MouseType)

	void OnTriggerEnter2D(Collider2D col)                       // Entering Collision Trigger on the Region
	{
		if (col.gameObject.tag == "DOOR_TRIGGER_MOUSE")         // Tagging of Door (mouse)
		{   
			M_Type = MouseType.MT_DOOR;                         // Set the type of the Mouse to Door Type
		}
        else if (col.gameObject.tag == "INTERACTABLE_NPC")      // Tagging of NPC
		{
            M_Type = MouseType.MT_NPC;                          // Set the type of the Mouse to NPC Type
		}
        else if (col.gameObject.tag == "PAUSE_GAME")            // Tagging of Pause Game
		{
            MenuHover = true;                                   // Pause Menu is being hovered
		}
        else if (col.gameObject.tag == "INTERACTABLE_OBJECT")   // Tagging of Interactable Object
		{
            M_Type = MouseType.MT_INTERACT;                     // Set the type of the Mouse to Interactable object Type
		}
        else if (col.gameObject.tag == "UNWALKABLE")            // Tagging of Unwalkable region
		{
			UnwalkableHover = true;                             // Unwalkable region is detected
		}
	}

    void OnTriggerExit2D(Collider2D col)                        // Exiting Collision Trigger on the Region
	{
		if (col.gameObject.tag == "DOOR_TRIGGER_MOUSE")
		{
			M_Type = MouseType.MT_DEFAULT;
		}
		else if (col.gameObject.tag == "INTERACTABLE_NPC")
		{
			M_Type = MouseType.MT_DEFAULT;
		}
		else if (col.gameObject.tag == "PAUSE_GAME")
		{
			MenuHover = false;
		}
		else if (col.gameObject.tag == "INTERACTABLE_OBJECT")
		{
			M_Type = MouseType.MT_DEFAULT;
		}
		else if (col.gameObject.tag == "UNWALKABLE")
		{
			UnwalkableHover = false;
		}
	}

	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;      // Disable the mouse cursor (Windows) - White colour mouse
	}
	
	// Update is called once per frame
	void Update ()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        //Update Mouse Pos
		Vector2 MousePos = Camera.main.ScreenToWorldPoint (new Vector2(Input.mousePosition.x, Input.mousePosition.y));          // Change the mouse screen position into world position
		this.transform.position = MousePos;                                                                                     // Set the Mouse position into the World position

		//Update Mouse Texture
		this.GetComponent<SpriteRenderer> ().sprite = MouseTex [(int)M_Type];       // Sprite rendering according to the mouse Type

		if (Input.GetMouseButtonDown(0) && MenuHover)                               // Mouse Down
		{
			Global.SetPause(true);                                                  // Set pause game
		}
        if (Input.GetMouseButtonDown(0) && M_Type == MouseType.MT_NPC)
        {
            Global.TriggerDialogue = true;                                          // Must click until the NPC then the dialogue will come out
        }
        if (Input.GetMouseButtonDown(0) && M_Type == MouseType.MT_INTERACT)
        {
            Global.TriggerItemUI = true;                                            // Must click until the object then the dialogue will come out
        }

        #elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            //Update Mouse Pos
		    Vector2 MousePos = Camera.main.ScreenToWorldPoint (new Vector2(touch.position.x, touch.position.y));          // Change the mouse screen position into world position
		    this.transform.position = MousePos;                                                                                     // Set the Mouse position into the World position

		    //Update Mouse Texture
		    this.GetComponent<SpriteRenderer> ().sprite = MouseTex [(int)M_Type];       // Sprite rendering according to the mouse Type

		    if (touch.phase == TouchPhase.Began && MenuHover)                               // Mouse Down
		    {
			    Global.SetPause(true);                                                  // Set pause game
		    }
            if (touch.phase == TouchPhase.Began && M_Type == MouseType.MT_NPC)
            {
                Global.TriggerDialogue = true;                                          // Must click until the NPC then the dialogue will come out
            }
            if (touch.phase == TouchPhase.Began && M_Type == MouseType.MT_INTERACT)
            {
                Global.TriggerItemUI = true;                                            // Must click until the object then the dialogue will come out
            }
        }
#endif
    }
}
