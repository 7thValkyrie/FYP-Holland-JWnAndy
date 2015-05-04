using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {
	public int Level_Unlock;
	public int Language;
	public int b_Mute;
	public int Level1_Coin;
	public float f_MasterVolume;
	public float f_BGMVolume;
	public float f_SFXVolume;

	public int current_Level;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Initialisation") == 1 || PlayerPrefs.GetInt ("Initialisation") == 0) { // When the computer doesn't have the save data, create a new set of data.
			PlayerPrefs.SetInt("Initialisation",2);
			PlayerPrefs.SetInt("Level_Unlock",1);
			PlayerPrefs.SetInt("Language",1);
			PlayerPrefs.SetInt("Mute",-1);
			PlayerPrefs.SetInt("Level1Coin",0);
			PlayerPrefs.SetFloat("Master Volume",1.0f);
			PlayerPrefs.SetFloat("BGM Volume",1.0f);
			PlayerPrefs.SetFloat("SFX Volume",1.0f);
			PlayerPrefs.Save();
			Language = 1;
			Level_Unlock = 1;
			b_Mute = -1;
			f_MasterVolume = 1.0f;
			f_BGMVolume = 1.0f;
		}
		else {
			GetData();
		}
	}

	void GetData() {
		Level_Unlock = PlayerPrefs.GetInt("Level_Unlock");
		Language = PlayerPrefs.GetInt("Language");
		b_Mute = PlayerPrefs.GetInt("Mute");
		Level1_Coin = PlayerPrefs.GetInt("Level1Coin");
		f_MasterVolume = PlayerPrefs.GetFloat("Master Volume");
		f_BGMVolume = PlayerPrefs.GetFloat("BGM Volume");
		f_SFXVolume = PlayerPrefs.GetFloat("SFX Volume");
	}

	void Save () { // Update the playerprefs
		PlayerPrefs.SetInt("Level_Unlock",2);
		PlayerPrefs.SetInt("Level_Unlock",3);
		PlayerPrefs.SetInt("Mute",b_Mute);
		PlayerPrefs.SetFloat("Master Volume",f_MasterVolume);
		PlayerPrefs.SetFloat("BGM Volume",f_BGMVolume);
		PlayerPrefs.SetFloat("SFX Volume",f_SFXVolume);
		PlayerPrefs.Save();
	}

	public void Clear () { // Resets the data
		PlayerPrefs.SetInt("Level_Unlock",1);
		PlayerPrefs.SetInt("Language",1);
		PlayerPrefs.SetInt("Mute",-1);
		PlayerPrefs.SetInt("Level1Coin",0);
		PlayerPrefs.SetFloat("Master Volume",1.0f);
		PlayerPrefs.SetFloat("BGM Volume",1.0f);
		PlayerPrefs.SetFloat("SFX Volume",1.0f);
		PlayerPrefs.Save();
		Level_Unlock = 1;
		b_Mute = -1;
		Level1_Coin = 0;
		f_MasterVolume = 1.0f;
		f_BGMVolume = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Save ();
		GetData();
	}
}
