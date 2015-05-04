using UnityEngine;
using System.Collections;

public class ArmWrestle : MonoBehaviour {
	
	protected Animator animator;

	public float counter;

	private float Timer = 0.0f;

	public bool reached;

	public GameObject targetbar;
	public GameObject slider;
	

	// Use this for initialization
	void Start () {
		counter = 0;
		animator = GetComponent<Animator>();
		GameObject.Find ("Slider").GetComponent<MovingBar> ().smoothTime = 1.0f;
		GameObject.Find ("Slider").GetComponent<MovingBar> ().ismoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.Timer += Time.deltaTime;
		print (counter);
		//Debug.Log (this.Timer);
		if (this.Timer >= 0.15f && reached == false) 
		{
			counter -=5;
			this.transform.position = new Vector3 ( this.transform.position.x - 5 ,this.transform.position.y, this.transform.position.z);
			this.Timer = 0;
		}

		InputUpdate ();
		if (this.reached == false) 
		{
			checkReached (); 
		}
		if (counter <= -100) 
		{
			GameObject.Find("Ody").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("1",typeof (Sprite));
			GameObject.Find("Euro").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Euro_3",typeof (Sprite));
		}
		if (counter <= 100 && counter >= -99) 
		{
			GameObject.Find("Ody").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("2",typeof (Sprite));
			GameObject.Find("Euro").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Euro_2",typeof (Sprite));
		}
		if (counter >= 100) 
		{
			GameObject.Find("Ody").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("3",typeof (Sprite));
			GameObject.Find("Euro").GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Euro_1",typeof (Sprite));
		}
		if (counter == 200)
		{
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().ArmWrestlingCompleted = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
		}

		//if (reached == true)
		//{
		//	Debug.Log ("HELLO");
		//}
	}
	
	void InputUpdate () 
	{
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (reached == false) 
				{
					ApplyStr();
				}

				else
				{
					if (this.Timer <= 1.0f) {
						return;
					}
					Finisher();
				}
			}
			if(Input.GetKeyDown (KeyCode.B) && reached == true) 
			{

			}
			if (Input.GetKey (KeyCode.Escape)) 
			{
				GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().ArmWrestlingCompleted = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
				GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
			}
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			if ((Input.touchCount > 0 && Input.touchCount <= 1))
			{
				if (reached == false) 
				{
					ApplyStr();
				}
				
				else 
				{
					if (this.Timer <= 1.0f) {
						return;
					}
					Finisher();
				}
			}
		}
	}

	void Finisher()
	{
		if(FinishingMove()) 
		{
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().ArmWrestlingCompleted = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
		}
		
		else 
		{
			GameObject.Find ("Finish").GetComponent<GUIText> ().enabled = false;
			reached = false;
			counter = 100;
			this.transform.position = new Vector3 ( this.transform.position.x - 100 ,this.transform.position.y, this.transform.position.z);
			GameObject.Find ("Slider").GetComponent<MovingBar> ().ismoving = false;
		}
	}

	void ApplyStr()
	{
		counter+=10;
		this.transform.position = new Vector3 ( this.transform.position.x + 10 ,this.transform.position.y, this.transform.position.z);
	}

	void checkReached()
	{
		if(counter == 200)
		{
			print ("IMREACHED");
		this.Timer = 0.0f;
		reached = true; 
		GameObject.Find ("Slider").GetComponent<MovingBar> ().ismoving = true;
		GameObject.Find ("Finish").GetComponent<GUIText> ().enabled = true;
			GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().ArmWrestlingCompleted = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
			GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
		}
		if (reached == true) 
		{
			Debug.Log("AAA");
		}
	}

	bool FinishingMove()
	{
		if (checkCollide (targetbar.transform.position, targetbar.GetComponent<SpriteRenderer> ().sprite.texture.width, targetbar.GetComponent<SpriteRenderer> ().sprite.texture.height,
		                  slider.transform.position, slider.GetComponent<SpriteRenderer> ().sprite.texture.width, slider.GetComponent<SpriteRenderer> ().sprite.texture.height))
		{
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
		
		// the division is for the pixels to units scaling
		x1Min = Position_1.x;
		x1Max = Position_1.x+Width_1/2;
		y1Min = Position_1.y-Height_1/2;
		y1Max = Position_1.y;
		
		x2Min = Position_2.x;
		x2Max = Position_2.x+Width_2/2;
		y2Min = Position_2.y-Height_2/2;
		y2Max = Position_2.y;
		
		// Collision tests
		if( x1Max < x2Min || x1Min > x2Max ) return false;
		if( y1Max < y2Min || y1Min > y2Max ) return false;
		
		return true;
	}
}
