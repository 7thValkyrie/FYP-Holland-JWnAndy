using UnityEngine;
using System.Collections;

public class DescriptionBox : MonoBehaviour 
{
	public string Description;
	public GUISkin guiskin;
	public float Button_Width, Button_Height;
	
	// Use this for initialization 
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputUpdate ();
	}
	
	void InputUpdate ()
	{
		
		if (this.GetComponent<DescriptionBox>().enabled == true)
		{
			if(Input.GetMouseButtonDown(0) == true)
			{
				this.GetComponent<DescriptionBox>().enabled = false;
				if (GameObject.Find("Player").GetComponent<PlayerMovement>().enabled == true) 
					GameObject.Find("Player").GetComponent<PlayerMovement>().timeLastCalled = 0;
				else
					GameObject.Find("MasterRam").GetComponent<PlayerMovement>().timeLastCalled = 0;
			}
		}
		
	}
	void OnGUI ()
	{
		GUI.skin = guiskin;
		GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Button_Width / 1280.0f * Screen.width,  Button_Height / 720.0f * Screen.height), Description);
		GUI.skin.box.fontSize = (int)(Screen.width*0.015f);
		GUI.skin.box.overflow.left = (int)(Screen.width * 0.048476f);
		GUI.skin.box.overflow.right = (int)(Screen.width * 0.048476f);
	}
	
	Rect ScreenRect (float coord_x, float coord_y, float coord_width, float coord_height)
	{
		float f_x, f_y, f_width, f_height;
		
		f_x = coord_x * Screen.width;
		f_y = coord_y * Screen.height;
		f_width = coord_width * Screen.width;
		f_height = coord_height * Screen.height;
		
		return new Rect (f_x, f_y, f_width, f_height);
	}
}
