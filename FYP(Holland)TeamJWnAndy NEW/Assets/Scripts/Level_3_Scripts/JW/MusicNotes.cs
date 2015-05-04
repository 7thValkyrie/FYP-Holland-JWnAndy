using UnityEngine;
using System.Collections;

public class MusicNotes : MonoBehaviour {
	private static MusicNotes notes_instance = null;
	public static MusicNotes Instance
	{
		get
		{
			if (notes_instance == null)
				notes_instance = (MusicNotes)FindObjectOfType (typeof(MusicNotes));
			return notes_instance;
		}
		
		
	}
	public GameObject HighNotes;
	public GameObject MidNotes;
	public GameObject LowNotes;
	public int MaxNumberOfNotes = 10;
//	public GameObject[] HighNoteList;
//	public GameObject[] MidNoteList;
//	public GameObject[] LowNoteList;
	public GameObject[] NoteList;
	public Transform HighNotePos;
	public Transform MidNotePos;
	public Transform LowNotePos;
	private int NoteType = 0;
	public int tempStop = 0;
	// Use this for initialization
	void Start () {
		NoteList = new GameObject[MaxNumberOfNotes];
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawningNotes ();
	}
	void spawningNotes()
	{

		if(tempStop < MaxNumberOfNotes)
		{
			for(int tempValue = 0; tempValue < MaxNumberOfNotes; tempValue++)
			{
				GameObject TempNotes = null;
				NoteType = Random.Range(1,4);
				if(NoteType == 1)
					TempNotes = Instantiate(HighNotes,HighNotePos.position,Quaternion.identity) as GameObject;
				else if(NoteType == 2)
					TempNotes = Instantiate(MidNotes,MidNotePos.position,Quaternion.identity)  as GameObject;
				else if(NoteType == 3)
					TempNotes = Instantiate(LowNotes,LowNotePos.position,Quaternion.identity)  as GameObject;
				
				NoteList[tempValue] = TempNotes;

			}
			tempStop++;
		}

	}
}
