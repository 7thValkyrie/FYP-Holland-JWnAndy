using UnityEngine;
using System.Collections;

//using PlayerPrefs = PreviewLabs.PlayerPrefs;

// mastervol - Overall volume affecting all the audio sources
//
public class AudioManager : MonoBehaviour {

	public enum EVOLUME
	{
		MASTER,
		BGM,
		SFX
	}

	public float m_MasterVolume = 1f;
	public static float masterVol
	{
		get {return GetInstance().m_MasterVolume;}
		set 
		{
			// Set Volume for the listener
			GetInstance().m_MasterVolume = value;
			AudioListener.volume = value;
		}
	}

	public AudioClip m_BGMClip;

	private static AudioManager m_Instance = null;

	// Use this for initialization
	void Awake () {
		// if an instance is alrdy created
		if (m_Instance != null) 
		{
			// if a new clip has been assigned
			if (m_BGMClip != null)
				// play the new clip
				PlayBGM(this.m_BGMClip);
			// else continue playing old clip and destroy the second instance
			Destroy(this.gameObject);
			return;
		} 
		//else if there isn't a instance created yet
		else 
		{
			// set this object to be the singleton instance
			m_Instance = this;

			AudioListener.volume = m_MasterVolume;
			PlayBGM(this.m_BGMClip);
			DontDestroyOnLoad(this.gameObject);
		}
	}

	public static AudioManager GetInstance()
	{
		if (m_Instance == null)
		{
			// creating new instance if not created
			GameObject go = new GameObject("AudioManager");
			go.AddComponent<AudioManager>();
		}
		return m_Instance;
	}
	
	public static void PlayBGM (AudioClip bgmClip)
	{
		GetInstance().m_BGMClip = bgmClip;
		// stop previous playing bgm
		GetInstance().audio.Stop();
		// set audiosource clip 
		GetInstance().audio.clip = bgmClip;
		GetInstance().audio.loop = true;
		GetInstance().audio.Play();
	}
}
