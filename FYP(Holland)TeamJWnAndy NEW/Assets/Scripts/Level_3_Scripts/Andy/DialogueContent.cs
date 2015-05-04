using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueContent : MonoBehaviour 
{
    public string Description;
    public bool isBranch = false, isQns = false;
    public List<string> Choices = new List<string>();
    //public string[] Choices = new string[3];

    public void AddChoices(params string[] ListOfStrings)
    {
        for (short i = 0; i < ListOfStrings.Length; ++i)
        {
            if (i >= 3)
                break;

            Choices.Add(ListOfStrings[i]);
        }
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isBranch)
        {
            Description = null;
        }
	}
}
