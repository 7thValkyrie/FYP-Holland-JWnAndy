using UnityEngine;
using System.Collections;

public class ghostspawn : MonoBehaviour {

	public Vector3 ghostMovingDirection;
	public Vector3 ghostSpawnPosition;
	//public GameObject bloodObject;
	//public GameObject GhostUnit;
	public float movespeedMin;
	public float movespeedMax;
	public Vector3 randomValue;
	public float radius = 5f;
	public Vector3 tempplayer;
	public ObjectManager objectM;
	public float randomSpeed;
	public GameObject drawRadius;
	bool fadingAway = false;
	public float temptime = 0f;
	//public GameObject poofafterdie;
	//public SpriteRenderer tempFade;
	public JwGUIMenu PauseCheck;
	// Use this for initialization
	void Start () {
		//print("I'm attached to "+transform.name);
		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			movespeedMax = 10;
			movespeedMin = 5;
			randomSpeed = Random.Range (movespeedMin, movespeedMax);
		}
		if (Application.loadedLevelName == "minigame_runupstair")
		{
			movespeedMax = 11;
			movespeedMin = 10;
			randomSpeed = Random.Range (movespeedMin, movespeedMax);

			//objectM.CalcRingRadius = 100.0f;
		}

		ghostMovingDirection = new Vector3 (0, 0, 0);
//		for (int i = 0; i < ghostLimit; i++) {
//			float angle = i * Mathf.PI * 2 / ghostLimit;
//			Vector3 pos = new Vector3 (Mathf.Cos (angle),  Mathf.Sin (angle),0) * radius;
//			Instantiate (GhostUnit, pos, Quaternion.identity);
//				}
		//GhostUnit = objectM.Ghost.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		//calculate Moving Direction


		//transform.rotation = Vector3.Slerp (objectM.Player.position, ghostMovingDirection, Time.deltaTime * radius);
		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			if(fadingAway == false)
			{
				ghostMovingDirection = objectM.center - transform.position;
				ghostMovingDirection.Normalize();
				ghostMovingDirection.z = 0;
				Vector3 SeekingBloodDir = new Vector3(ghostMovingDirection.x,ghostMovingDirection.y,1) - transform.position;
				float angle = Mathf.Atan2(SeekingBloodDir.y, SeekingBloodDir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2 (SeekingBloodDir.y, SeekingBloodDir.x) * Mathf.Rad2Deg - 90));
				//transform.Translate(ghostMovingDirection.x * randomSpeed * Time.deltaTime, ghostMovingDirection.y *  randomSpeed  * Time.deltaTime, 0);
				transform.position += ghostMovingDirection * randomSpeed * Time.deltaTime;
			}
			if(fadingAway == true)
			{
				//float Fade = Mathf.SmoothDamp(1f,0f,1f,1f);
				//tempFade.color = new Color(1f,1f,1f,0.5f);
				temptime += Time.deltaTime;


			}
			DeactiviteGhost();
		}
		if (Application.loadedLevelName == "minigame_runupstair")
		{
			//Vector3 templayer;
			tempplayer = GameObject.FindGameObjectWithTag ("RunningOdyseusMiniGame").transform.position;
			objectM.CalcRingRadius = (tempplayer - transform.position).sqrMagnitude;
			//drawRadius.SetActive(true);
			if (objectM.CalcRingRadius > 50){
				//drawRadius.SetActive(false);
				ghostMovingDirection = tempplayer - transform.position;
				ghostMovingDirection.Normalize();
				ghostMovingDirection.z = 0;
				renderer.material.color = new Color(255, 255, 255, 0.1f);
				//transform.Translate(ghostMovingDirection.x * randomSpeed * Time.deltaTime,ghostMovingDirection.y *  randomSpeed  * Time.deltaTime, 0);
//				print("in radius");
			}

			if(transform.localScale.magnitude < 5)
			{
				transform.localScale += new Vector3(1f * Time.deltaTime ,1f * Time.deltaTime,0);
				//renderer.material.color = new Color(Mathf.Lerp(0, 255.0f, 1*Time.deltaTime), 0, 0, Mathf.Lerp(renderer.material.color.a, 1.0f, 10*Time.deltaTime));
			}
			if (objectM.CalcRingRadius < 50)
			{
				//transform.localScale += new Vector3(0.01f,0.01f,0);
				renderer.material.color = new Color(255, 255, 255, Mathf.Lerp(renderer.material.color.a, 1.0f, 10*Time.deltaTime));
			}
			//temp.Normalize();
			transform.position += ghostMovingDirection * randomSpeed * Time.deltaTime * 0.1f;

		}

	}
	void DeactiviteGhost()
	{
		if(temptime > 1.5f)
		{
			ObjectManager.Instance.numberofGhost -= 1;
			this.gameObject.SetActive(false);
			fadingAway = false;
			temptime = 0;
		}


	}
	void OnCollisionEnter2D(Collision2D col){
		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			
			if (col.gameObject.tag != "BloodMiddle" ) {
				//this.GetComponent<GUITexture>().texture = hi;
				//Debug.Log (col);
				Vector2 HitbackForce = col.gameObject.transform.position - gameObject.transform.position;
				gameObject.rigidbody2D.velocity = new Vector2(HitbackForce.x * 10,HitbackForce.y * 10);

				fadingAway = true;
				
			}
		}

	}
	void OnCollisionStay2D(Collision2D colExit)
	{
		if(colExit.gameObject.tag != "BloodMiddle" )
		temptime += Time.deltaTime;


	}
	void OnMouseEnter()
	{


	}

}
