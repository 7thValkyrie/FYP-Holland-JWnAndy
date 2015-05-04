using UnityEngine;
using System.Collections;

public class JW_minigame_playercontroller : MonoBehaviour {
	public ObjectManager objectM;
	public Vector3 axis = Vector3.up;
	public Vector3 desiredPos;
	public float radius = 3.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed;
	public Vector3 moveDir;
	public Vector3 PMPosition;
	public Vector3 travelDir;
	public	Vector3 LastMPosition;
	public float MoveSpeed;
	public Texture antiClockWise;
	public Texture ClockWise;
    public bool abletomove = false;
	private float rotationInputButton = 0;
	public bool PlayMove = false;
    Animator animat;
    public GameObject fendLeg;

	public GameObject spawnPosforFiyaa;
	// Use this for initialization
	void Start () {
		
        if (Application.loadedLevelName == "minigame_fendoffghost")
        {
            objectM.fending_Player.position = (objectM.fending_Player.position - objectM.Blood.position).normalized * radius + objectM.Blood.position;
            animat = fendLeg.GetComponent<Animator>();
        }
		if (Application.loadedLevelName == "minigame_runupstair")
		{
			objectM.running_Player.position = objectM.running_Player.position;
			//Instantiate (ObjectManager.Instance.radiusRing, objectM.running_Player.position, Quaternion.identity);
//			objectM.radiusRing.transform.localScale = new Vector3(objectM.CalcRingRadius,objectM.CalcRingRadius, 0 );
		}
		if (Application.loadedLevelName == "minigame_walkonFiyaa")
		{
			MoveSpeed = 1.0f;
			objectM.walkonFiya_Player.position =  spawnPosforFiyaa.transform.position;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			ClockMove(rotationInputButton);

		}
		if (Application.loadedLevelName == "minigame_walkonFiyaa")
		{
//			//doing smth
//			if (Input.GetKey (KeyCode.LeftArrow)) 
//				objectM.walkonFiya_Player.position += Vector3.left * Time.deltaTime;
//			if (Input.GetKey (KeyCode.RightArrow)) 
//				objectM.walkonFiya_Player.position += Vector3.right * Time.deltaTime;
//			if (Input.GetKey (KeyCode.UpArrow)) 
//				objectM.walkonFiya_Player.position += Vector3.up * Time.deltaTime;
//			if (Input.GetKey (KeyCode.DownArrow)) 
//				objectM.walkonFiya_Player.position += Vector3.down * Time.deltaTime;
           
			pointClickMovement();
			//MoveSpeed += 0.05f;

		}

	}
	public void ClockMove(float Dir){
		rotationSpeed = 0.0f;
		rotationInputButton = Dir;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveDir = Vector3.forward * 90;
			rotationSpeed = 200.0f;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveDir = Vector3.back * 90;
			rotationSpeed = 200.0f;
		}
		if (Dir == 1) {
			moveDir = Vector3.forward ;
			rotationSpeed = 200.0f;
            animat.SetBool("LegAnimation", true);
		}
		if (Dir == -1) {
			moveDir = Vector3.back;
			rotationSpeed = 200.0f;
            animat.SetBool("LegAnimation", true);
		}
        if(Dir == 0)
            animat.SetBool("LegAnimation", false);
		objectM.fending_Player.RotateAround (objectM.Blood.position, moveDir , rotationSpeed * Time.deltaTime);		
		desiredPos = (objectM.fending_Player.position - objectM.Blood.position).normalized * radius + objectM.Blood.position;
		objectM.fending_Player.position = Vector3.Slerp (objectM.fending_Player.position, desiredPos, Time.deltaTime * radiusSpeed);
		
	}
	void pointClickMovement()
	{
		#if UNITY_ANDROID
		//Vector3 touchDir;
		foreach(Touch touch in Input.touches)
		{

			PMPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));// -  objectM.walkonFiya_Player.position;
            abletomove = true;
		}

		#endif
		#if UNITY_STANDALONE || UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{
			//Change Mouse Position on GUI to World Coordinates
			PMPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			travelDir = PMPosition - objectM.walkonFiya_Player.position;
			LastMPosition = travelDir;
			LastMPosition.z = 0;
            abletomove = true;
		}
		#endif
//		if(Input.GetMouseButtonUp(0))
//			objectM.walkonFiya_Player.position = Vector2.Lerp( objectM.walkonFiya_Player.position,LastMPosition, Time.deltaTime * MoveSpeed);
//		if ((LastMPosition - objectM.walkonFiya_Player.position).sqrMagnitude < (100f * MoveSpeed))
//			objectM.walkonFiya_Player.rigidbody2D.velocity = Vector2.zero;
//		    objectM.walkonFiya_Player.position += LastMPosition * MoveSpeed * Time.deltaTime;
        if(abletomove == true)
        objectM.walkonFiya_Player.position = Vector2.MoveTowards(objectM.walkonFiya_Player.position, PMPosition, Time.deltaTime * MoveSpeed);

	}
	void FixedUpdate()
	{
		if (Application.loadedLevelName == "minigame_walkonFiyaa")
		{
			rigidbody2D.MovePosition (objectM.walkonFiya_Player.position);

		}
	}


	
}