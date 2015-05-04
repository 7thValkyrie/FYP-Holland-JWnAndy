using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour 
{
	public bool CollidedUnwalkable = false;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "UNWALKABLE")
		{
			CollidedUnwalkable = true;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "UNWALKABLE")
		{
			CollidedUnwalkable = false;
		}
	}
}
