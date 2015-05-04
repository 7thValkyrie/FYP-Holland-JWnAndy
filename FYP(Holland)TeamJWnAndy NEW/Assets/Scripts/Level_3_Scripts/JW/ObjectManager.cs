using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
	private static ObjectManager object_instance = null;
	public static ObjectManager Instance
	{
		get
		{
			if (object_instance == null)
				object_instance = (ObjectManager)FindObjectOfType (typeof(ObjectManager));
			return object_instance;
		}
		
		
	}
	//objects
	public Transform Ghost;
	public Transform Blood;
	public Transform fending_Player;
	public Transform running_Player;
	public Transform walkonFiya_Player;
	public Transform FlyingGhost;
	public GameObject radiusRing;
	//random spawn in rect
	public Transform TempRectSpawn;


	public float CalcRingRadius;
	//setting value and pos
	public int ghostLimit;
	public int numberofGhost;
	public Vector3 center;
	public Vector3 pos;
	public Vector3 towardPlayer;
	public bool spawning;
	//object list to store object in a temporary list
	public Transform[] ghost_list;
	public Transform[] FlyingGhost_list;
	// Use this for initialization
	void Start () {
		spawning = true;
		ghostLimit = 3;
		numberofGhost = 0;
		ghost_list = new Transform[ghostLimit];
		FlyingGhost_list = new Transform[ghostLimit];
		//print("I'm attached to "+transform.name);
		pos = new Vector3 (0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			SpawnCircleGhost ();
		}
	
		if (Application.loadedLevelName == "minigame_runupstair")
		{
			SpawnFlyingGhost();
		}
	}
	void SpawnCircleGhost(){
		//instantiate ghost
		//First mini game ghost spawning
		if(numberofGhost < ghostLimit)
		{
			for (int i = 0; i < ghostLimit; i++) 
			{
				//this.Ghost.gameObject.SetActive(true);
				center = Blood.transform.position;
				pos = RandomCircle (center, 20.0f);
				//Quaternion rot = Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2 (SeekingBloodDir.y, SeekingBloodDir.x) * Mathf.Rad2Deg - 90));
				//Quaternion rot = Quaternion.RotateTowards(Ghost.transform.rotation, Blood.transform.rotation, 360);
				//ghostSpawnPosition = new Vector3 (randomValue.x, randomValue.y, 0);
				if(spawning == true){
					Transform go = Instantiate (ObjectManager.Instance.Ghost, pos, Quaternion.identity) as Transform;
					Debug.DrawLine (fending_Player.transform.position,Ghost.transform.position);

					numberofGhost++;
					//go.transform.rotation = Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2 (SeekingBloodDir.y, SeekingBloodDir.x) * Mathf.Rad2Deg - 90));
					ghost_list[i] = go;
				}
			}
		}
		if(numberofGhost >= (ghostLimit-1) )
		{
			spawning = false;
		}
		if (spawning == false && numberofGhost < 4) {
			//GameObject obj = GameObject.FindWithTag("ghost");
			foreach(Transform obj in ghost_list)
			{
			if (obj.gameObject.activeSelf == false) {
				obj.gameObject.SetActive(true);
				center = Blood.transform.position;
				//Vector3 SeekingBloodDir = new Vector3(center.x,center.y,1) - transform.position;
				//Quaternion rot = Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2 (SeekingBloodDir.y, SeekingBloodDir.x) * Mathf.Rad2Deg - 90));

				pos = RandomCircle (center, 20.0f);
				obj.position = pos;
				numberofGhost++;
				// obj.rotation =  Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2 (SeekingBloodDir.y, SeekingBloodDir.x) * Mathf.Rad2Deg - 90));
			}
			}
		}
		//end of minigame 1 ghost spawning 
		// start of minigame 2 stair running
	}
	//2nd mini game
	void SpawnFlyingGhost(){
		//Quaternion rot = Quaternion.RotateTowards(FlyingGhost.rotation, running_Player.rotation, 360);
		Vector3 EFacingDir = new Vector3(running_Player.position.x,running_Player.position.y,1) - transform.position;
		//float angle = Mathf.Atan2(EFacingDir.y, EFacingDir.x) * Mathf.Rad2Deg;
		float angle = Mathf.Atan2(EFacingDir.y, EFacingDir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0,Mathf.Atan2 (EFacingDir.y, EFacingDir.x) * Mathf.Rad2Deg - 90));
		if(numberofGhost < ghostLimit)
		{
			for (int i = 0; i < ghostLimit; i++) 
			{
				if(spawning == true){
					pos = RandomRect (TempRectSpawn.position, 2, 2, 1);
					Transform go = Instantiate (ObjectManager.Instance.FlyingGhost, pos, Quaternion.identity) as Transform;
					numberofGhost++;
					FlyingGhost_list[i] = go;

				}
			}
		}
		if(numberofGhost >= (ghostLimit-1) )
		{
			spawning = false;
		}
		if (spawning == false && numberofGhost < 4) {
			//GameObject obj = GameObject.FindWithTag("ghost");
			foreach(Transform obj in FlyingGhost_list)
			{
				pos = RandomRect (TempRectSpawn.position, 2, 2, 1);
				if (obj.gameObject.activeSelf == false) {
					obj.gameObject.SetActive(true);
					obj.position = pos;
					numberofGhost++;
				}
			}
		}
		//Instantiate (FlyingGhost, FlyingGhost.position, Quaternion.identity);   
	}
	Vector3 RandomRect (Vector3 boxPos, float boxWidth, float boxHeight, float boxDepth){
		Vector3 randPos = new Vector3(Random.Range(-boxWidth, boxWidth), Random.Range(-boxHeight, boxHeight), 0);
		Vector3 tempos = new Vector3 (boxPos.x - randPos.x, boxPos.y - randPos.y, 0);
		return tempos;
	}
	Vector3 RandomCircle ( Vector3 centered ,   float radius  ){
		float ang = Random.value * 360;
		Vector3 posC;
		posC.x = centered.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		posC.y = centered.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		posC.z = centered.z;
		return posC;
	}
}
