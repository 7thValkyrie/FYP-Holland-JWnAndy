using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	static int TotalScorePoint = 0;
	static int TotalMenCounter = 4;

	SpriteRenderer WinningMove;
	SpriteRenderer RightTargetBox;
	SpriteRenderer LeftTargetBox;
	SpriteRenderer UpTargetBox;
	SpriteRenderer Bug_1;
	SpriteRenderer Bug_2;
	SpriteRenderer Bug_3;
	SpriteRenderer Bug_4;
	Insect insect_1;
	Insect insect_2;
	Insect insect_3;
	Insect insect_4;
	private GUIText GUIScore;
	private GUIText GUIMen;
	public int ScorePoint;
	private float RecoveryTime;
	public bool isRecovering;
	private bool stopmoving;
	private bool resetcounter;
	//public int MenCounter = 4;
	public AudioSource SFXPunchLeft;
	public AudioSource SFXPunchUp;
	public AudioSource SFXPunchRight;
	private float timer;

	public Texture LeftBtn;

	// Use this for initialization
	void Start () 
	{
		TotalScorePoint = 0;
		TotalMenCounter = 4;
		RightTargetBox = GameObject.Find ("TargetBox_Right").GetComponent<SpriteRenderer> ();
		LeftTargetBox = GameObject.Find ("TargetBox_Left").GetComponent<SpriteRenderer> ();
		UpTargetBox = GameObject.Find ("TargetBox_Up").GetComponent<SpriteRenderer> ();
		Bug_1 = GameObject.Find ("Bug_1").GetComponent<SpriteRenderer> ();
		Bug_2 = GameObject.Find ("Bug_2").GetComponent<SpriteRenderer> ();
		Bug_3 = GameObject.Find ("Bug_3").GetComponent<SpriteRenderer> ();
		Bug_4 = GameObject.Find ("Bug_4").GetComponent<SpriteRenderer> ();
		insect_1 = GameObject.Find ("Bug_1").GetComponent<Insect> ();
		insect_2 = GameObject.Find ("Bug_2").GetComponent<Insect> ();
		insect_3 = GameObject.Find ("Bug_3").GetComponent<Insect> ();
		insect_4 = GameObject.Find ("Bug_4").GetComponent<Insect> ();
		GUIScore = GameObject.Find ("GUIText_Score").GetComponent<GUIText> ();
		GUIMen = GameObject.Find ("GUIText_MenCounter").GetComponent<GUIText> ();
		ScorePoint = 0;

		if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
			GUIMen.text = "Number Of Men Left:" + TotalMenCounter;
			GUIScore.text = "Insect Squashed:" + TotalScorePoint;
		} 

		else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
			GUIMen.text = "Aantal mannen over:" + TotalMenCounter;
			GUIScore.text = "Insect Geplet:" + TotalScorePoint;
		}
		//ComboCount = 0;
		//GUICombo.text = "Combo X " + ComboCount;
		
		//stopmoving = false;
		RecoveryTime = 0.0f;
		isRecovering = false;

	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find("TutorialScript").GetComponent<TutorialScript>().Ready == true) {
		//Debug.Log (ScorePoint);
			//GameObject.Find ("InGameInstructions").GetComponent<SpriteRenderer>().enabled = true;
			if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				GameObject.Find ("InGameInstructions").GetComponent<SpriteRenderer>().enabled = true;
			}
			else if(Application.platform == RuntimePlatform.Android)
			{
				GameObject.Find ("InGameInstructionsAndroid").GetComponent<SpriteRenderer>().enabled = true;
			}
			GameObject.Find ("MenImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("BugsImage").GetComponent<SpriteRenderer>().enabled = true;
			if (GameObject.Find ("Background").GetComponent<RandomGenerator> ().over == true) {

				//Debug.Log ("Anything");

				
				if (GameObject.Find("Player").transform.position.x < 205.0f ) {
					GameObject.Find ("Player").GetComponent<Animator>().SetInteger("Index", 5);
					GameObject.Find ("Player2").GetComponent<Animator>().SetInteger("Index", 5);
					GameObject.Find ("Player3").GetComponent<Animator>().SetInteger("Index", 5);
				}
				else { 
					GameObject.Find ("Player").GetComponent<Animator>().SetInteger("Index", 0);
					GameObject.Find ("Player2").GetComponent<Animator>().SetInteger("Index", 0);
					GameObject.Find ("Player3").GetComponent<Animator>().SetInteger("Index", 0);
				}
				if (this.transform.position.x <= -466) {
					GameObject.Find ("Player").GetComponent<Animator>().SetInteger("Index",  5);
					GameObject.Find ("Player2").GetComponent<Animator>().SetInteger("Index",  5);
					GameObject.Find ("Player3").GetComponent<Animator>().SetInteger("Index",  5);
					GameObject.Find ("Background").GetComponent<RandomGenerator> ().CalculateRandom ();
					GameObject.Find ("Player").GetComponent<SpriteRenderer> ().enabled = false;
					GameObject.Find ("Player2").GetComponent<SpriteRenderer> ().enabled = false;
					GameObject.Find ("Player3").GetComponent<SpriteRenderer> ().enabled = false;
				}
				
				if (GameObject.Find ("Background").GetComponent<RandomGenerator> ().random_value == 1) {
					GameObject.Find ("Player").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("Player2").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("Player3").GetComponent<SpriteRenderer> ().enabled = true;
				} else if (GameObject.Find ("Background").GetComponent<RandomGenerator> ().random_value == 2) {
					GameObject.Find ("Player").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("Player2").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("Player3").GetComponent<SpriteRenderer> ().enabled = true;
				} else if (GameObject.Find ("Background").GetComponent<RandomGenerator> ().random_value == 3) {
					GameObject.Find ("Player3").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("Player2").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("Player").GetComponent<SpriteRenderer> ().enabled = true;
				}

				if (this.transform.position.x <= -800)
					this.transform.position = new Vector3 (1405.551f, 498.5139f, 0.0f);

						
			this.transform.position += new Vector3 (-10, 0, 0);

				// RESET 	// RESET 	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET 
			if (this.transform.position.x <= 406 && this.transform.position.x >= 405) {
				insect_1.RespawnBug();
				insect_2.RespawnBug();
				insect_3.RespawnBug();
				insect_4.RespawnBug();
				timer = 0;

					// RESET	// RESET	// RESET	// RESET 405	// RESET	// RESET	// RESET	// RESET	// RESET
				this.transform.position = new Vector3(405.5591f, 498.5139f, 0.0f);
				GameObject.Find("Player").GetComponent<Player>().ScorePoint = 0;
				GameObject.Find("Player2").GetComponent<Player>().ScorePoint = 0;
				GameObject.Find("Player3").GetComponent<Player>().ScorePoint = 0;
				GameObject.Find ("Bug_1").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("Bug_2").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("Bug_3").GetComponent<SpriteRenderer> ().enabled = true;				
				GameObject.Find ("Bug_4").GetComponent<SpriteRenderer> ().enabled = true;
				this.ScorePoint = 0;
					TotalScorePoint = 0;
					if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
						
						GUIScore.text = "Insect Squashed:" + TotalScorePoint;
					} 
					
					else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
						
						GUIScore.text = "Insect Geplet:" + TotalScorePoint;
					}
				//stopmoving = true;

					//GameObject.Find ("Player").GetComponent<Player>().MenCounter -=1;
					//GameObject.Find ("Player2").GetComponent<Player>().MenCounter -=1;
					//GameObject.Find ("Player3").GetComponent<Player>().MenCounter -=1;
					//GUIMen.text = "Number of Men Left: " + MenCounter;
			}
				// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET	// RESET
			//if (GameObject.Find("Player").transform.position == new Vector3(205.0f, 498.5139f, 0.0f) &&
			    //GameObject.Find("Player2").transform.position == new Vector3(405.0f, 498.5139f, 0.0f) && 
			    //GameObject.Find("Player3").transform.position == new Vector3(605.0f, 498.5139f, 0.0f) )
				if (GameObject.Find("Player").transform.position.x < 205.0f && GameObject.Find("Player").transform.position.x >= 195.0f )
					//&&
				
					    //GameObject.Find("Player2").transform.position.x < 405.0f && 
					    //GameObject.Find("Player3").transform.position.x < 605.0f )
				{
				GameObject.Find ("Background").GetComponent<RandomGenerator> ().over = false;
					//Debug.Log(GameObject.Find("Player").transform.position.x);
			}
			}
			//}
			//}
			else if (this.GetComponent<SpriteRenderer>().enabled == true){
				if (timer <= 1)
					isRecovering = false;
					InputUpdate ();	
			}
			if ( TotalMenCounter == 0 && TotalScorePoint == 0 )
			{
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Beach";
			}

			timer += Time.deltaTime;
		}

	}
	
	void InputUpdate()
	{
		// Setting player at his original state before proceeding into other state
		GameObject.Find ("Player").GetComponent<Animator> ().SetInteger ("Index", 0);
		GameObject.Find ("Player2").GetComponent<Animator> ().SetInteger ("Index", 0);
		GameObject.Find ("Player3").GetComponent<Animator> ().SetInteger ("Index", 0);
		if (isRecovering == true) {
			RecoveryTime += Time.deltaTime;
			//tells you how long player takes to recover after
			//every insect misses he gets
			if (RecoveryTime >=0.2f) {
				RecoveryTime = 0.0f;
				isRecovering = false;
				GameObject.Find ("Player").GetComponent<Animator> ().SetInteger ("Index", 0);
				GameObject.Find ("Player2").GetComponent<Animator> ().SetInteger ("Index", 0);
				GameObject.Find ("Player3").GetComponent<Animator> ().SetInteger ("Index", 0);
			}

				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);         
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					UpTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);         
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					RightTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);      
				}

			if(Input.GetKey(KeyCode.Escape))
			{
				TotalMenCounter = 0;
			}
			GameObject.Find ("Player").GetComponent<Animator> ().SetInteger ("Index", 4);
			GameObject.Find ("Player2").GetComponent<Animator> ().SetInteger ("Index", 4);
			GameObject.Find ("Player3").GetComponent<Animator> ().SetInteger ("Index", 4);
			
		} 
		else {
			// PLAYER DIRECTION HITTING 
			if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				if (TotalScorePoint < 5) {
					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						// Animator to indicate the picture that character is turning left 
						GameObject.Find("Player").GetComponent<Animator>().SetInteger("Index", 3);
						LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.0f, 0.0f); 
						if (CheckCollisionWithBug (LeftTargetBox) == true) {
							//ScorePoint += 1;
							
							if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
								
								GUIScore.text = "Insect Squashed:" + TotalScorePoint;
							} 
							
							else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
								
								GUIScore.text = "Insect Geplet:" + TotalScorePoint;
							}
							//LeftTargetBox.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);         
						}
						
					}
					else if (Input.GetKey (KeyCode.LeftArrow)) {
						SFXPunchLeft.Play();
						GameObject.Find("Player").GetComponent<Animator>().SetInteger("Index", 3);
						
					}
					else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
						//PlayerAnimator.SetInteger ("Index", 0);
						LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f); 
						//	PlayerAnimator.SetInteger ("Index", 0);        
					}
					// if character hits upwards
					if (Input.GetKeyDown (KeyCode.UpArrow)) {
						SFXPunchUp.Play ();
						GameObject.Find ("Player2").GetComponent<Animator>().SetInteger("Index", 1 );
						UpTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.0f, 0.0f);   
						if (CheckCollisionWithBug (UpTargetBox) == true) {
							//ScorePoint += 1;
							if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
								
								GUIScore.text = "Insect Squashed:" + TotalScorePoint;
							} 
							
							else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
								
								GUIScore.text = "Insect Geplet:" + TotalScorePoint;
							}
						}
					}

					else if (Input.GetKey (KeyCode.UpArrow)) {
						SFXPunchLeft.Play();
						GameObject.Find("Player2").GetComponent<Animator>().SetInteger("Index", 1);
					}

					else if (Input.GetKeyUp (KeyCode.UpArrow)) {
						//GameObject.Find("Player2").GetComponent<Animator>().SetInteger("Index", 1);
						UpTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);         
					}

					//If player hits right
					if (Input.GetKeyDown (KeyCode.RightArrow)) {
						SFXPunchRight.Play();
						GameObject.Find("Player3").GetComponent<Animator>().SetInteger("Index", 2);
		
						RightTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.0f, 0.0f);    
						if (CheckCollisionWithBug (RightTargetBox) == true) {
							//ScorePoint += 1;
							if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
								
								GUIScore.text = "Insect Squashed:" + TotalScorePoint;
							} 
							
							else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
								
								GUIScore.text = "Insect Geplet:" + TotalScorePoint;
							}
						}
					} 
					else if (Input.GetKey (KeyCode.RightArrow)) {
						GameObject.Find("Player3").GetComponent<Animator>().SetInteger("Index", 2);
					} 
					else if (Input.GetKeyUp (KeyCode.RightArrow)) {
						//	PlayerAnimator.SetInteger ("Index", 0);
						RightTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);      
					}
					// Condition if player kills all 5 insects 
					// To Change note , Score point remains at 5 , at every 5 insects a character changes 
					
				} else {
					if (TotalScorePoint >= 5 && !stopmoving) {
						
						// Player  1,2,3 are being rendered , men counter will decrease by 1 
						// in totala, men counter is 12 .
						stopmoving = false;
						GameObject.Find("Background").GetComponent<RandomGenerator>().over = true;
						GameObject.Find ("Bug_1").GetComponent<SpriteRenderer> ().enabled = false;
						GameObject.Find ("Bug_2").GetComponent<SpriteRenderer> ().enabled = false;
						GameObject.Find ("Bug_3").GetComponent<SpriteRenderer> ().enabled = false;				
						GameObject.Find ("Bug_4").GetComponent<SpriteRenderer> ().enabled = false;
						RightTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);   
						UpTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);     
						LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f); 
					}
				}
			}

			if(Application.platform == RuntimePlatform.Android)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
				RaycastHit hit;

				if (TotalScorePoint < 5) 
                {

					LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);
                    RightTargetBox.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
                    UpTargetBox.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
					
					if (Physics.Raycast(ray, out hit)) 
					{
						if (Input.touchCount > 0 && Input.touchCount <= 1) 
						{
							if (hit.collider.name == "TargetBox_Left")
							{
								// Animator to indicate the picture that character is turning left 
								SFXPunchLeft.Play();
								GameObject.Find("Player").GetComponent<Animator>().SetInteger("Index", 3);
								LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.0f, 0.0f); 
								if (CheckCollisionWithBug (LeftTargetBox) == true) {
									//ScorePoint += 1;
									
									if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
										
										GUIScore.text = "Insect Squashed:" + TotalScorePoint;
									} 
									
									else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
										
										GUIScore.text = "Insect Geplet:" + TotalScorePoint;
									}        
								}
							}
                            else if (hit.collider.name == "TargetBox_Up")
                            {
                                SFXPunchLeft.Play();
                                GameObject.Find("Player2").GetComponent<Animator>().SetInteger("Index", 1);
                                UpTargetBox.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
                                if (CheckCollisionWithBug(UpTargetBox) == true)
                                {
                                    //ScorePoint += 1;
                                    if (GameObject.Find("SaveData").GetComponent<SaveData>().Language == 1)
                                    {
                                        GUIScore.text = "Insect Squashed:" + TotalScorePoint;
                                    }

                                    else if (GameObject.Find("SaveData").GetComponent<SaveData>().Language == 2)
                                    {
                                        GUIScore.text = "Insect Geplet:" + TotalScorePoint;
                                    }
                                }
                            }
							else if (hit.collider.name == "TargetBox_Right")
							{
								SFXPunchLeft.Play();
								GameObject.Find("Player3").GetComponent<Animator>().SetInteger("Index", 2);
								
								RightTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.0f, 0.0f);    
								if (CheckCollisionWithBug (RightTargetBox) == true) {
									//ScorePoint += 1;
									if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
										
										GUIScore.text = "Insect Squashed:" + TotalScorePoint;
									} 
									
									else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
										
										GUIScore.text = "Insect Geplet:" + TotalScorePoint;
									}
								}
							}
						}
					}
				}
					// Condition if player kills all 5 insects 
					// To Change note , Score point remains at 5 , at every 5 insects a character changes 
				else if (TotalScorePoint >= 5 && !stopmoving)
				{
					// Player  1,2,3 are being rendered , men counter will decrease by 1 
					// in totala, men counter is 12 .
					stopmoving = false;
					GameObject.Find("Background").GetComponent<RandomGenerator>().over = true;
					GameObject.Find ("Bug_1").GetComponent<SpriteRenderer> ().enabled = false;
					GameObject.Find ("Bug_2").GetComponent<SpriteRenderer> ().enabled = false;
					GameObject.Find ("Bug_3").GetComponent<SpriteRenderer> ().enabled = false;				
					GameObject.Find ("Bug_4").GetComponent<SpriteRenderer> ().enabled = false;
					RightTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);   
					UpTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);     
					LeftTargetBox.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f); 
				}
			}
		}
	}
	
	
	
	
	bool CheckCollisionWithBug (SpriteRenderer tempSpriteRenderer)
	{
		bool Collided;
		Collided = false;
		if(checkCollide(tempSpriteRenderer.transform.position, tempSpriteRenderer.sprite.texture.width, tempSpriteRenderer.sprite.texture.height, Bug_1.transform.position, Bug_1.sprite.texture.width/4.0f, Bug_1.sprite.texture.height) == true)
		{
			GameObject.Find("Particle_1").transform.position = new Vector3 (insect_1.transform.position.x, insect_1.transform.position.y, -5.0f);
			GameObject.Find("Particle_1").GetComponent<ParticleSystem>().Emit(GameObject.Find("Particle_1").GetComponent<ParticleSystem>().maxParticles);
			insect_1.RespawnBug();
			Collided = true;
			ScorePoint += 1;
		}
		if(checkCollide(tempSpriteRenderer.transform.position, tempSpriteRenderer.sprite.texture.width, tempSpriteRenderer.sprite.texture.height, Bug_2.transform.position, Bug_2.sprite.texture.width/4.0f, Bug_2.sprite.texture.height) == true)
		{
			GameObject.Find("Particle_2").transform.position = new Vector3 (insect_2.transform.position.x, insect_2.transform.position.y, -1.0f);
			GameObject.Find("Particle_2").GetComponent<ParticleSystem>().Emit(GameObject.Find("Particle_1").GetComponent<ParticleSystem>().maxParticles);
			insect_2.RespawnBug();
			Collided = true;
			ScorePoint += 1;
		}
		if(checkCollide(tempSpriteRenderer.transform.position, tempSpriteRenderer.sprite.texture.width, tempSpriteRenderer.sprite.texture.height, Bug_3.transform.position, Bug_3.sprite.texture.width/4.0f, Bug_3.sprite.texture.height) == true)
		{
			GameObject.Find("Particle_3").transform.position = new Vector3 (insect_3.transform.position.x, insect_3.transform.position.y, -1.0f);
			GameObject.Find("Particle_3").GetComponent<ParticleSystem>().Emit(GameObject.Find("Particle_1").GetComponent<ParticleSystem>().maxParticles);
			insect_3.RespawnBug();
			Collided = true;
			ScorePoint += 1;
		}
		if(checkCollide(tempSpriteRenderer.transform.position, tempSpriteRenderer.sprite.texture.width, tempSpriteRenderer.sprite.texture.height, Bug_4.transform.position, Bug_4.sprite.texture.width/4.0f, Bug_4.sprite.texture.height) == true)
		{
			GameObject.Find("Particle_4").transform.position = new Vector3 (insect_4.transform.position.x, insect_4.transform.position.y, -1.0f);
			GameObject.Find("Particle_4").GetComponent<ParticleSystem>().Emit(GameObject.Find("Particle_1").GetComponent<ParticleSystem>().maxParticles);
			insect_4.RespawnBug();
			Collided = true;
			ScorePoint += 1;
		}

		TotalScorePoint =
		GameObject.Find("Player").GetComponent<Player>().ScorePoint +
		GameObject.Find("Player2").GetComponent<Player>().ScorePoint +
		GameObject.Find("Player3").GetComponent<Player>().ScorePoint;
		
		if(Collided == true)
		{
			if (TotalScorePoint >= 5)
			{
				TotalMenCounter--;
				if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 1) {
					GUIMen.text = "Number Of Men Left:" + TotalMenCounter;
				} 
				
				else if (GameObject.Find ("SaveData").GetComponent<SaveData> ().Language == 2) {
					GUIMen.text = "Aantal mannen over:" + TotalMenCounter;
					
				}
			}
			return true;
		}
		else
		{
			return false;
		}
	} 
	bool checkCollide(Vector3 Position_1, float Width_1, float Height_1, Vector3 Position_2, float Width_2, float Height_2) 
	{ 
		float x1Min, x1Max, y1Min,y1Max; 
		float x2Min, x2Max, y2Min,y2Max;
		x1Min = Position_1.x; x1Max = Position_1.x+Width_1;
		y1Min = Position_1.y-Height_1; y1Max = Position_1.y; 
		x2Min = Position_2.x; x2Max = Position_2.x+Width_2; 
		y2Min = Position_2.y-Height_2; y2Max = Position_2.y; 
		// Collision tests 
		if( x1Max < x2Min || x1Min > x2Max )
			return false; 
		if( y1Max < y2Min || y1Min > y2Max )
			return false; 
		return true; 
	}
	
}
