using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public enum TransDir
	{
		LEFT,
		RIGHT
	} public TransDir Dir;
		
	public bool isMoved = false;
	public bool Stop = false;
	public int priority = 0;
	public bool isChild = false;
	public bool isParent = false;
	public DoorScript[] Child;
	public DoorScript Parent;

	void OnTriggerEnter2D (Collider2D col)
	{	
		if (col.gameObject.tag == "DESTROY")
		{
			this.gameObject.SetActive(false);
		}

		if (col.gameObject.tag == "STOP")
		{
			Stop = true;
		}
	}

    void Start()
    {
        //Add to List of Doors
        MiniGame_Door.ListOfDoors.Add(this);
    }
}