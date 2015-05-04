using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour
{

		void OnCollisionEnter(Collision collision)
	{
		//PlayerCharacterCollided = true;
		Debug.Log ("Enter called.");
	}

	void OnCollisionStay(Collision collision)
	{
		//PlayerCharacterCollided = true;
		Debug.Log ("Stay occuring.");
	}

	void OnCollisionExit(Collision collision)
	{
		Debug.Log ("Exit called.");
	}
}

