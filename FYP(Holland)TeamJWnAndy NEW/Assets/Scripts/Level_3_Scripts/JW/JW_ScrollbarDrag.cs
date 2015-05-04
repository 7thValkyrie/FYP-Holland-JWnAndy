using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JW_ScrollbarDrag : MonoBehaviour {
	public JW_WinBar BloodUI;
	public JW_WinBar runUI;
	public Scrollbar rekt;
	public GUITexture textext;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			BloodUI.currentBlood += BloodUI.GainOverTime;
			rekt.size = BloodUI.currentBlood / 100f;

		}
		if (Application.loadedLevelName == "minigame_runupstair")
		{
			runUI.currentDistance += runUI.GainOverTime;
			rekt.value = runUI.currentDistance / 100f;
		}
		//rekt.value = BloodUI.currentBlood / 100f;
		//transform.position = Vector3.Lerp (StartPos, EndPos, BloodUI.currentBlood);
	}
	

}