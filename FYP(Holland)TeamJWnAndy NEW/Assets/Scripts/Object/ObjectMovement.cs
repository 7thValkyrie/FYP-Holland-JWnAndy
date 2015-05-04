using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour 
{
	public float Speed;
	public bool IncreaseVelocity;
	public float IncreaseRate;
	public Vector2 EndPosition;
	private bool StopAnimation_X;
	private bool StopAnimation_Y;
	private bool isRight;
	private bool isUp;



	// Use this for initialization
	void Start () 
	{
		//Movement for horizontal
		if(this.transform.position.x > EndPosition.x)
		{
			StopAnimation_X = false;
			isRight = false;
		}
		else if(this.transform.position.x < EndPosition.x)
		{
			StopAnimation_X = false;
			isRight = true;
		}
		else 
		{
			StopAnimation_X = true;
		}

		//Movement for vertical
		if(this.transform.position.y > EndPosition.y)
		{
			StopAnimation_Y = false;
			isUp = false;
		}
		else if(this.transform.position.y < EndPosition.y)
		{
			StopAnimation_Y = false;
			isUp = true;
		}
		else 
		{
			StopAnimation_Y = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Movement for horizontal
		if(StopAnimation_X == false)
		{
			if(isRight == true)
			{
				//Moving Right
				this.transform.position = new Vector3(this.transform.position.x + Speed*Time.deltaTime, this.transform.position.y, this.transform.position.z);
				if(this.transform.position.x >= EndPosition.x)
				{
					this.transform.position = new Vector3(EndPosition.x, this.transform.position.y, this.transform.position.z);
					StopAnimation_X = true;
				}
			}
			else
			{
				//Moving Left
				this.transform.position = new Vector3(this.transform.position.x - Speed*Time.deltaTime, this.transform.position.y, this.transform.position.z);
				if(this.transform.position.x <= EndPosition.x)
				{
					this.transform.position = new Vector3(EndPosition.x, this.transform.position.y, this.transform.position.z);
					StopAnimation_X = true;
				}
			}
		}

		//Movement for vertical
		if(StopAnimation_Y == false)
		{
			if(isUp == true)
			{
				//Moving Up
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Speed*Time.deltaTime, this.transform.position.z);
				if(this.transform.position.y >= EndPosition.y)
				{
					this.transform.position = new Vector3(this.transform.position.x, EndPosition.y, this.transform.position.z);
					StopAnimation_Y = true;
				}
			}
			else
			{
				//Moving Down
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Speed*Time.deltaTime, this.transform.position.z);
				if(this.transform.position.y <= EndPosition.y)
				{
					this.transform.position = new Vector3(this.transform.position.x, EndPosition.y, this.transform.position.z);
					StopAnimation_Y = true;
				}
			}
		}

		if(StopAnimation_X == true && StopAnimation_Y == true)
		{
			IncreaseVelocity = false;
		}
		if(IncreaseVelocity == true)
		{
			Speed += IncreaseRate;
		}
	}
}
