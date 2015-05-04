using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float Speed;
	public bool reached_X, reached_Y;
	private Vector3 clickPosition;
	public Vector3 playerSpeed;
	private Animator PlayerAnimator;
	private bool isMoveUp, isMoveRight;
	private bool PlayerCharacterCollided;
	public bool PlayerObjectMovement;

	private int NumberOfObjectCollided;
	
	public float Limit_Height;
	public float Bottom_Limit;
	public float WalkableLimit_Height;
	
	public float RightX_Start, RightX_End;
	public float FinalPosition_Y;
	private bool Change_Y_Right, Change_Y_Left;
	
	public float LeftX_Start, LeftX_End;

	public bool SpeedChange;
	public float Min_Speed;
	public float Max_Speed;
	
	public int ClickedItemIconIndex;
	public int ClickedItemEnviromentIndex;
	public bool isClickedItemIcon_Enviroment;
	private bool GottenTheObject;
	public float timeLastCalled;
	public float timeLastCalled_Combine;

	// Used to lock the player in 1 direction
	public bool OnlyXMovement;
	public bool OnlyYMovement;

	public float Max_X;
	public float Max_Y;

	private Vector2 playerPosition;

	private bool Movable;
	

	public AudioSource SFXFire;

	public GameObject Bush;
	public GameObject BeeHiveDrop;

	static public bool once;

	public int current_Level;

	// Use this for initialization
	void Start () 
	{
		//Speed = 9999.0f;
		reached_X = true;
		reached_Y = true;
		isMoveUp = false;
		isMoveRight = false;
		PlayerCharacterCollided = false;
		PlayerObjectMovement = false;
		playerSpeed = new Vector3 (Speed, Speed, 0.0f);
		PlayerAnimator = GetComponent<Animator> ();
		NumberOfObjectCollided = 0;
		WalkableLimit_Height = Limit_Height + this.GetComponent<SpriteRenderer>().sprite.texture.height/2.0f;
		ClickedItemIconIndex = 0;
		ClickedItemEnviromentIndex = 0;
		isClickedItemIcon_Enviroment = false;
		timeLastCalled = 0.0f;
		SpeedChange = false;
		Bottom_Limit = 281;
		Min_Speed = 150;
		Max_Speed = 250;
		playerPosition = new Vector2 (this.transform.position.x, this.transform.position.y);
		Movable = false;
		once = false;

        //GameObject.Find("Bush_Sprite").GetComponent<SpriteRenderer>().enabled = false;

        //GameObject.Find("Spear").GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
		if (current_Level == 1) {
			if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetTreeBranchFromShit)
			once = true;
		}
		else if (current_Level == 2) {
			if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWine)
				Destroy(GameObject.Find("Goblet"));
		}

		//Debug.Log (once);
		if(GameObject.Find ("PauseScreen").GetComponent<PauseScreen>().enabled == false)
		{
			PlayerAnimator.speed = 1.0f;
			PlayerToObjectCollision();
			//if (isClickedItemIcon_Enviroment == true) {
			//	isClickedItemIcon_Enviroment = false;
			//	timeLastCalled = 0;
			//}
			PlayerToExitBoxCollision();
			PlayerToCharacterCollision();
			if (SpeedChange)
				SpeedUpdate();
			GoldenCoinCollision(); // Check if the collision between the mouse pointer and golden coin
			if (Movable)
				InputUpdate();
			Movable = true;
			MovePlayer();
			if (OnlyXMovement) {
				this.transform.position = new Vector3(this.transform.position.x,playerPosition.y,this.transform.position.z);
				reached_Y = true;
			}

			if (OnlyYMovement) {
				this.transform.position = new Vector3 (playerPosition.x,this.transform.position.y,this.transform.position.z);
				reached_X = true;
			}

			if (Max_X != 0) {
				if (this.transform.position.x >= Max_X) {
					this.transform.position = new Vector3 (Max_X,this.transform.position.y,this.transform.position.z);
					reached_X = true;
				}
			}

			if (Max_Y != 0) {
				if (this.transform.position.y >= Max_Y) {
					this.transform.position = new Vector3 (this.transform.position.x,Max_Y,this.transform.position.z);
					reached_Y = true;
				}
			}
			timeLastCalled += Time.deltaTime;
		}
		else
		{
			PlayerAnimator.speed = 0.0f;
		}
	}

	void SpeedUpdate () {
		float x = 0.0f;
		x =(this.transform.position.y - Bottom_Limit)/(Limit_Height - Bottom_Limit) * 100;
		Speed = (((Min_Speed - Max_Speed) / 100) * x) + Max_Speed;
	}

	void OnCollisionEnter2D (Collision2D collide)
	{
		if (collide.gameObject.GetComponent < ObjectInformation > ().ObjectID == 34) 
		{

					playerSpeed = Vector3.zero;
					reached_X = true;
					reached_Y = true;

			if(isMoveUp)
			{
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 10);
			}
			if(isMoveRight)
			{
				this.transform.position = new Vector3(this.transform.position.x -10, this.transform.position.y);
			}
			if(!isMoveRight && !isMoveUp)
			{
				this.transform.position = new Vector3(this.transform.position.x+10, this.transform.position.y + 10);
			}
		}
	}
	
	void GoldenCoinCollision () 
	{
		if (Input.GetMouseButtonDown(0)) {
			GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableCoin");
			foreach (GameObject TagObject in TagObjects) {
				if (TagObject.GetComponent<SpriteRenderer>().enabled == false)
					continue;

				if (PointToSpriteCollision(Input.mousePosition,Camera.main.WorldToScreenPoint(TagObject.GetComponent<SpriteRenderer>().transform.position),TagObject.GetComponent<SpriteRenderer>().sprite.texture.width/1280.0f*Screen.width,TagObject.GetComponent<SpriteRenderer>().sprite.texture.height/720.0f*Screen.height,TagObject.transform.localScale.x,TagObject.transform.localScale.y)) {
					//TagObject.GetComponent<SpriteRenderer>().enabled = false;
					TagObject.GetComponent<SpriteRenderer>().sortingOrder = 99;
					Movable = false;
					GameObject.Find("GoldenCoin").GetComponent<Coin_Controller>().CoinMoving = true;
					switch (TagObject.GetComponent<Coin_Controller>().ID) {
					case 1:
						GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoldenCoin1 = true;
						break;
					case 2:
						GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoldenCoin2 = true;
						break;
					case 3:
						GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoldenCoin3 = true;
						break;
					case 4:
						GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoldenCoin4 = true;
						break;
					case 5:
						GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoldenCoin5 = true;
						break;
					case 6:
						GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoldenCoin6 = true;
						break;
					}
				}
			}
		}
	}
	
	void PlayerToCharacterCollision ()
	{
		float TextureWidth = 98.0f/2.0f;
		float TextureHeight = 250.0f/2.0f;
		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableCharacter");
		DialogueBox TempDialogueBox = GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ();
		foreach(GameObject TagObject in TagObjects)
		{
			if (TagObject.GetComponent<SpriteRenderer>().enabled == false)
				continue;
			if(TagObject.GetComponent<CharacterDialogue>().isClicked == true)
			{
				SpriteRenderer tempObjRenderer = TagObject.GetComponent<SpriteRenderer>();
				if(SpriteToSpriteCollision(tempObjRenderer.transform.position, tempObjRenderer.sprite.texture.width/TagObject.GetComponent<CharacterDialogue>().NumberOfFrame_X, tempObjRenderer.sprite.texture.height, TagObject.transform.localScale.x, TagObject.transform.localScale.y, this.transform.position, TextureWidth, TextureHeight, this.transform.localScale.x, this.transform.localScale.y) == true)
				{
					if(PlayerCharacterCollided == false)
					{
						PlayerCharacterCollided = true;
						if(TempDialogueBox.isSetDialogue == false)
						{
							TempDialogueBox.DisplayDialogue(TagObject.GetComponent<CharacterDialogue>().DialogueID);
						}
						reached_X = true;
						reached_Y = true;
					}
				}
				else
				{
					PlayerCharacterCollided = false;
				}
			}
		}
	}
	
	void PlayerToExitBoxCollision ()
	{
		float TextureWidth = 98.0f/2.0f;
		float TextureHeight = 250.0f/2.0f;
		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableExit");
		foreach(GameObject TagObject in TagObjects)
		{
			if (GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == true)
				break;
			if (TagObject.GetComponent<SpriteRenderer>().enabled == false || TagObject.GetComponent<ExitBox>().enabled == false)
				continue;
			if(TagObject.GetComponent<ExitBox>().isClicked == true)
			{
				SpriteRenderer tempObjRenderer = TagObject.GetComponent<SpriteRenderer>();
				if(SpriteToSpriteCollision(tempObjRenderer.transform.position, tempObjRenderer.sprite.texture.width, tempObjRenderer.sprite.texture.height, TagObject.transform.localScale.x, TagObject.transform.localScale.y, this.transform.position, TextureWidth, TextureHeight, this.transform.localScale.x, this.transform.localScale.y) == true)
				{
						reached_X = true;
						reached_Y = true;
						TagObject.GetComponent<ExitBox>().ChangeScene(TagObject.GetComponent<ExitBox>().ExitID);
				}
			}
		}
	}

	void PlayerToObjectCollision()
	{
		float TextureWidth = 98.0f/2.0f;
		float TextureHeight = 250.0f/2.0f;
		
		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableObject");
		foreach(GameObject TagObject in TagObjects)
		{
			if (TagObject.GetComponent<SpriteRenderer>().enabled == false)
				continue;	

			if(TagObject.GetComponent<ClickableObject>().PlayerUpdate == true)
			{
				if (GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().enabled == true && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishHidingInRam == false)
					continue;
				SpriteRenderer tempObjRenderer = TagObject.GetComponent<SpriteRenderer>();
				int NumberOfFrame_X = TagObject.GetComponent<ObjectInformation>().NumberOfFrame_X;
				
				if(SpriteToSpriteCollision(tempObjRenderer.transform.position, tempObjRenderer.sprite.texture.width/NumberOfFrame_X, tempObjRenderer.sprite.texture.height, TagObject.transform.localScale.x, TagObject.transform.localScale.y, this.transform.position, TextureWidth, TextureHeight, this.transform.localScale.x, this.transform.localScale.y) == true)
				{
					timeLastCalled = 0.0f;
					if(isClickedItemIcon_Enviroment == true)
					{
						CombineListEnviromentItem(ClickedItemIconIndex, ClickedItemEnviromentIndex);
						isClickedItemIcon_Enviroment = false;
						ClickedItemEnviromentIndex = 0;
						ClickedItemIconIndex = 0; 
					}
					else 
					{
						//Debug.Log(NumberOfFrame_X);
						//Debug.Log (TagObject.GetComponent<ClickableObject>().transform.position.x);
						//Debug.Log(TagObject.GetComponent<SpriteRenderer>().sprite.texture.width/NumberOfFrame_X/2.1f);
						//Don't Change this
						GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().enabled = true;
						GameObject.Find("OptionPlacement").transform.position = new Vector3(TagObject.GetComponent<ClickableObject>().transform.position.x + TagObject.GetComponent<SpriteRenderer>().sprite.texture.width/NumberOfFrame_X/2.1f - GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().sprite.texture.width/4.0f, TagObject.GetComponent<ClickableObject>().transform.position.y + GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().sprite.texture.height/4.0f + 7.0f, 0);
						
						//tempObjRenderer.color = new Color(1, 0, 0);
						if(TagObject.GetComponent<ClickableObject>().b_Interact == true)
						{
							TagObject.GetComponent<Interact>().enabled = true;
						}
						if(TagObject.GetComponent<ClickableObject>().b_Observe == true)
						{
							TagObject.GetComponent<Observe>().enabled = true;
							//GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = TagObject.GetComponent<Observe>().English_Dialogue;
						}
						if(TagObject.GetComponent<ClickableObject>().b_PickUp == true)
						{
							TagObject.GetComponent<PickUp>().enabled = true;
						}
						if(TagObject.GetComponent<ClickableObject>().PlayerObjectCollided == false)
						{
							TagObject.GetComponent<ClickableObject>().PlayerObjectCollided = true;
							PlayerObjectMovement = true;
						}
					}
					NumberOfObjectCollided ++;
				}
				else
				{
					TagObject.GetComponent<ClickableObject>().PlayerObjectCollided = false;
				}
			}
			//Didn't clicked on the object
			else
			{	
				if(TagObject.GetComponent<ClickableObject>().b_Interact == true && TagObject.GetComponent<Interact>().enabled == true)
				{
					TagObject.GetComponent<Interact>().enabled = false;
					GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().enabled = false;
				}
				if(TagObject.GetComponent<ClickableObject>().b_Observe == true && TagObject.GetComponent<Observe>().enabled == true)
				{
					TagObject.GetComponent<Observe>().enabled = false;
					GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().enabled = false;
				}
				if(TagObject.GetComponent<ClickableObject>().b_PickUp == true && TagObject.GetComponent<PickUp>().enabled == true)
				{
					TagObject.GetComponent<PickUp>().enabled = false;
					GameObject.Find("OptionPlacement").GetComponent<SpriteRenderer>().enabled = false;
				}
				
			}
		}
	}
	void InputUpdate ()
	{
		if(GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().enabled == true)
		{
		}
		else if(NumberOfObjectCollided >= 1)
		{
			NumberOfObjectCollided = 0;
			reached_X = true;
			reached_Y = true;
		}
		else if(NumberOfObjectCollided == 0)
		{
			float TextureWidth = 1080.0f/8.0f/2.0f;
			float TextureHeight = 250.0f/2.0f;

			if(Application.platform == RuntimePlatform.Android)
			{
				if (Input.touchCount > 0 && Input.touchCount <= 1)
				{
					Change_Y_Right = false;
					Change_Y_Left = false;
					if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= 23.0f || Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= 150.0f || 
					   Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 1258.0f || Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 698.0f)
					{
					}
					else
					{
						float Distance_X, Distance_Y;
						
						PlayerAnimator.SetBool("isWalking", true);
						
						//Transform the position from screen space into world space
						clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
						
						//Set reach to destination false
						reached_X = false;
						reached_Y = false;
						
						// If destination coordinate X is bigger than player X (Moving Right)
						if(clickPosition.x > this.transform.position.x)
						{
							//Make the player facing the right if it isn't
							if(this.transform.localScale.x < 0)
							{
								this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
							}
							if(clickPosition.x + TextureWidth >= 1280.0f) 
							{
								clickPosition.x -= TextureWidth;
							}
							
							if(clickPosition.x >= RightX_Start)
							{
								Change_Y_Right = true;
							}
							else if(clickPosition.x <= LeftX_End)
							{
								Change_Y_Left = true;
							}
							
							Distance_X = clickPosition.x - this.transform.position.x;
							
							isMoveRight = true;
							if(Distance_X <= 0)
							{
								reached_X = true;
								Distance_X = 0;
							}
						}
						// If destination Player X is bigger than coordinate X (Moving Left)
						else
						{
							//Make the player facing the Left if it isn't
							if(this.transform.localScale.x > 0)
							{
								this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
							}
							if(clickPosition.x - TextureWidth <= 0) 
							{
								clickPosition.x += TextureWidth;
							}
							
							if(clickPosition.x >= RightX_Start)
							{
								Change_Y_Right = true;
							}
							else if(clickPosition.x <= LeftX_End)
							{
								Change_Y_Left = true;
							}
							
							Distance_X =  this.transform.position.x - clickPosition.x;
							isMoveRight = false;
							if(Distance_X <= 0)
							{
								reached_X = true;
								Distance_X = 0;
							}
						}
						
						if(Change_Y_Right == true)
						{
							float clicked_X;
							if(isMoveRight == true)
							{
								clicked_X = clickPosition.x - RightX_Start;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (RightX_End-RightX_Start));
								if(this.transform.position.y >= FinalPosition_Y)
								{
									isMoveUp = false;
									
									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}
									Distance_Y =  this.transform.position.y - FinalPosition_Y;
									
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
								else
								{
									isMoveUp = true;
									
									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}
									Distance_Y =  FinalPosition_Y - this.transform.position.y;
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
							}
							else
							{
								clicked_X = clickPosition.x - RightX_Start;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (RightX_End-RightX_Start));
								
								if(FinalPosition_Y <= TextureHeight + 156.0f) 
								{
									FinalPosition_Y = TextureHeight + 156.0f;
								}
								Distance_Y =  FinalPosition_Y - this.transform.position.y;
								if(Distance_Y <= 0)
								{
									reached_Y = true;
									Distance_Y = 0;
								}
							}
						}
						else if(Change_Y_Left == true)
						{
							float clicked_X;
							if(isMoveRight == true)
							{
								isMoveUp = true;
								clicked_X = LeftX_End - clickPosition.x;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (LeftX_End-LeftX_Start));
								
								if(FinalPosition_Y <= TextureHeight + 156.0f) 
								{
									FinalPosition_Y = TextureHeight + 156.0f;
								}
								
								Distance_Y =  FinalPosition_Y - this.transform.position.y;
								if(Distance_Y <= 0)
								{
									reached_Y = true;
									Distance_Y = 0;
								}
							}
							else
							{
								clicked_X = LeftX_End - clickPosition.x;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (LeftX_End-LeftX_Start));
								if(this.transform.position.y >= FinalPosition_Y)
								{
									isMoveUp = false;
									
									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}
									
									Distance_Y =  this.transform.position.y - FinalPosition_Y;
									
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
								else
								{
									isMoveUp = true;
									
									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}
									
									Distance_Y =  FinalPosition_Y - this.transform.position.y;
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
							}
						}
						// If destination coordinate Y is bigger than player Y (Moving Up)
						else if(clickPosition.y > this.transform.position.y)
						{
							if(clickPosition.y + TextureHeight >= WalkableLimit_Height) 
							{
								clickPosition.y = WalkableLimit_Height - TextureHeight;
							}
							/*
							if(Change_Y == true)
							{
								float clicked_X;
								clicked_X = clickPosition.x - RightX_Start;
								FinalPosition_Y = Limit_Height - ((Limit_Height-156.0f))*(clicked_X / (RightX_End-RightX_Start));
								
								Distance_Y = FinalPosition_Y - this.transform.position.y;
							}
							else
							{
							*/
							Distance_Y = clickPosition.y - this.transform.position.y;
							//}
							isMoveUp = true;
							if(Distance_Y <= 0)
							{
								reached_Y = true;
								Distance_Y = 0;
							}
						}
						// If destination Player Y is bigger than coordinate Y (Moving Down)
						else
						{
							if(clickPosition.y - TextureHeight <= 156.0f) 
							{
								clickPosition.y = TextureHeight + 156.0f;
							}
							
							Distance_Y =  this.transform.position.y - clickPosition.y;
							
							isMoveUp = false;
							if(Distance_Y <= 0)
							{
								reached_Y = true;
								Distance_Y = 0;
							}
						}
						
						//Calculate Speed
						if(Distance_X > Distance_Y)
						{
							playerSpeed.x = Speed;
							playerSpeed.y = Distance_Y/Distance_X * Speed;
						}
						else
						{
							playerSpeed.x = Distance_X/Distance_Y * Speed;
							playerSpeed.y = Speed;
						}
					}
				}
			}

			if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if(Input.GetMouseButtonDown(0))
				{
					//Debug.Log ("Test");
					Change_Y_Right = false;
					Change_Y_Left = false;
					if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= 23.0f || Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= 150.0f || 
					   Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 1258.0f || Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 698.0f)
					{
					}
					else
					{
						float Distance_X, Distance_Y;
						
						PlayerAnimator.SetBool("isWalking", true);
						
						//Transform the position from screen space into world space
						clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
						
						//Set reach to destination false
						reached_X = false;
						reached_Y = false;
						
						// If destination coordinate X is bigger than player X (Moving Right)
						if(clickPosition.x > this.transform.position.x)
						{
							//Make the player facing the right if it isn't
							if(this.transform.localScale.x < 0)
							{
								this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
							}
							if(clickPosition.x + TextureWidth >= 1280.0f) 
							{
								clickPosition.x -= TextureWidth;
							}

							if(clickPosition.x >= RightX_Start)
							{
								Change_Y_Right = true;
							}
							else if(clickPosition.x <= LeftX_End)
							{
								Change_Y_Left = true;
							}

							Distance_X = clickPosition.x - this.transform.position.x;
							
							isMoveRight = true;
							if(Distance_X <= 0)
							{
								reached_X = true;
								Distance_X = 0;
							}
						}
						// If destination Player X is bigger than coordinate X (Moving Left)
						else
						{
							//Make the player facing the Left if it isn't
							if(this.transform.localScale.x > 0)
							{
								this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
							}
							if(clickPosition.x - TextureWidth <= 0) 
							{
								clickPosition.x += TextureWidth;
							}
							
							if(clickPosition.x >= RightX_Start)
							{
								Change_Y_Right = true;
							}
							else if(clickPosition.x <= LeftX_End)
							{
								Change_Y_Left = true;
							}

							Distance_X =  this.transform.position.x - clickPosition.x;
							isMoveRight = false;
							if(Distance_X <= 0)
							{
								reached_X = true;
								Distance_X = 0;
							}
						}

						if(Change_Y_Right == true)
						{
							float clicked_X;
							if(isMoveRight == true)
							{
								clicked_X = clickPosition.x - RightX_Start;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (RightX_End-RightX_Start));
								if(this.transform.position.y >= FinalPosition_Y)
								{
									isMoveUp = false;
									
									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}
									Distance_Y =  this.transform.position.y - FinalPosition_Y;
									
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
								else
								{
									isMoveUp = true;
									
									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}
									Distance_Y =  FinalPosition_Y - this.transform.position.y;
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
							}
							else
							{
								clicked_X = clickPosition.x - RightX_Start;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (RightX_End-RightX_Start));
								
								if(FinalPosition_Y <= TextureHeight + 156.0f) 
								{
									FinalPosition_Y = TextureHeight + 156.0f;
								}
								Distance_Y =  FinalPosition_Y - this.transform.position.y;
								if(Distance_Y <= 0)
								{
									reached_Y = true;
									Distance_Y = 0;
								}
							}
						}
						else if(Change_Y_Left == true)
						{
							float clicked_X;
							if(isMoveRight == true)
							{
								isMoveUp = true;
								clicked_X = LeftX_End - clickPosition.x;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (LeftX_End-LeftX_Start));

								if(FinalPosition_Y <= TextureHeight + 156.0f) 
								{
									FinalPosition_Y = TextureHeight + 156.0f;
								}

								Distance_Y =  FinalPosition_Y - this.transform.position.y;
								if(Distance_Y <= 0)
								{
									reached_Y = true;
									Distance_Y = 0;
								}
							}
							else
							{
								clicked_X = LeftX_End - clickPosition.x;
								FinalPosition_Y = Limit_Height - (Limit_Height - (Limit_Height-156.0f - TextureHeight))*(clicked_X / (LeftX_End-LeftX_Start));
								if(this.transform.position.y >= FinalPosition_Y)
								{
									isMoveUp = false;

									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}

									Distance_Y =  this.transform.position.y - FinalPosition_Y;
									
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
								else
								{
									isMoveUp = true;

									if(FinalPosition_Y <= TextureHeight + 156.0f) 
									{
										FinalPosition_Y = TextureHeight + 156.0f;
									}

									Distance_Y =  FinalPosition_Y - this.transform.position.y;
									if(Distance_Y <= 0)
									{
										reached_Y = true;
										Distance_Y = 0;
									}
								}
							}
						}
						// If destination coordinate Y is bigger than player Y (Moving Up)
						else if(clickPosition.y > this.transform.position.y)
						{
							if(clickPosition.y + TextureHeight >= WalkableLimit_Height) 
							{
								clickPosition.y = WalkableLimit_Height - TextureHeight;
							}
							/*
							if(Change_Y == true)
							{
								float clicked_X;
								clicked_X = clickPosition.x - RightX_Start;
								FinalPosition_Y = Limit_Height - ((Limit_Height-156.0f))*(clicked_X / (RightX_End-RightX_Start));
								
								Distance_Y = FinalPosition_Y - this.transform.position.y;
							}
							else
							{
							*/
								Distance_Y = clickPosition.y - this.transform.position.y;
							//}
							isMoveUp = true;
							if(Distance_Y <= 0)
							{
								reached_Y = true;
								Distance_Y = 0;
							}
						}
						// If destination Player Y is bigger than coordinate Y (Moving Down)
						else
						{
							if(clickPosition.y - TextureHeight <= 156.0f) 
							{
								clickPosition.y = TextureHeight + 156.0f;
							}

							Distance_Y =  this.transform.position.y - clickPosition.y;

							isMoveUp = false;
							if(Distance_Y <= 0)
							{
								reached_Y = true;
								Distance_Y = 0;
							}
						}
						
						//Calculate Speed
						if(Distance_X > Distance_Y)
						{
							playerSpeed.x = Speed;
							playerSpeed.y = Distance_Y/Distance_X * Speed;
						}
						else
						{
							playerSpeed.x = Distance_X/Distance_Y * Speed;
							playerSpeed.y = Speed;
						}
					}
				}
			}
		}
	}
	
	//Moving Player 
	void MovePlayer ()
	{
		//Check if 
		if (PlayerAnimator.GetBool("isWalking") == true) 
		{
			if(isMoveRight == false)
			{
				//If the player current Position is Bigger than the destination coordinate X (Move Left)
				if(this.transform.position.x  == clickPosition.x || reached_X == true)
				{
					reached_X = true;
				}
				else if(this.transform.position.x  > clickPosition.x)
				{
					//Move Player to the Right
					this.transform.position = new Vector3(this.transform.position.x - (playerSpeed.x * Time.deltaTime), this.transform.position.y, this.transform.position.z);
					
					//If it reaches/smaller to the destination coordinate X, set it to the destination coordinate X
					if(this.transform.position.x <= clickPosition.x)
					{
						this.transform.position = new Vector3(clickPosition.x, this.transform.position.y, this.transform.position.z);
						reached_X = true;
					}
				}
			}
			else
			{
				//If the player current Position is Smaller than the destination Coordinate X (Move Right)
				if(this.transform.position.x  == clickPosition.x || reached_X == true)
				{
					reached_X = true;
				}
				else if(this.transform.position.x < clickPosition.x)
				{
					//Move Player to the Right
					this.transform.position = new Vector3(this.transform.position.x + (playerSpeed.x * Time.deltaTime), this.transform.position.y, this.transform.position.z);
					
					//If it reaches/over to the destination coordinate X, set it to the destination coordinate X
					if(this.transform.position.x >= clickPosition.x)
					{
						this.transform.position = new Vector3(clickPosition.x, this.transform.position.y, this.transform.position.z);
						reached_X = true;
					}
				}
			}

			if(Change_Y_Right == true)
			{
				//Move Player to the Right
				if(isMoveRight == true)
				{
					if(isMoveUp == true)
					{
						this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (playerSpeed.y * Time.deltaTime), this.transform.position.z);
						
						if(this.transform.position.y >= FinalPosition_Y)
						{
							this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
							reached_Y = true;
						}
					}
					else
					{
						this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (playerSpeed.y * Time.deltaTime), this.transform.position.z);

						if(this.transform.position.y <= FinalPosition_Y)
						{
							this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
							reached_Y = true;
						}
					}
				}
				else
				{
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (playerSpeed.y * Time.deltaTime), this.transform.position.z);
					
					if(this.transform.position.y >= FinalPosition_Y)
					{
						this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
						reached_Y = true;
					}
				}
			}
			else if(Change_Y_Left == true)
			{
				//Move Player to the Right
				if(isMoveRight == false)
				{
					if(isMoveUp == true)
					{
						this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (playerSpeed.y * Time.deltaTime), this.transform.position.z);
						
						if(this.transform.position.y >= FinalPosition_Y)
						{
							this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
							reached_Y = true;
						}
					}
					else
					{
						this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (playerSpeed.y * Time.deltaTime), this.transform.position.z);
						
						if(this.transform.position.y <= FinalPosition_Y)
						{
							this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
							reached_Y = true;
						}
					}
				}
				else
				{
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (playerSpeed.y * Time.deltaTime), this.transform.position.z);
					
					if(this.transform.position.y >= FinalPosition_Y)
					{
						this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
						reached_Y = true;
					}
				}
			}
			else if(isMoveUp == false)
			{
				//If the player current Position is Bigger than the destination coordinate Y (Move Down)
				if(this.transform.position.y == clickPosition.y || reached_Y == true)
				{
					reached_Y = true;
				}
				else if(this.transform.position.y > clickPosition.y )
				{
					//Move Player to the Right
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (playerSpeed.y * Time.deltaTime), this.transform.position.z);
					/*
					if(Change_Y == true)
					{
						if(this.transform.position.y <= clickPosition.y)
						{
							this.transform.position = new Vector3(this.transform.position.x, FinalPosition_Y,  this.transform.position.z);
							reached_Y = true;
						}
					}*/
					//If it reaches/smaller to the destination coordinate Y, set it to the destination coordinate Y
					if(this.transform.position.y <= clickPosition.y)
					{
						this.transform.position = new Vector3(this.transform.position.x, clickPosition.y,  this.transform.position.z);
						reached_Y = true;
					}
				}
			}
			else
			{
				//If the player current Position is Smaller than the destination Coordinate Y (Move Up)
				if(this.transform.position.y == clickPosition.y || reached_Y == true)
				{
					reached_Y = true;
				}
				else if(this.transform.position.y < clickPosition.y)
				{
					//Move Player to the Right
					this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (playerSpeed.y * Time.deltaTime), this.transform.position.z);

					//If it reaches/over to the destination coordinate Y, set it to the destination coordinate Y
					if(this.transform.position.y >= clickPosition.y)
					{
						this.transform.position = new Vector3(this.transform.position.x, clickPosition.y,  this.transform.position.z);
						reached_Y = true;
					}
				}
			}
			
			//It reaches it destination coordinate x and y (make it stop moving)
			if(reached_X == true && reached_Y == true && PlayerAnimator.GetBool("isWalking") == true)
			{
				PlayerAnimator.SetBool("isWalking", false);
				PlayerAnimator.SetFloat("IdleTime", 0.0f);
				
			}
		}
		//Odysseus only
		else
		{
            PlayerAnimator.SetFloat("IdleTime", PlayerAnimator.GetFloat("IdleTime") + Time.deltaTime);
		}
	}
	
	bool SpriteToSpriteCollision(Vector3 Position_1, float Width_1, float Height_1, float ScaleX1, float ScaleY1, Vector3 Position_2, float Width_2, float Height_2, float ScaleX2, float ScaleY2)
	{
		float x1Min, x1Max, y1Min,y1Max;
		float x2Min, x2Max, y2Min,y2Max;
		if(ScaleX1 > 0)
		{
			x1Min = Position_1.x;
			x1Max = Position_1.x+(Width_1*ScaleX1);
			y1Min = Position_1.y-(Height_1*ScaleY1);
			y1Max = Position_1.y-(Height_1*ScaleY1)/2.0f;
			//y1Max = Position_1.y;

			if (ScaleX2 > 0) {
				x2Min = Position_2.x-(Width_2*ScaleX2);
				x2Max = Position_2.x+(Width_2*ScaleX2);
				y2Min = Position_2.y-(Height_2*ScaleY2);
				//y2Max = Position_2.y;
				y2Max = Position_2.y+(Height_2*ScaleY2)/1.2f;
			}

			else {
				x2Min = Position_2.x-(-Width_2*ScaleX2);
				x2Max = Position_2.x+(-Width_2*ScaleX2);
				y2Min = Position_2.y-(Height_2*ScaleY2);
				//y2Max = Position_2.y;
				y2Max = Position_2.y+(Height_2*ScaleY2)/1.2f;
			}
		}
		else
		{
			x1Min = Position_1.x-(-Width_1*ScaleX1);
			x1Max = Position_1.x;
			y1Min = Position_1.y-(Height_1*ScaleY1);
			y1Max = Position_1.y-(Height_1*ScaleY1)/2.0f;
			//y1Max = Position_1.y;
			
			if (ScaleX2 > 0) {
				x2Min = Position_2.x-(Width_2*ScaleX2);
				x2Max = Position_2.x+(Width_2*ScaleX2);
				y2Min = Position_2.y-(Height_2*ScaleY2);
				//y2Max = Position_2.y;
				y2Max = Position_2.y+(Height_2*ScaleY2)/1.2f;
			}
			
			else {
				x2Min = Position_2.x-(-Width_2*ScaleX2);
				x2Max = Position_2.x+(-Width_2*ScaleX2);
				y2Min = Position_2.y-(Height_2*ScaleY2);
				//y2Max = Position_2.y;
				y2Max = Position_2.y+(Height_2*ScaleY2)/1.2f;
			}
		}
		// Collision tests
		if( x1Max < x2Min || x1Min > x2Max ) return false;
		if( y1Max < y2Min || y1Min > y2Max ) return false;
		return true;
	}

	//To Stop doing anything
	IEnumerator stopAction()
	{
		yield return new WaitForSeconds (1.0f);
		PlayerAnimator.SetBool("isDoingSomething", false);
	}
	//To stop cutting animation
	IEnumerator stopCutting()
	{
		yield return new WaitForSeconds (0.5f);
		PlayerAnimator.SetBool("isCutting", false);
	}
	IEnumerator stopChoppedBush()
	{
		yield return new WaitForSeconds (0.5f);
		Bush.GetComponent<Animator>().SetBool("isChopped", false);
		yield return new WaitForSeconds (0.5f);
		Destroy (Bush.gameObject);
	}
	IEnumerator stopThrowingSpear()
	{
		yield return new WaitForSeconds (0.01f);
		GameObject.Find("PlayerImage").GetComponent<Animator>().SetBool("isThrowing", false);
		yield return new WaitForSeconds (1.0f);
		GameObject.Find ("Deer").SetActive(false);
		GameObject.Find ("DeadDeer").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find ("DeadDeer_Collision").GetComponent<SpriteRenderer>().enabled = true;
	}
	IEnumerator FlyingSpear()
	{
		yield return new WaitForSeconds (0.5f);
		GameObject.Find("Spear").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("Spear").transform.position = new Vector3 (1088.0f, 272.0f, 0.0f);
		yield return new WaitForSeconds (0.5f);
		GameObject.Find("Spear").GetComponent<SpriteRenderer>().enabled = false;
	}
	IEnumerator FlyingSpear2()
	{
		yield return new WaitForSeconds (0.5f);
		GameObject.Find("Spear").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("Spear").transform.position = new Vector3 (55.3f, 563.4f, 0.0f);
		yield return new WaitForSeconds (0.5f);
		GameObject.Find("Spear").GetComponent<SpriteRenderer>().enabled = false;
	}
	IEnumerator DroppingBeehive()
	{
		yield return new WaitForSeconds (0.5f);
		GameObject.Find("BeeHive").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("BeeHiveDrop").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("BeeHiveImage").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("BeeHiveDrop").GetComponent<ObjectMovement>().enabled = true;
	}



	void CombineListEnviromentItem (int Item_Index, int EnviromentItem_Index)
	{
		if(Item_Index == 10 && EnviromentItem_Index == 17)
		{
			Sprite sprite;
			sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[17].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			GameObject.Find("Closet").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("Closet").GetComponent<Interact>().InteractID = 2;
			GameObject.Find("Closet").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[81];
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);

			
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[10];
			
			//GameObject.Find("Closet").GetComponent<ClickableObject>().PlayerUpdate = false;
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseKeyOnCloset = true;
		}
		if(Item_Index == 11 && EnviromentItem_Index == 26)
		{
			Sprite sprite;
			sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[20].height), new Vector2 (0.0f, 1.0f), 1.0f);
			
			//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
			GameObject.Find("Tree").GetComponent<SpriteRenderer>().sprite = sprite;
			GameObject.Find("CollisionBoxForTree").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[179];
			//GameObject.Find("CollisionBoxForTree").GetComponent<ObjectInformation>().ObjectID = 0;
			GameObject.Find("CollisionBoxForTree").GetComponent<Interact>().enabled = false;
			GameObject.Find("CollisionBoxForTree").GetComponent<ClickableObject>().b_Interact = false;
			
			//GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			
			
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader>().OneLiner[15];
			
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ChopTreeBranch = true;
			
			GameObject.Find("TreeBranch").transform.position = new Vector3(400.0f, 623.0f, 0.0f);
			GameObject.Find("TreeBranch").GetComponent<ObjectMovement>().enabled = true;
			//GameObject.Find("CollisionBoxForTree").GetComponent<ClickableObject>().PlayerUpdate = false;
		}
		if(Item_Index == 1 && EnviromentItem_Index == 30)
		{
			GameObject.Find("BurntWood").GetComponent<ObjectInformation>().enabled = false;
			GameObject.Find("BurntWood").GetComponent<Observe>().enabled = false;
			GameObject.Find("BurntWood").GetComponent<ClickableObject>().enabled = false;
			GameObject.Find("BurntWood").GetComponent<ClickableObject>().PlayerUpdate = false;

			
			GameObject.Find("FireOnWood").transform.position = new Vector3 (720.0f, 625.0f, 0.0f);
			GameObject.Find("FireOnWood").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[43];
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().LightedBurntWood = true;
			SFXFire.Play();

			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[17];
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(1);
		}
		if(((Item_Index == 16 && EnviromentItem_Index == 31) || (Item_Index == 27 && EnviromentItem_Index == 31) || (Item_Index == 28 && EnviromentItem_Index == 31)) && GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod == false)
		{
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().OfferedCheeseToGod = true;
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[18];
		}

		if(Item_Index == 11 && EnviromentItem_Index == 34)
		{
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseSwordOnCyclops = true;
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[19];
			//GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			//GameObject.Find("Cyclops").GetComponent<ClickableObject>().PlayerUpdate = false;
		}
		if (Item_Index == 11 && EnviromentItem_Index == 29)
		{
			if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishThinkingOfIdea) {
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetOsierBands = true;
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(12);
				GameObject.Find("osier-bed").SetActive(false);
				GameObject.Find("cut-bed").GetComponent<SpriteRenderer>().enabled = true;
			}
		}

		if (Item_Index == 11 && EnviromentItem_Index == 40) 
		{
			PlayerAnimator.SetBool("isCutting", true);
			Bush.GetComponent<Animator>().SetBool("isChopped", true);

			StartCoroutine(stopCutting());
			StartCoroutine(stopChoppedBush());

			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownBush = true;
			GameObject.Find("Bush").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find ("Bush_Collision").SetActive(false);
			GameObject.Find("Bush_Sprite").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("ExitToForest").GetComponent<ExitBox>().enabled = true;
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[35];
		}

		if (Item_Index == 44 && EnviromentItem_Index == 41) 
		{
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CutDownTree = true;
			GameObject.Find("Dead_Tree").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Dead_Tree").SetActive(false);
			GameObject.Find("Fallen_Tree").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("ExitToCave").GetComponent<ExitBox>().enabled = true;
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[35];
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
		}

		if (Item_Index == 11 && EnviromentItem_Index == 42) 
		{
			if(GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID >= 7)
			{
				GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = "I can't carry any more stuff.";
			}

			else 
			{
				if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines == false) {
					GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetVines = true;
					GameObject.Find("Vines_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [273];
					GameObject.Find("Vines").GetComponent<SpriteRenderer>().enabled = false;
					GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(44);
				}
			}
		}

		if (Item_Index == 12 && EnviromentItem_Index == 50) 
		{
			GameObject.Find("LevelProgression").GetComponent<LevelProgress>().FinishTyingSheeps = true;
			GameObject.Find("Sheep_1").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Sheep_2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Sheep_3").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Sheep_collision").GetComponent<SpriteRenderer>().enabled = false;
			//GameObject.Find("Sheep_collision").GetComponent<ClickableObject>().PlayerUpdate = false;

			GameObject.Find("Tied_Sheeps").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Tied_Sheeps").GetComponent<ClickableObject>().PlayerUpdate = false;

			int tempID = 0;
			for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
			{
				int tempStorage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
				if(tempStorage == Item_Index)
				{
					tempID = tempStorage;
				}
			}
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID); // Delete the Osier bands
			GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
			GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[20];

		}
		//Debug.Log (once);
		if(once == false)
		{
			if(Item_Index == 14 && EnviromentItem_Index == 24)
			{
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit = true;
					
				Sprite sprite;
				sprite = Sprite.Create (GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[35], new Rect(0, 0, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[35].width, GameObject.Find("InventoryBag").GetComponent<Inventory>().IconTexture[35].height), new Vector2 (0.0f, 1.0f), 1.0f);
					
				//sprite = Sprite.Create (TempTexture, new Rect (0.0f, 0.0f, 125.0f, 120.0f), new Vector2 (0.0f, 1.0f), 1.0f);
				GameObject.Find("SheepShit").GetComponent<SpriteRenderer>().sprite = sprite;
				GameObject.Find("SheepShit").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[114];
					
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
					
				GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(9);
			}
		}

		if (Item_Index == 14 && EnviromentItem_Index == 34) 
		{
			if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep == true) {
				GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[21];
			}
		}

		//Stick on fire to make fire stick
		if (Item_Index == 14 && EnviromentItem_Index == 31) 
		{
			if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().CyclopsAsleep == true) {
				int tempID = 0;
				for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
				{
					int tempStorage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
					if(tempStorage == Item_Index)
					{
						tempID = tempStorage;
					}
				}
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(15);

				GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[22];
			}
		}

		//Load Pokingeyeminigame after using fire stick on cyclop
		if (Item_Index == 15 && EnviromentItem_Index == 34) 
		{
			int tempID = 0;
			for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
			{
				int tempStorage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
				if(tempStorage == Item_Index)
				{
					tempID = tempStorage;
				}
			}
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
			GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
			GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "PokingEyeMiniGame";
			//GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
			//GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(21);
		}

		if( Item_Index == 5 && EnviromentItem_Index == 34)
		{
			if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().SharpenBranchInShit == true)
			{
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce = true;
				
				//Delete away one feta cheese
				int tempID = 0;
				for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
				{
					int tempStorage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
					if(tempStorage == Item_Index)
					{
						tempID = tempStorage;
					}
				}
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(3);
			}
		}
		
		if(Item_Index == 3 && EnviromentItem_Index == 34)
		{
			if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsOnce == true)
			{
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsTwice = true;
				
				//Delete away one feta cheese
				int tempID = 0;
				for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
				{
					int tempStorage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
					if(tempStorage == Item_Index)
					{
						tempID = tempStorage;
					}
				}
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(2);
				GameObject.Find ("Cyclops_TwoThirdDrunk").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.Find ("Cyclops_OneThirdDrunk").GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		

		if(Item_Index == 2 && EnviromentItem_Index == 34)
		{
			//if(GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsTwice == true)
			//{
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().UseWineOnCyclopsThird = true;
				
				//Delete away one feta cheese
				int tempID = 0;
				for(int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++)
				{
					int tempStorage = GameObject.Find("InventoryItem_"+ i).GetComponent<ObjectInformation>().ObjectID;
					if(tempStorage == Item_Index)
					{
						tempID = tempStorage;
					}
				}
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(tempID);
				//GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(20);
				GameObject.Find ("Cyclops_TwoThirdDrunk").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find ("Cyclops_FullyDrunk").GetComponent<SpriteRenderer>().enabled = true;
			//}
		}

		//Spear & deer on cliff
		if (Item_Index == 60 && EnviromentItem_Index == 62) 
		{
			GameObject.Find("PlayerImage").GetComponent<Animator>().SetBool("isThrowing", true);
			GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer = true;

			GameObject.Find("Deer_Collision").GetComponent<Observe>().English_Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[15];
			StartCoroutine(stopThrowingSpear());
			StartCoroutine(FlyingSpear());
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
		}

		//Spear & maze/smoke on cliff
		if (Item_Index == 60 && EnviromentItem_Index == 85) 
		{	
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [84];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}

		//Spear & maze/smoke on cliff
		if (Item_Index == 60 && EnviromentItem_Index == 86) 
		{	
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [85];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
		}


		//Sword and grass on shore
		if (Item_Index == 11 && EnviromentItem_Index == 63) 
		{
			if(GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID >= 7)
			{
				GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = "I can't carry any more stuff.";
			}
			
			else
			{
				if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass == false) 
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGrass = true;
					GameObject.Find("Grass_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [8];
					PlayerAnimator.SetBool("isDoingSomething", true);
					StartCoroutine(stopAction()); 
					GameObject.Find("Grass").GetComponent<SpriteRenderer>().enabled = false;
					GameObject.Find ("Grass").SetActive (false);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(63);
				}
			}
		}

		//Rope and dead deer at clearing
		if (Item_Index == 64 && EnviromentItem_Index == 87 && GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().killedDeer == true) 
		{
			if(GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID >= 7)
			{
				GameObject.Find("/DescriptionBox").GetComponent<DescriptionBox>().enabled = true;
				GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().Description = "I can't carry any more stuff.";
			}
			
			else 
			{
				if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer == false) 
				{
					GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer = true;
					GameObject.Find("Deer_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [11];
					GameObject.Find("DeadDeer").GetComponent<SpriteRenderer>().enabled = false;
					GameObject.Find("DeadDeer").SetActive(false);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(65);
				}
			}
		}

		//Deer and chef at deck
		if (Item_Index == 65 && EnviromentItem_Index == 66) 
		{
			if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().tiedDeer == true) 
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().part1Completed = true;
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().passDeerToChef = true;
					GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(25);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
				}
		}

		//Spear and beehive 
		if (Item_Index == 60 && EnviromentItem_Index == 68) 
		{
			if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().helmWithSilk == true)
			{
			if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().shotBeeHive == false)
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().shotBeeHive = true;
					PlayerAnimator.SetBool("isThrowing", true);
					StartCoroutine(stopThrowingSpear());
					StartCoroutine(FlyingSpear2());
					StartCoroutine(DroppingBeehive());
					GameObject.Find ("Bee_Collision").SetActive (false);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
				}
			}
			else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().helmWithSilk == false)
			{
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [54];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			}
		}

		//Feed meat to lion
		if (Item_Index == 81 && EnviromentItem_Index == 52 && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedLion == false) 
		{

			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [47];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedLion = true;
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);

			if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedLion == true)
			{
				GameObject.Find ("Lion_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [79];
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [79];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			}
		}

		//Feed meat to wolf
		if (Item_Index == 81 && EnviromentItem_Index == 53 && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedWolf == false) 
		{
			GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [47];
			GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedWolf = true;
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);

			if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().feedWolf == true)
			{
				GameObject.Find ("Wolf_Collision").GetComponent<Observe> ().English_Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [79];
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [79];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
			}
		}

		//Sword on circe
		if (Item_Index == 11 && EnviromentItem_Index == 83 && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().combineMolyWithWine == true) 
		{
			GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().DisplayDialogue(34);
		}

		// Chapter 3
		// bowl + river = bowl with water
		if (Item_Index == 53 &&  EnviromentItem_Index == 351) 
		{
			print ("123123");
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(54);
		}

		// bowl with water + river = bowl
		if (Item_Index == 54 &&  EnviromentItem_Index == 351) 
		{
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(53);
		}

		// unheated animal glue + fire pit = heated animal glue
		if (Item_Index == 55 &&  EnviromentItem_Index == 352) 
		{
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(56);
		}

		//shovel on pile of dirt
		if (Item_Index == 59 &&  EnviromentItem_Index == 100) 
		{
			GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
			GameObject.Find("Closet").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Closet1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Closet1").GetComponent<ClickableObject>().PlayerUpdate = false;

			//GameObject.Find("Closet1").AddComponent<Observe>();
			//GameObject.Find("Closet1").GetComponent<Observe>().Button_Width = 120;
			//GameObject.Find("Closet1").GetComponent<Observe>().Button_Height = 38;
			//.Find("Closet1").GetComponent<Observe>().guiskin = "GUISkin_Button";
		}

		//if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetHoneyComb2 == true)
		//{
			//Helmet get water
			if (Item_Index == 67 && EnviromentItem_Index == 69) 
			{
				if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().filledHelmWithWater == false)
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = true;
					GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(70);
				}
			}
			
			//Helmet remove water
			if (Item_Index == 70 && EnviromentItem_Index == 69) 
			{
				if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().filledHelmWithWater == true) 
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = false;
					GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(67);
				}
			}
			
			//Helmet remove hot water
			if (Item_Index == 71 && EnviromentItem_Index == 69) 
			{
				if (GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().filledHelmWithWater == true) 
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().filledHelmWithWater = false;
					GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
					GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(67);
				}
			}
			
			//warm up water
			if (Item_Index == 70 && EnviromentItem_Index == 76) 
			{
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [46];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(71);
			}
			
			//warm up tea
			if (Item_Index == 72 && EnviromentItem_Index == 76) 
			{
				GameObject.Find ("DescriptionBox").GetComponent<DescriptionBox> ().Description = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description [47];
				GameObject.Find ("/DescriptionBox").GetComponent<DescriptionBox> ().enabled = true;
				GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWarmTea = true;
				GameObject.Find("InventoryBag").GetComponent<Inventory>().DestoryItemIcon(Item_Index);
				GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(73);
			}
		//}


		GameObject[] TagObjects = GameObject.FindGameObjectsWithTag("InteractableObject");
		foreach (GameObject TagObject in TagObjects) {
			if (TagObject.GetComponent<ObjectInformation>().ObjectID == EnviromentItem_Index) {
				TagObject.GetComponent<ClickableObject>().PlayerUpdate = false;
			}
		}
	}

	bool PointToSpriteCollision (Vector3 pointPosition, Vector3 SpritePosition, float width, float height, float ScaleX, float ScaleY)
	{
		if (pointPosition.x >= (SpritePosition.x -(width*0.5*ScaleX)) && pointPosition.x <= (SpritePosition.x + (width*0.5*ScaleX))) {
			if (pointPosition.y >= (SpritePosition.y - (height*0.5*ScaleY)) && pointPosition.y <= (SpritePosition.y + (height*0.5*ScaleY)))
				return true;
		}
		return false;
	}
}
