using UnityEngine;
using System.Collections;

public class zzz : MonoBehaviour 
{
    public GameObject text;
    public int count = 0;
	// Update is called once per frame
	void Update () 
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            text.transform.localScale *= 1.01f;

            if (count >= 5)
            {
                count = 0;
                Application.LoadLevel("ShipDeck");
            }
            else
            {
                count++;
            }
        }
        #elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                text.transform.localScale *= 1.01f;

                if (count >= 5)
                {
                    count = 0;
                    Application.LoadLevel("ShipDeck");
                }
                else
                {
                    count++;
                }
            }
        }
        #endif
    }
}
