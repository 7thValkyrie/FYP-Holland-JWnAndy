using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	
	protected Animator animator;
	protected Animator branchanimator;
	public GameObject targetbar;
	public GameObject slider;
	public AudioSource SFXCut;

	public bool cutonce;
	private float cuttime = 0.0f;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		branchanimator = GameObject.Find ("Branch").GetComponent<Animator> ();

		cutonce = false;
	}
	
	// Update is called once per frame
	void Update () {
		InputUpdate ();    

		if (cutonce == true)
		{
			cuttime += Time.deltaTime;
		}

		if (cuttime >= 2.0f)
		{
			cuttime = 0.0f;
			cutonce = false;
		}
	}
	
	void InputUpdate () {
		if (Input.GetKey (KeyCode.Escape)) {
			GameObject.Find("Branch").GetComponent<Animator> ().SetInteger ("branch_state", 7);
				}
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (cutonce == false)
				{
					Cut();
				}
			}
		}
		else if(Application.platform == RuntimePlatform.Android)
		{
			if ((Input.touchCount > 0 && Input.touchCount <= 1)) 
			{
				if (cutonce == false)
				{
					Cut();
				}
			}
		}
	}
	
	void Cut()
	{
		if(!animator.GetBool("b_success") && !animator.GetBool("b_fail"))
		{
			GameObject.Find("Slider").GetComponent<MovingBar>().ismoving = false;
			
			if (AttemptSlice()) 
			{
				SFXCut.Play ();
				animator.SetBool("b_success", true);
				cutonce = true;
				GameObject.Find("Slider").GetComponent<MovingBar>().smoothTime -= 0.08f;
			}
			else
			{
				animator.SetBool("b_fail", true);
			}
		}
		
		
	}
	
	bool AttemptSlice()
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
	
	// this is called by slicesuccess animation trigger
	void CutBranch()
	{
		branchanimator.SetInteger("branch_state", branchanimator.GetInteger("branch_state") + 1);
	}
	// this is called by slicesuccess animation trigger
	void DisplayPow()
	{
		GameObject.Find ("Pow").GetComponent<SpriteRenderer> ().enabled = true;
	}
	// this is called by slicesuccess animation trigger
	void DisablePow()
	{
		GameObject.Find ("Pow").GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// this is called by slicefail animation trigger
	void DisplayAww()
	{
		GameObject.Find ("Aww").GetComponent<SpriteRenderer> ().enabled = true;
	}
	// this is called by slicefail animation trigger
	void DisableAww()
	{
		GameObject.Find ("Aww").GetComponent<SpriteRenderer> ().enabled = false;
	}
	// this is called by both animations trigger
	void StartMovingBar()
	{
		GameObject.Find("Slider").GetComponent<MovingBar>().ismoving = true;
		animator.SetBool("b_success", false);
		animator.SetBool("b_fail", false);
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
