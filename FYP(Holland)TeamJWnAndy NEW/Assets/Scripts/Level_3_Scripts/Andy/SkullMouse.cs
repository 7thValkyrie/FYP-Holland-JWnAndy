using UnityEngine;
using System.Collections;

public class SkullMouse : MonoBehaviour 
{
    Vector3 WorldMousePos;

	// Update is called once per frame
	void Update () 
	{
        WorldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        this.transform.position = WorldMousePos; 
	}
}
