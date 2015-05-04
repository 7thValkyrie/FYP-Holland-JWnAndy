using UnityEngine;
using System.Collections;

public class bloodstopTimer : MonoBehaviour {
	public float TimeToStopBlood;
	private float DefaultBlood;
	// Use this for initialization
	void Start () {
		DefaultBlood = 0;
	}
	
	// Update is called once per frame
	void Update () {
		DefaultBlood += Time.deltaTime;
		if (DefaultBlood > TimeToStopBlood)
						Destroy (this.gameObject);
	}
}
