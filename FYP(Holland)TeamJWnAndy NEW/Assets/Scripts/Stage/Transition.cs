using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour 
{
	public bool isTransition;
	public bool isEnterScene;
	public float FadeDuration;
	public Texture BlackTexture;
	private float alphaValue;
	public string LoadLevel;

	// Use this for initialization
	void Start () 
	{
		alphaValue = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isEnterScene == true) 
		{
			if(isTransition == true)
			{
				if(alphaValue > 0.0f)
				{
					alphaValue -= Mathf.Clamp01(Time.deltaTime / FadeDuration);
				}
				else
				{
					isEnterScene = false;
					isTransition = false;
				}
			}
		}
		else
		{
			if(isTransition == true)
			{
				if(alphaValue < 1.0f)
				{
					alphaValue += Mathf.Clamp01(Time.deltaTime / FadeDuration);
				}
				//change scene
				else
				{
					Application.LoadLevel(LoadLevel);
				}
			}
		}
	}

	void OnGUI ()
	{
		//Have a black screen for each transition
		if (isTransition == true) 
		{
			GUI.color = new Color(0, 0, 0, alphaValue);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackTexture);
			GUI.depth = 0;
		}
	}
}
