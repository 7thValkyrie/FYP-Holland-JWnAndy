using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour
{
	public int patternIndex;
	public float Speed_X, Speed_Y;
	private bool isMoveUp;
	private bool isMoveRight;

	
	Vector3 TargetBox_Position;
	float TargetBox_Width;
	float TargetBox_Height;
	float Real_Speed_X, Real_Speed_Y;
	
	GameObject TargetBoxLeft;
	GameObject TargetBoxRight;
	GameObject TargetBoxUp;

	// Use this for initialization
	void Start ()
	{
		isMoveUp = false;
		isMoveRight = false;
		TargetBoxRight = GameObject.Find("TargetBox_Right");
		TargetBoxLeft = GameObject.Find("TargetBox_Left");
		TargetBoxUp = GameObject.Find("TargetBox_Up");

		RespawnBug();
		
		Real_Speed_X = Speed_X;
		Real_Speed_Y = Speed_Y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find ("TutorialScript").GetComponent<TutorialScript> ().Ready == true) {
						if (GameObject.Find ("Background").GetComponent<RandomGenerator> ().over == false)
								RandomMovement ();
				}
		}
	
	void RandomMovement ()
	{
		if(patternIndex == 0 || patternIndex == 1)
		{
			if (isMoveUp == false) 
			{
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Real_Speed_Y*Time.deltaTime, 0.0f);
				Real_Speed_Y += Speed_Y;
				if(this.transform.position.y <= TargetBox_Position.y - TargetBox_Height/2.0f - GetComponent<SpriteRenderer>().sprite.texture.height/2.0f)
				{
					Real_Speed_Y = Speed_Y;
					isMoveUp = true;
					this.transform.position = new Vector3(this.transform.position.x,TargetBox_Position.y - TargetBox_Height/2.0f - GetComponent<SpriteRenderer>().sprite.texture.height/2.0f, 0.0f);
				}
			}
			else
			{
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Real_Speed_Y*Time.deltaTime, 0.0f);
				Real_Speed_Y += Speed_Y;
				if(this.transform.position.y >= TargetBox_Position.y - TargetBox_Height/2.0f + GetComponent<SpriteRenderer>().sprite.texture.height)
				{
					Real_Speed_Y = Speed_Y;
					isMoveUp = false;
					this.transform.position = new Vector3(this.transform.position.x, TargetBox_Position.y - TargetBox_Height/2.0f + GetComponent<SpriteRenderer>().sprite.texture.height, 0.0f);
				}
				
			}
		}
		else
		{
			if(isMoveRight == false)
			{
				this.transform.position = new Vector3(this.transform.position.x - Real_Speed_X*Time.deltaTime, this.transform.position.y, 0.0f);
				Real_Speed_X += Speed_X;
				if(this.transform.position.x <= TargetBox_Position.x + TargetBox_Width/2.0f - GetComponent<SpriteRenderer>().sprite.texture.width/4.0f)
				{
					Real_Speed_X = Speed_X;
					isMoveRight = true;
					this.transform.position = new Vector3(TargetBox_Position.x + TargetBox_Width/2.0f - GetComponent<SpriteRenderer>().sprite.texture.width/4.0f, this.transform.position.y, 0.0f);
				}
			}
			else
			{
				this.transform.position = new Vector3(this.transform.position.x + Real_Speed_X*Time.deltaTime, this.transform.position.y, 0.0f);
				Real_Speed_X += Speed_X;
				if(this.transform.position.x >= TargetBox_Position.x + TargetBox_Width/2.0f + GetComponent<SpriteRenderer>().sprite.texture.width/4.0f)
				{
					Real_Speed_X = Speed_X;
					isMoveRight = false;
					this.transform.position = new Vector3(TargetBox_Position.x + TargetBox_Width/2.0f + GetComponent<SpriteRenderer>().sprite.texture.width/4.0f, this.transform.position.y, 0.0f);
				}
			}
		}
		if(patternIndex == 0)
		{
			this.transform.position = new Vector3(this.transform.position.x + Real_Speed_X*Time.deltaTime, this.transform.position.y, 0.0f);
			//Real_Speed_Y += Speed_Y / 720.0f * Screen.height;

			Real_Speed_X += Speed_X;
			// Collision checking to the left side of the player
			//CHANGE THIS TO SOFT CODE!************************************************
			if(this.transform.position.x >= 340.0f)
			{
				//Debug.Log ("called");
				//GameObject.Find ("Player").GetComponent<Player> ().ResetComboCount();
				//if (GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player").GetComponent<Animator> ().SetInteger("Index", 4);
				//if (GameObject.Find("Player2").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player2").GetComponent<Animator> ().SetInteger("Index", 4);
				//if (GameObject.Find("Player3").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player3").GetComponent<Animator> ().SetInteger("Index", 4);
				GameObject.Find ("Player").GetComponent<Player> ().isRecovering = true;
				GameObject.Find ("Player2").GetComponent<Player> ().isRecovering = true;
				GameObject.Find ("Player3").GetComponent<Player> ().isRecovering = true;

				RespawnBug();
			}
		}
		else if(patternIndex == 1)
		{
			this.transform.position = new Vector3(this.transform.position.x - Real_Speed_X*Time.deltaTime, this.transform.position.y, 0.0f);
			//Real_Speed_Y += Speed_Y / 720.0f * Screen.height;
			
			Real_Speed_X += Speed_X;
			// Collision checking to the right side of the player
			//CHANGE THIS TO SOFT CODE!************************************************
			if(this.transform.position.x <= 950.0f)
			{
				//Debug.Log ("called");
				//if (GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player").GetComponent<Animator> ().SetInteger("Index", 4);
				//if (GameObject.Find("Player2").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player2").GetComponent<Animator> ().SetInteger("Index", 4);
				//if (GameObject.Find("Player3").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player3").GetComponent<Animator> ().SetInteger("Index", 4);
				//GameObject.Find ("Player").GetComponent<Player> ().ResetComboCount();
				GameObject.Find ("Player").GetComponent<Player> ().isRecovering = true;
				GameObject.Find ("Player2").GetComponent<Player> ().isRecovering = true;
				GameObject.Find ("Player3").GetComponent<Player> ().isRecovering = true;

				RespawnBug();
			}
		}
		else if(patternIndex == 2)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - Real_Speed_Y*Time.deltaTime, 0.0f);
			//Real_Speed_Y += Speed_Y / 720.0f * Screen.height;
			
			Real_Speed_Y += Speed_Y;
			//CHANGE THIS TO SOFT CODE!************************************************
			if(this.transform.position.y <= 350.0f)
			{
				//Debug.Log ("called");
				//if (GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player").GetComponent<Animator> ().SetInteger("Index", 4);
				//if (GameObject.Find("Player2").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player2").GetComponent<Animator> ().SetInteger("Index", 4);
				//if (GameObject.Find("Player3").GetComponent<SpriteRenderer>().enabled == true)
				//	GameObject.Find ("Player3").GetComponent<Animator> ().SetInteger("Index", 4);
				//GameObject.Find ("Player").GetComponent<Player> ().ResetComboCount();
				GameObject.Find ("Player").GetComponent<Player> ().isRecovering = true;
				GameObject.Find ("Player2").GetComponent<Player> ().isRecovering = true;
				GameObject.Find ("Player3").GetComponent<Player> ().isRecovering = true;

				RespawnBug();
			}
		}
	}
	
	public void RespawnBug ()
	{
		int tempRandom;
		tempRandom = Random.Range (0, 3);
		
		switch(tempRandom)
		{
		case 0:
			TargetBox_Position.x = TargetBoxLeft.GetComponent<SpriteRenderer>().transform.position.x;
			TargetBox_Position.y = TargetBoxLeft.GetComponent<SpriteRenderer>().transform.position.y;
			TargetBox_Position.z = 0.0f;
			TargetBox_Width = TargetBoxLeft.GetComponent<SpriteRenderer> ().sprite.texture.width;
			TargetBox_Height = TargetBoxLeft.GetComponent<SpriteRenderer> ().sprite.texture.height;
			
			patternIndex = 0;
			Real_Speed_X = Speed_X;
			Real_Speed_Y = Speed_Y;
			this.transform.position = new Vector3(-100.0f, 300.0f, 0.0f);
			break;
		case 1:
			TargetBox_Position.x = TargetBoxRight.GetComponent<SpriteRenderer>().transform.position.x;
			TargetBox_Position.y = TargetBoxRight.GetComponent<SpriteRenderer>().transform.position.y;
			TargetBox_Position.z = 0.0f;
			TargetBox_Width = TargetBoxRight.GetComponent<SpriteRenderer> ().sprite.texture.width;
			TargetBox_Height = TargetBoxRight.GetComponent<SpriteRenderer> ().sprite.texture.height;
			
			patternIndex = 1;
			Real_Speed_X = Speed_X;
			Real_Speed_Y = Speed_Y;
			this.transform.position = new Vector3(1500.0f, 300.0f, 0.0f);
			break;
		case 2:
			TargetBox_Position.x = TargetBoxUp.GetComponent<SpriteRenderer>().transform.position.x;
			TargetBox_Position.y = TargetBoxUp.GetComponent<SpriteRenderer>().transform.position.y;
			TargetBox_Position.z = 0.0f;
			TargetBox_Width = TargetBoxUp.GetComponent<SpriteRenderer> ().sprite.texture.width;
			TargetBox_Height = TargetBoxUp.GetComponent<SpriteRenderer> ().sprite.texture.height;
			
			patternIndex = 2;
			Real_Speed_X = Speed_X;
			Real_Speed_Y = Speed_Y;
			this.transform.position = new Vector3(700.0f, 850.0f, 0.0f);
			break;
		default:
			break;
		}
	}
}
