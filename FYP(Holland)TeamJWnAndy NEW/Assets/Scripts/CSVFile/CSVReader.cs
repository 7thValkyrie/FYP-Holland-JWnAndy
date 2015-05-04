using UnityEngine;
using System.Collections;

public class CSVReader : MonoBehaviour 
{
	// Level 1
	public TextAsset CSVFile_Level1_Dialogues;
	public TextAsset CSVFile_Level1_Description;
	public TextAsset CSVFile_Level1_OneLiner;
	public TextAsset CSVFile_Level1_Narration;

	public TextAsset CSVFile_Level1_Dialogues_Dutch;
	public TextAsset CSVFile_Level1_Description_Dutch;
	public TextAsset CSVFile_Level1_OneLiner_Dutch;
	public TextAsset CSVFile_Level1_Narration_Dutch;

	// Level 2
	public TextAsset CSVFile_Level2_Dialogues;
	public TextAsset CSVFile_Level2_Description;
	public TextAsset CSVFile_Level2_OneLiner;
	public TextAsset CSVFile_Level2_Narration;

	public TextAsset CSVFile_Level2_Dialogues_Dutch;
	public TextAsset CSVFile_Level2_Description_Dutch;
	public TextAsset CSVFile_Level2_OneLiner_Dutch;
	public TextAsset CSVFile_Level2_Narration_Dutch;

	// Level 3
	public TextAsset CSVFile_Level3_Dialogues;
	public TextAsset CSVFile_Level3_Description;
	public TextAsset CSVFile_Level3_OneLiner;
	public TextAsset CSVFile_Level3_Narration;

	public string[] Dialogue;
	public string[] Description;
	public string[] OneLiner;
	public string[] Narration;

	public int current_Level;
	// Use this for initialization
	void Awake () {
		current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
		if (current_Level == 1) {
			if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 1)
			{
				DialogueEng1();
			}
			else if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 2)
			{
				DialogueDutch1();
			}
		}

		else if (current_Level == 2) {
			if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 1)
			{
				DialogueEng2();
			}
			else if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 2)
			{
				DialogueDutch2();
			}
		}

		else if (current_Level == 3) {
			if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 1)
			{
				DialogueEng3();
			}
			//			else if(GameObject.Find("SaveData").GetComponent<SaveData>().Language == 2)
			//			{
			//				DialogueDutch2();
			//			}
		}
	}

	void Start () 
	{
		//if (x == 0) {
			
		//}
		//else {
		//	Dialogue = CSVFile4.text.Split ('\n');
		//	Description = CSVFile5.text.Split ('\n');
		//	OneLiner = CSVFile6.text.Split ('\n');
		//}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if(
	}

	public void DialogueEng1()
	{
		Dialogue = CSVFile_Level1_Dialogues.text.Split ('\n');
		Description = CSVFile_Level1_Description.text.Split ('\n');
		OneLiner = CSVFile_Level1_OneLiner.text.Split ('\n');
		Narration = CSVFile_Level1_Narration.text.Split ('\n');
	}

	public void DialogueDutch1()
	{
		Dialogue = CSVFile_Level1_Dialogues_Dutch.text.Split ('\n');
		Description = CSVFile_Level1_Description_Dutch.text.Split ('\n');
		OneLiner = CSVFile_Level1_OneLiner_Dutch.text.Split ('\n');
		Narration = CSVFile_Level1_Narration_Dutch.text.Split ('\n');
	}

	public void DialogueEng2()
	{
		Dialogue = CSVFile_Level2_Dialogues.text.Split ('\n');
		Description = CSVFile_Level2_Description.text.Split ('\n');
		OneLiner = CSVFile_Level2_OneLiner.text.Split ('\n');
		Narration = CSVFile_Level2_Narration.text.Split ('\n');
	}

	public void DialogueEng3()
	{
		Dialogue = CSVFile_Level3_Dialogues.text.Split ('\n');
		Description = CSVFile_Level3_Description.text.Split ('\n');
		OneLiner = CSVFile_Level3_OneLiner.text.Split ('\n');
		Narration = CSVFile_Level3_Narration.text.Split ('\n');
	}
	
	public void DialogueDutch2()
	{
		Dialogue = CSVFile_Level2_Dialogues_Dutch.text.Split ('\n');
		Description = CSVFile_Level2_Description_Dutch.text.Split ('\n');
		OneLiner = CSVFile_Level2_OneLiner_Dutch.text.Split ('\n');
		Narration = CSVFile_Level2_Narration_Dutch.text.Split ('\n');
	}

}
