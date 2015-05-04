using UnityEngine;
using System.Collections;

public class RunningMan_Controller : MonoBehaviour {
	// ENUM
	Position player_position; 
	public bool Hit;
	// Timer variables
	float Hit_Timer = 0;
	//float Run_Timer = 0;
	
	public int minX;
	public int maxX;
	public int score;
	public int high_score;
	public int distance;
	public int max_distance;
	public float speed;

	// Swipe
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;
	// Swipe

	// Enum to represent the 3 lanes
	enum Position
	{
		Top,
		Middle,
		Bottom
	};

	// Use this for initialization
	void Start () {
		player_position = Position.Middle; // Set middle as the default position.
	}

	void UpdatePosition () {
		float tempx = 0;

		// Setting the x-axis depending on whether the player is hit
		if (Hit) { // When the player got hit
			// Manually set the speed 
			speed = 5;
			score = 0;
			Hit_Timer += Time.deltaTime;

			// Once the player hits the max position, manually set it to that max position.
			if (this.transform.position.x == maxX) {
				speed = 1;
				tempx = this.transform.position.x;
			}
			else {
				this.transform.FindChild("RunningManImage").GetComponent<SpriteRenderer>().color = new Vector4 (1,1,1,0.5f);
				tempx = this.transform.position.x+speed; // Update the position 
				if (tempx >= maxX) // When it reach maxX, hard set it to maxX.
					tempx = maxX;
			}

			// Once timer hits 4 seconds, let the player run back to the the minX
			if (Hit_Timer > 4) {
                this.transform.FindChild("RunningManImage").GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
				Hit_Timer = 0;
				Hit = false;
				speed = 1;
			}
		}

		else { // When the player didn't get hit
			speed += 1 * Time.deltaTime; // Increment of the speed.

			// Once the speed is equal or more than 5, hardset it to 5
			if (speed >= 5) 
				speed = 5;
			if (high_score <= score) // When the player reaches a score higher than the the previously known high_score, overwrite the high_score with the current score.
				high_score = score;

			// When the position is at minX, set it there.
			if (this.transform.position.x == minX)
				tempx = this.transform.position.x;

			// Move the player towards the minX 
			else {
				tempx = this.transform.position.x-speed;
				if (tempx < minX) // When it reach minX, hard set it to minX
					tempx = minX;
			}
		}

		// Setting the y-axis depending on where the position it is at.
		if (player_position == Position.Top) {
			this.transform.position = new Vector3(tempx,570,0);
			GameObject.Find("RunningManImage").GetComponent<SpriteRenderer>().sortingOrder = 1;
		}
		else if (player_position == Position.Middle) {
			this.transform.position = new Vector3(tempx,470,0);
			GameObject.Find("RunningManImage").GetComponent<SpriteRenderer>().sortingOrder = 2;
		}
		else {
			this.transform.position = new Vector3(tempx,370,0);
			GameObject.Find("RunningManImage").GetComponent<SpriteRenderer>().sortingOrder = 3;
		}
	}

	void InputUpdate () {

		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor){
			// Down arrow
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (player_position == Position.Top)
					player_position = Position.Middle;
				else if (player_position == Position.Middle)
					player_position = Position.Bottom;
			}
			// Up arrow
			else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (player_position == Position.Middle)
					player_position = Position.Top;
				else if (player_position == Position.Bottom)
					player_position = Position.Middle;
			}
			if(Input.GetKey(KeyCode.Escape))
			{
				distance = 0;
			}
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			if (Input.touchCount > 0){
				
				foreach (Touch touch in Input.touches)
				{
					switch (touch.phase)
					{
					case TouchPhase.Began :
						/* this is a new touch */
						isSwipe = true;
						fingerStartTime = Time.time;
						fingerStartPos = touch.position;
						break;
						
					case TouchPhase.Canceled :
						/* The touch is being canceled */
						isSwipe = false;
						break;
						
					case TouchPhase.Ended :
						
						float gestureTime = Time.time - fingerStartTime;
						float gestureDist = (touch.position - fingerStartPos).magnitude;
						
						if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
							Vector2 direction = touch.position - fingerStartPos;
							Vector2 swipeType = Vector2.zero;
							
							if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
								// the swipe is horizontal:
								swipeType = Vector2.right * Mathf.Sign(direction.x);
							}else{
								// the swipe is vertical:
								swipeType = Vector2.up * Mathf.Sign(direction.y);
							}
							
							if(swipeType.y != 0.0f ){
								if(swipeType.y > 0.0f){
									// MOVE UP
									if (player_position == Position.Middle)
										player_position = Position.Top;
									else if (player_position == Position.Bottom)
										player_position = Position.Middle;
								}else{
									// MOVE DOWN
									if (player_position == Position.Top)
										player_position = Position.Middle;
									else if (player_position == Position.Middle)
										player_position = Position.Bottom;
								}
							}
							
						}
						break;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// When the game is still on the instruction page, skip all the codes below
		if (GameObject.Find ("Continue").GetComponent<TutorialTextScript1> ().Ready == false)
			return;
		InputUpdate (); // Keyboard Control
		UpdatePosition (); // Updating Position based on the Keyboard control

		// Check through all the collision with all the trees.
		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag ("RunningManTree");
		foreach (GameObject TagObject in TagObjects) {
			if (SpriteToSpriteCollision(TagObject.transform.position, TagObject.GetComponent<SpriteRenderer>().sprite.texture.width, TagObject.GetComponent<SpriteRenderer>().sprite.texture.height) &&
			    player_position.ToString() == TagObject.GetComponent<Tree_Controller>().Lane.ToString()) {
				Hit = true;
			}
		}
		if(distance <= 0)
		{
            this.minX = 0;
			GameObject.Find("Background1").GetComponent<ScrollingBackground>().stop = true;
			GameObject.Find("Background2").GetComponent<ScrollingBackground>().stop = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-3";
		}

	}

	bool SpriteToSpriteCollision (Vector3 Position, float Width, float Height) {
		float x1Min, x1Max, y1Min, y1Max; // Player
		float x2Min, x2Max, y2Min, y2Max; // Input

		x1Min = this.transform.position.x;
		x1Max = this.transform.position.x + this.GetComponent<SpriteRenderer>().sprite.texture.width/2;
		y1Min = this.transform.position.y;
		y1Max = this.transform.position.y + this.GetComponent<SpriteRenderer>().sprite.texture.height/2;

		x2Min = Position.x;
		x2Max = Position.x + Width;
		y2Min = Position.y;
		y2Max = Position.y + Height;

		// Collision tests
		if( x1Max < x2Min || x1Min > x2Max ) return false;
		if( y1Max < y2Min || y1Min > y2Max ) return false;


		return true;
	}
}
