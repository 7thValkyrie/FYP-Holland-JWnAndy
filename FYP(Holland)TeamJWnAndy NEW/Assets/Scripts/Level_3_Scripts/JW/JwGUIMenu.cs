using UnityEngine;
using System.Collections;

public class JwGUIMenu : MonoBehaviour {
	public GameObject JwMenuObject;
	public bool JWPauseGame;
	// Use this for initialization
	void Start () {
		//JwMenuObject.SetActive (false);
		JWPauseGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.timeScale);
	}
	public void showMenu(bool IsShow)
	{
		JWPauseGame = IsShow;
		JwMenuObject.SetActive (IsShow);
		if(JwMenuObject.activeSelf == true)
			Time.timeScale = 0;
		else if(JwMenuObject.activeSelf ==  false)
			Time.timeScale = 1;

	}
	public void RestartLvL(bool IsRestart)
	{
		if (!IsRestart)
		{
			Application.LoadLevel (Application.loadedLevel);
			Time.timeScale = 1;
		}
	}
}
