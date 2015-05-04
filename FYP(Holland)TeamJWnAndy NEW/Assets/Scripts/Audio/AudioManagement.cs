using UnityEngine;
using System.Collections;

public class AudioManagement : MonoBehaviour {

	public AudioClip[] Storage;

	public bool b_bgm;
	public bool b_sfx;
	public int audio_ID;

	// Use this for initialization
	void Awake () {
		this.audio.volume = (GameObject.Find("AudioSettings").GetComponent<AudioManager>().m_MasterVolume);
	
		this.GetComponent <AudioSource> ().audio.clip = this.GetComponent<AudioManagement> ().Storage [this.GetComponent<AudioManagement> ().audio_ID];

	}

	void Start() {
		if (GameObject.Find (this.name) != this.gameObject) {
			Destroy(this.gameObject);
			return;
		}
		this.audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
