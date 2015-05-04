using UnityEngine;
using System.Collections;

public class JW_burstForce : MonoBehaviour {

	public float explosionRate;
	public float explosionMaxSize;
	public float currentRadius;
	public playerGetBurn isBurned;
	public bool exploded = false;
	public JW_minigame_playercontroller playerMHit;
	CircleCollider2D explosionRadius;
	void Start()
	{

		exploded = true;
		explosionRadius = gameObject.GetComponent<CircleCollider2D> ();
		explosionMaxSize = 0.1f;
	}

	void FixedUpdate()
	{

		if(exploded == true)
		{
			if(currentRadius < explosionMaxSize)
			{
			currentRadius += explosionRate;
			}
			explosionRadius.radius = currentRadius;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(exploded == true)
		{
			if(col.gameObject.rigidbody2D != null)
			{
				//playerMHit.PlayMove = false;
				Vector2 target = col.gameObject.transform.position;
				Vector2 bomb = gameObject.transform.position;
				Vector2 direction = (target - bomb);
				col.gameObject.rigidbody2D.AddForce(direction * 1000);
				if(col.gameObject.tag == "odysseyFW")
				{
					isBurned.burning = true;
					isBurned.resetPos += 1;


				}

			}
		}
	}
}
