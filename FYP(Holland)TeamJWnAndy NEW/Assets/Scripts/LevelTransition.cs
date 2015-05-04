using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {
	public string Previous_Level = "";
	public bool Initialised;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("SkipScenesController") != null)
        {
            if (GameObject.Find("SkipScenesController").GetComponent<SkipSceneController>().Initialised == true)
            {
                Destroy(this.gameObject);
            }
            Initialised = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
