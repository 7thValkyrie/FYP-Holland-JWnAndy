using UnityEngine;
using System.Collections;

public class jw_lavaChange : MonoBehaviour {
	public JW_LevelDesign_bitImg tileChange;
	public GameObject lavaChange;
	public GameObject groundWarning;
	public int burstfrog;
	public float burstTime;
	public float burstLife;
	public float burstWarning;
	// Use this for initialization
	void Start ()
	{
		//this.renderer.material.mainTexture = groundChange;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if(Input.GetKeyDown(KeyCode.A))

		burstWarning += Time.deltaTime;

		if(burstWarning > 2)
		{
			burstfrog = Random.Range(1,10);
			if(burstfrog == 5)
			{
				groundWarning.SetActive(true);

			}
			burstWarning = 0;
			burstLife = 1;
			//burstWarning = 0;
		}

		if(groundWarning.activeSelf == true )
		{
			burstTime += Time.deltaTime;
			if(burstTime > 4)
			{
				lavaChange.SetActive(true);

				burstTime = 0;
			}
			
		}	


		
		if(lavaChange.activeSelf == true)
		{

			burstLife -= Time.deltaTime;
			if(burstLife < 0)
			{
				groundWarning.SetActive(false);
				lavaChange.SetActive(false);
			}
		}

	}

}
