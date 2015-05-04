using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

//	public int level_unlocked = 0;
	public int testgrey;

	// Use this for initialization
	void Start () {
		testgrey = GameObject.Find ("SaveData").GetComponent<SaveData> ().Level_Unlock;
		for(int i = 1; i < 6;i++)
		{
			if(testgrey >= i)
			{
				GameObject.Find("Level_"+i).GetComponent<SpriteRenderer>().color = Color.white;
			}
		}


//		level_unlocked = PlayerPrefs.GetInt ("PlayerPref_INT");
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (level_unlocked);
//		PlayerPrefs.SetInt ("PlayerPref_INT", level_unlocked);
//		PlayerPrefs.Save ();

	}

//	void storeData()
//	{
//
//	}
}
