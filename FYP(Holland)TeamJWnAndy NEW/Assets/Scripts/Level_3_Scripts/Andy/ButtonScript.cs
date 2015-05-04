using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour 
{
	public bool Hover = false;
	public Sprite[] Tex = new Sprite[2];

	public PauseScript PS;

	public enum ButtonFunction
	{
		BF_RESUME,      // Resume function
		BF_MAINMENU     // Main menu function
	} public ButtonFunction BF;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "MOUSE")
		{
			Hover = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "MOUSE")
		{
			Hover = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

        
		if (Hover)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[1]; // Change to hover sprite

            #if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                switch (BF)
                {
                    case ButtonFunction.BF_RESUME:
                        Global.PauseGame = false;             // Resume game
                        break;

                    case ButtonFunction.BF_MAINMENU:
                        Application.LoadLevel("MainMenu");   // Load main menu
                        break;
                }
            }

            #elif UNITY_ANDROID
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    switch (BF)
                    {
                        case ButtonFunction.BF_RESUME:
                            Global.PauseGame = false;             // Resume game
                            break;

                        case ButtonFunction.BF_MAINMENU:
                            Application.LoadLevel("MainMenu");   // Load main menu
                            break;
                    }
                }
            }
            #endif
		}
		else
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Tex[0]; // Reset to default sprite
		}
	}
}
