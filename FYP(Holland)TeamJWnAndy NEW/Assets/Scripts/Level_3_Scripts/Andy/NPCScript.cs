using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour
{
    //Dialogue Box
    public DialogueScript DBox;
    public bool Clicked;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (DBox != null && Clicked)
            {
                // Trigger Dialogue                 // Set Dialogue to be at the start
                DBox.gameObject.SetActive(true);    // Set Dialogue box to render
                Global.TriggerDialogue = false;     // Reset the flag of the Diablogue box
                Global.SetPause(true, false);       // Pause the game without rendering the pause menu
                Clicked = false;
            }
        }

        if (col.gameObject.tag == "MOUSE")
        {
            if (Input.GetMouseButtonDown(0))
                Clicked = true;
        }
    }
}
