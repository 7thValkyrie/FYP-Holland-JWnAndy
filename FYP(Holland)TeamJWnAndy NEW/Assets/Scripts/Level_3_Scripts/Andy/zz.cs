using UnityEngine;
using System.Collections;

public class zz : MonoBehaviour 
{
	void Start ()
	{
		Screen.showCursor = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Application.Quit();
		}
	}
}
