using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class JW_WinBar : MonoBehaviour {
	public float requiredBlood;
	public float currentBlood;
	public float currentDistance;
	public float endDistance;
	public float GainOverTime;

	public GameObject getRekt;
	public GameObject bloodsplattering;
	public Image FakeExitLight;
	float alphaExitValue;
	// Use this for initialization
	void Start () {
		requiredBlood = 100;
		endDistance = 100;
		alphaExitValue = 0;
	}
    void Awake()
    {
       if (Global.Minigame_Win)
           Application.LoadLevel("SacrificialArea");
    }

	// Update is called once per frame
	void Update () {
		GainOverTime = Time.deltaTime * 1.5f;

		//bloodsplattering.Stop ();

		if (Application.loadedLevelName == "minigame_fendoffghost")
		{
			currentBlood += GainOverTime;
			if(currentBlood >= requiredBlood){
				Debug.Log ("you win");
                Global.Minigame_Win = true;
			}
			if(currentBlood < 0)
			{
				currentBlood = 0;
			}

            if (Global.Minigame_Win)
                Application.LoadLevel("SacrificialArea");
		}
		if (Application.loadedLevelName == "minigame_runupstair")
		{
			FakeExitLight.color = new Color(1,1,1,alphaExitValue);
			currentDistance += GainOverTime;
			if(currentDistance > 50)
			alphaExitValue += GainOverTime / 100f;

			
			if(currentDistance >= endDistance){
				Debug.Log ("you win");
				Application.LoadLevel("Chapter3CutSceneEnd");
			}
			if(currentDistance < 0)
			{
				currentDistance = 0;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "ghost" ) {
			
			Vector3 BloodFlyDirection = new Vector3(col.transform.position.x,col.transform.position.y,1) - bloodsplattering.transform.position;
			float angle = Mathf.Atan2(BloodFlyDirection.y, BloodFlyDirection.x) * Mathf.Rad2Deg;
			//Quaternion rot =  Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2 (BloodFlyDirection.y, BloodFlyDirection.x) * Mathf.Rad2Deg - 90));
			Quaternion rot = Quaternion.RotateTowards(bloodsplattering.transform.rotation, col.transform.rotation, 360);
			Instantiate(bloodsplattering,col.transform.position,Quaternion.identity);
			//col.rigidbody.AddForce(10000);
			
			currentBlood -= 1f;
		}
		if(col.gameObject.tag == "flyingGhost")
		{
			currentDistance -= 5f;
			getRekt.SetActive(true);
		}

	}
	void OnCollisionStay2D(Collision2D eating)
	{
		if (eating.gameObject.tag == "ghost" ) {
			
			Vector3 BloodFlyDirection = new Vector3(eating.transform.position.x,eating.transform.position.y,1) - bloodsplattering.transform.position;
			float angle = Mathf.Atan2(BloodFlyDirection.y, BloodFlyDirection.x) * Mathf.Rad2Deg;
			//Quaternion rot =  Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2 (BloodFlyDirection.y, BloodFlyDirection.x) * Mathf.Rad2Deg - 90));
			Quaternion rot = Quaternion.RotateTowards(bloodsplattering.transform.rotation, eating.transform.rotation, 360);
			Instantiate(bloodsplattering,eating.transform.position / 2,Quaternion.identity);
			//col.rigidbody.AddForce(10000);
			
			currentBlood -= 0.1f;
		}
		if(eating.gameObject.tag == "flyingGhost")
		{
			currentDistance -= 0.1f;
			getRekt.SetActive(true);

		}


	}
	void OnTriggerEnter2D (Collider2D hit)
	{
		if(hit.gameObject.tag == "flyingGhost")
		{
			currentDistance -= 10;
		}
		
	}
}
