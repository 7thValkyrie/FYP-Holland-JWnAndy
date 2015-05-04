using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {
	private float SPEED = 60.0f;
	private int counter;
	private Vector2 Velocity;
	private bool Stop = false;
	private bool Expand;
	private bool PlaySound;
	private bool Check1,Check2,Check3;
	private float timer;
	private Vector3 original_Scale;

	public Sprite RedTarget;
	public Sprite GreenTarget;
	public AudioSource SFXBeep1, SFXBeep2, SFXBeep3;

	public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
		counter = 1000;
		Velocity = new Vector2 (0.0f, 0.0f);
		original_Scale = GameObject.Find ("Target").transform.localScale;
		Expand = true;
		PlaySound = false;
		Check1 = false;
		Check2 = false;
		Check3 = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Continue").GetComponent<TutorialTextScript1>().Ready == true ) {
			// Boundary
			transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax));

			if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
			{
				GameObject.Find ("InGameInstructions").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.Find ("InGameInstructionsAndroid").GetComponent<SpriteRenderer>().enabled = false;
			}
			else if(Application.platform == RuntimePlatform.Android)
			{
				GameObject.Find ("InGameInstructions").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find ("InGameInstructionsAndroid").GetComponent<SpriteRenderer>().enabled = true;
			}

			if (!Stop) {
				if (counter > 100) {
					Velocity = new Vector2 (Random.Range (-100.0f, 100.0f) * 0.01f * SPEED * Time.deltaTime, Random.Range (-100.0f, 100.0f) * 0.01f * SPEED * Time.deltaTime);
						counter = 0;
				}

				/*if (Input.GetKey(KeyCode.Escape))
				{
					Stop = true;
				}*/

				counter ++;
				if ((this.transform.position.x + Velocity.x < 1280 && this.transform.position.x + Velocity.x > 0) &&
					(this.transform.position.y + Velocity.y < 720 && this.transform.position.y + Velocity.y > 0))
					this.transform.position += new Vector3 (Velocity.x, Velocity.y, 0);
				else {
					Velocity = new Vector2 (-Velocity.x, -Velocity.y);
					this.transform.position += new Vector3 (Velocity.x, Velocity.y, 0);
				}
				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
				{
					if (Input.GetKeyUp ("up")) { 
						if (this.transform.position.y + 1 > 0)
							Velocity += new Vector2 (0, 35* Time.deltaTime);
					}
					if (Input.GetKeyUp ("down")) {
						if (this.transform.position.y - 1 < 1280)
							Velocity -= new Vector2 (0, 35* Time.deltaTime);
					}
					if (Input.GetKeyUp ("left")) {
						if (this.transform.position.x - 1 > 0)
							Velocity -= new Vector2 (35* Time.deltaTime, 0);
					}
					if (Input.GetKeyUp ("right")) {
						if (this.transform.position.x + 1 < 720)
							Velocity += new Vector2 (35* Time.deltaTime, 0);
					}
				}
				else if (Application.platform == RuntimePlatform.Android)
				{
					transform.Translate(Input.acceleration.x * Time.deltaTime * SPEED * 5, Input.acceleration.y * Time.deltaTime * SPEED * 5, 0);
				}

				if (GameObject.Find("Target").transform.localScale.x >= original_Scale.x + 10 ) {
					Expand = false;
				}

				if (GameObject.Find("Target").transform.localScale.x <= original_Scale.x) {
					Expand = true;
				}
			}
			else {
				GameObject.Find("GUITransition").GetComponent<Transition>().isTransition = true;
				GameObject.Find("GUITransition").GetComponent<Transition>().LoadLevel = "Cave_Night";
				GameObject.Find("LevelProgression").GetComponent<LevelProgress>().ConversationBetweenCyclops = true;
				for (int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++) {
					GameObject.Find("InventoryItem_"+i).GetComponent<SpriteRenderer>().enabled = true;	
				}
			}
			if (this.transform.position.x >= GameObject.Find("Target").transform.position.x - original_Scale.x/2 &&
			    this.transform.position.x <= GameObject.Find("Target").transform.position.x + original_Scale.x/2 &&
			    this.transform.position.y >= GameObject.Find("Target").transform.position.y - original_Scale.y/2  &&
			    this.transform.position.y <= GameObject.Find("Target").transform.position.y + original_Scale.y/2 ) {
				if (timer >= 1 && !Check1) {
					SFXBeep1.Play ();
					Check1 = true;
				}
				if (timer >= 2 && !Check2) {
					SFXBeep2.Play ();
					Check2 = true;
				}
				if (timer > 3) {
					if (timer >= 3 && !Check3) {
						SFXBeep3.Play ();
						Check3 = true;
					}
					//GameObject.Find("Target").GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
					if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
					{
						if (Input.GetKeyUp ("space")) 
						{
							Stop = true;
						}
					}
					else if(Application.platform == RuntimePlatform.Android)
					{
						if ((Input.touchCount > 0 && Input.touchCount <= 1))
						{
							Stop = true;
						}
					}
					GameObject.Find("Target").GetComponent<SpriteRenderer>().sprite = GreenTarget;
				} 
				else {
					GameObject.Find("Target").GetComponent<SpriteRenderer>().sprite = RedTarget;
					GameObject.Find("Target").transform.Rotate(new Vector3(0,0,0.5f));
					
					if (Expand)
						GameObject.Find("Target").transform.localScale += new Vector3(0.5f* Time.deltaTime,0.5f* Time.deltaTime,0);
					else
						GameObject.Find("Target").transform.localScale -= new  Vector3(0.5f* Time.deltaTime,0.5f* Time.deltaTime,0);
				}
				timer += Time.deltaTime;
				if (PlaySound) {
					GameObject.Find("AudioLibrary").GetComponent <AudioSource> ().audio.clip = GameObject.Find("AudioLibrary").GetComponent<AudioManagement> ().Storage [GameObject.Find("AudioLibrary").GetComponent<AudioManagement> ().audio_ID];
					GameObject.Find("AudioLibrary").GetComponent<AudioSource>().audio.Play();
					PlaySound = false;
				}

			}

			else {
				Check1 = false;
				Check2 = false;
				Check3 = false;
				GameObject.Find("AudioLibrary").GetComponent<AudioManagement>().audio_ID = 9;
				GameObject.Find("Target").GetComponent<SpriteRenderer>().sprite= RedTarget;
				timer = 0;
				GameObject.Find("Target").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				GameObject.Find("Target").transform.Rotate(new Vector3(0,0,0.5f));
				
				if (Expand)
					GameObject.Find("Target").transform.localScale += new Vector3(0.5f,0.5f,0);
				else
					GameObject.Find("Target").transform.localScale -= new  Vector3(0.5f,0.5f,0);

			}

		}
		//}
	}
}
