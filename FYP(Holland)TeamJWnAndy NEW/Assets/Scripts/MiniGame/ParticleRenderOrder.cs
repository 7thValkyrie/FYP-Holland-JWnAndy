using UnityEngine;
using System.Collections;

public class ParticleRenderOrder : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		particleSystem.renderer.sortingOrder = 15;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
