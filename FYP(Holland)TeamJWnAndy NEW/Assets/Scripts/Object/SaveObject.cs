using UnityEngine;
using System.Collections;

public class SaveObject : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void Awake() 
	{
		DontDestroyOnLoad(gameObject);
	}
}
