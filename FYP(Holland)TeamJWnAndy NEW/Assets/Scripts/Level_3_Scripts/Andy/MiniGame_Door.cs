using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniGame_Door : MonoBehaviour 
{
    public static List<DoorScript> ListOfDoors = new List<DoorScript>();
    static bool bWin = false;

    void Awake()
    {
        if (bWin)
            Application.LoadLevel("SacrificialArea");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!bWin)
        {
            bool Completed = true;
            for (short i = 0; i < ListOfDoors.Count; ++i)
            {
                if (ListOfDoors[i].gameObject.activeSelf)
                    Completed = false;
            }
            if (ListOfDoors.Count > 0)
                bWin = Completed;
        }

        if (bWin)
            Application.LoadLevel("SacrificialArea");
	}
}
