using UnityEngine;
using System.Collections;

public class ChoiceScript : MonoBehaviour 
{
    bool Hover;
    public bool clicked, Transparent;
    public GUISkin D_GUISkin, Trans;
    public string Option;
    float Button_Width = 1010, Button_Height = 60.0f;

    void OnGUI()
    {
        if (Option != null)
        {
            GUI.depth = 0;
            Rect theRect = new Rect(this.transform.position.x / 1280.0f * Screen.width,
                             (this.transform.position.y / 720.0f * Screen.height) * -1,
                              Button_Width / 1280.0f * Screen.width,
                              Button_Height / 720.0f * Screen.height);

            //Check for Mouse Input
            if (theRect.Contains(Event.current.mousePosition))
            {
                GUI.skin = D_GUISkin;
                Hover = true;
            }
            else
            {
                if (Transparent)
                    GUI.skin = Trans;
                else
                    GUI.skin = null; 
                Hover = false;
            }

            GUI.skin.box.alignment = TextAnchor.MiddleLeft;
            GUI.skin.box.fontSize = (int)(Screen.width * 0.018f);
            GUI.skin.box.overflow.left = 0;
            GUI.skin.box.overflow.right = (int)(Screen.width * 0.048476f);
            GUI.Box(theRect, Option);
        }
    }

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        if (Hover && Input.GetMouseButton(0) && Option != null)
        {
            clicked = true;
        }
        else
        {
            clicked = false;
        }
#elif UNITY_ANDROID
            
#endif
	}
}
