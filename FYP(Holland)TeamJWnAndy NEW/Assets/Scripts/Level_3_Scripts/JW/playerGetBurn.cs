using UnityEngine;
using System.Collections;

public class playerGetBurn : MonoBehaviour {
	public bool burning;
	public float cooldownTimer;
	public ParticleSystem onFiyaa;
	public JW_minigame_playercontroller PlayerM;
	public int resetPos;
	// Use this for initialization
	void Start () {
		burning = false;
		cooldownTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(cooldownTimer > 0)
		{
			onFiyaa.Play();
			cooldownTimer -= Time.deltaTime;
			if(PlayerM.MoveSpeed > 0.5f)
				PlayerM.MoveSpeed -= 0.05f;

		}
		else if(cooldownTimer < 0)
		{
			cooldownTimer = 0;
			burning = false;
			PlayerM.MoveSpeed = 1f;
			onFiyaa.Stop();

		}
		if(burning == true && onFiyaa.isStopped)
		{

			cooldownTimer = 10;
		}
		if(resetPos > 3)
		{
			PlayerM.objectM.walkonFiya_Player.position = PlayerM.spawnPosforFiyaa.transform.position;
			resetPos = 0;
			PlayerM.abletomove = false;
		}
	}
}
