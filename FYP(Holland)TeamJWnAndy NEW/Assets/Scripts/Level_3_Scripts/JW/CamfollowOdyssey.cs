using UnityEngine;
using System.Collections;

public class CamfollowOdyssey : MonoBehaviour {

	public Transform target;
	private Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.15f;
	public float minFov = 5f;
	public float maxFov = 20f;
	public float sensivity = 2.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float fov = Camera.main.orthographicSize;
		fov += Input.GetAxis ("Mouse ScrollWheel") * sensivity;
		fov = Mathf.Clamp (fov, minFov, maxFov);
		Camera.main.orthographicSize = fov;
		if (target) 
		{
			Vector3 targetPosition = target.position;
			targetPosition.z = transform.position.z;
			
			transform.position = Vector3.SmoothDamp(transform.position, 
			                                        targetPosition,
			                                        ref velocity, 
			                                        smoothTime);

		}
	}
}