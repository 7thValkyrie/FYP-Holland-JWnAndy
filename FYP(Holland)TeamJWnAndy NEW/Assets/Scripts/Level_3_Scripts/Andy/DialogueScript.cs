using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueScript : MonoBehaviour
{
    //Txt Data
    public TextAsset TxtFile;

    DialogueScript[] Branches = new DialogueScript[3];
    public ChoiceScript[] Pre_Choices = new ChoiceScript[3];
    List<DialogueContent> Content = new List<DialogueContent>();
    List<ChoiceScript> ChoiceList = new List<ChoiceScript>();
    bool Opened, Choices_Opened, Correct;
    public int Correct_Choice = 1;
    int Re_Index = 0;

	public GameObject Background;
	public GUISkin D_GUISkin;
	float Button_Width = 1100.0f, Button_Height = 300.0f;
    int CurIndex = 0;

    public void AddContent(params string[] ListOfStrings)
    {
        for (short i = 0; i < ListOfStrings.Length; ++i)
        {
            DialogueContent TempContent = new DialogueContent();
            bool ProceedToAdd = true;

            if (ListOfStrings[i].Length >= 8 && ListOfStrings[i].Substring(ListOfStrings[i].Length - 8, 8) == "<CHOICE>" ||
                ListOfStrings[i].Length >= 8 && ListOfStrings[i].Substring(ListOfStrings[i].Length - 8, 8) == "<OPTION>")
                ProceedToAdd = false;

            if (ListOfStrings[i].Length >= 8 && ListOfStrings[i].Substring(ListOfStrings[i].Length - 8, 8) == "<BRANCH>")
            {
                for (short j = 0; j < ChoiceList.Count; ++j)
                    TempContent.AddChoices(ChoiceList[j].Option);

                TempContent.isBranch = true;
                TempContent.Description = null;
                Re_Index = Content.Count;
            }
            else if (ListOfStrings[i].Length >= 5 && ListOfStrings[i].Substring(ListOfStrings[i].Length - 5, 5) == "<QNS>")
            {
                TempContent.isQns = true;
                TempContent.Description = ListOfStrings[i].Substring(0, ListOfStrings[i].Length - 5);
            }
            else
                TempContent.Description = ListOfStrings[i];

            if (ProceedToAdd)
                Content.Add(TempContent);
        }
    }

    void AddChoices(params string[] ListOfStrings)
    {
        for (short i = 0; i < ListOfStrings.Length; ++i)
        {
            ChoiceScript TempChoice = new ChoiceScript();

            if (ListOfStrings[i].Length >= 8 && ListOfStrings[i].Substring(ListOfStrings[i].Length - 8, 8) == "<CHOICE>")
            {
                TempChoice.Option = ListOfStrings[i].Substring(0, ListOfStrings[i].Length - 8);
                ChoiceList.Add(TempChoice);
            }
        }
        Debug.Log("CHOICE COUNT: " + ChoiceList.Count);
    }

    void AddBranch(params string[] ListOfStrings)
    {
        for (short i = 0; i < ListOfStrings.Length; ++i)
        {
            if (ListOfStrings[i].Length >= 8 && ListOfStrings[i].Substring(ListOfStrings[i].Length - 8, 8) == "<OPTION>")
            {
                int ID = int.Parse(ListOfStrings[i].Substring(ListOfStrings[i].Length - 9, 1));
                Branches[ID-1].AddContent(ListOfStrings[i].Substring(0, ListOfStrings[i].Length - 9));
            }
        }
    }

    void MergeBranch(DialogueScript Branch)
    {
        //Remove everything after Branch's Index
        while (true)
        {
            bool allClear = true;
            for (short i = 0; i < Content.Count; ++i)
            {
                if (i > CurIndex)
                {
                    allClear = false;
                    Content.RemoveAt(i);
                    break;
                }
            }
            if (allClear)
                break;
        }

        //Add New Branch
        for (short i = 0; i < Branch.Content.Count; ++i)
            AddContent(Branch.Content[i].Description);
    }

    void Start()
    {
        //Init Branches
        for (short i = 0; i < Branches.Length; ++i)
            Branches[i] = new DialogueScript();

        //Add Choice from Txt
        List<string> ContentList = FileReader.Load(TxtFile);
        for (short i = 0; i < ContentList.Count; ++i)
            AddChoices(ContentList[i]);

        //Add Content from Txt
        for (short i = 0; i < ContentList.Count; ++i)
            AddContent(ContentList[i]);

        //Add Branches (Option Tag)
        for (short i = 0; i < ContentList.Count; ++i)
            AddBranch(ContentList[i]);
    }

    public void Open()
    {
        if (!Opened)
        {
            CurIndex = 0;
            Background.SetActive(this.gameObject.activeSelf);      // Render the background of the translucent screen
            Opened = true;
        }
    }

    public void Close()
    {
        Opened = false;
        CurIndex = 0;
        Background.SetActive(false);                    // Disable the screen   
        this.gameObject.SetActive(false);               // Close the dialogue box
        Global.SetPause(false);                         // Unpause the game
    }

    public void OpenChoices()
    {
        if (!Choices_Opened)
        {
            for (short i = 0; i < Pre_Choices.Length; ++i)
            {
                if (i > ChoiceList.Count - 1)
                    break;
                Pre_Choices[i].gameObject.SetActive(true);
                Pre_Choices[i].Option = Content[CurIndex].Choices[i];
            }
            Choices_Opened = true;
        }
    }

    public void CloseChoices()
    {
        for (short i = 0; i < Pre_Choices.Length; ++i)
        {
            if (i > ChoiceList.Count - 1)
                break;
            Pre_Choices[i].clicked = false;
            Pre_Choices[i].gameObject.SetActive(false);
        }
        Choices_Opened = false;
    }

	void OnGUI ()
	{
        GUI.depth = 1;
		GUI.skin = D_GUISkin;
		GUI.Box (new Rect(this.transform.position.x/1280.0f*Screen.width, 
		                 (this.transform.position.y/720.0f * Screen.height) * -1 ,
		                  Button_Width / 1280.0f * Screen.width,
		                  Button_Height / 720.0f * Screen.height),
		         		  Content[CurIndex].Description);
		GUI.skin.box.fontSize = (int)(Screen.width*0.015f);
		GUI.skin.box.overflow.left = (int)(Screen.width * 0.048476f);
		GUI.skin.box.overflow.right = (int)(Screen.width * 0.048476f);
	}

	void Update ()
	{
        Open();

        bool ChoiceSelected = false;
        for (short i = 0; i < Pre_Choices.Length; ++i)
        {
            if (Pre_Choices[i].gameObject.activeSelf && Pre_Choices[i].clicked)
            {
                ChoiceSelected = true;
                MergeBranch(Branches[i]);
                CloseChoices();
                if (CurIndex < Content.Count)
                    ++CurIndex;
                if (ChoiceList.Count > 0)
                {
                    if (i + 1 == Correct_Choice)
                        Correct = true;
                    else
                        Correct = false;
                }
                else
                    Correct = true;
                break;
            }
        }

        if (Content[CurIndex].isBranch)
        {
            OpenChoices();
        }

        #if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && !ChoiceSelected)                        // Left click
        {
            if (CurIndex < Content.Count && !Content[CurIndex].isBranch)
            {
                ++CurIndex;                                     // Display next dialogue
            }
            if (CurIndex >= Content.Count)                 // Dialogue has ended
            {
                if (Correct || ChoiceList.Count <= 0)
                    Close();
                else
                    CurIndex = Re_Index;
            }
        }

        #elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (CurIndex < Description.Length)                  // Check if the dialogue has not ended
                {
                    ++CurIndex;                                     // Display next dialogue
                }
                if (CurIndex >= Description.Length)                 // Dialogue has ended
                {
                    Background.SetActive(false);                   // Disable the screen   
                    this.gameObject.SetActive(false);               // Close the dialogue box
                    Global.SetPause(false);                         // Unpause the game
                }
            }
        }
        #endif
    }
}