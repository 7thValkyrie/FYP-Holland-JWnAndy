using UnityEngine;
using System.Collections;

public class MovingBar : MonoBehaviour {

	Sword sword;

	protected Animator animator;
	public float smoothTime;
	bool up = true;
	public bool ismoving;

	private Vector3 velocity = Vector3.zero;
	private Vector3 targetPosition = new Vector3(38.5f, 633f, 0f);
	private Vector3 targetPosition2 = new Vector3(38.5f, 98f, 0f);

	// Use this for initialization
	void Start () {
		//ismoving = true;
        if (GameObject.Find("Sword") != null)
        {
            animator = GameObject.Find("Sword").GetComponent<Animator>();
        }
		smoothTime = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeDirection ();
		Move ();
	}

	void ChangeDirection() 
	{
		if (Mathf.Ceil(transform.position.y) == (int)targetPosition.y) {
			up = false;
		}
		if (Mathf.Floor(transform.position.y) == (int)targetPosition2.y) {
			up = true;
		}
	}

	void Move()
	{
		if (ismoving) {
			if (up == true)
			{
				transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref(velocity), smoothTime);
			}
			else
			{
				transform.position = Vector3.SmoothDamp (transform.position, targetPosition2, ref(velocity), smoothTime);
			}
		}
	}
}
