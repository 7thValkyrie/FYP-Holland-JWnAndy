using UnityEngine;
using System.Collections;

public class LevelProgress2 : MonoBehaviour 
{
	//Standard variable
	public bool GetLevelProgression;
	public bool GetInventoryBag;
	

	//Level 2 --------------------------------------------------------------------------------------------------------------------------------------
	// Action done
	public bool killedDeer;
	public bool passDeerToChef;
	public bool talkedToOdysseus;
	public bool filledHelmWithWater;
	public bool shotBeeHive;
	public bool helmWithSilk;
	public bool talkedToEurylochus;
	public bool sharpenSword;
	public bool feedLion;
	public bool feedWolf;
	public bool talkedToHermes;
	public bool combineMolyWithWine;
	public bool swordOnCirce;

	//Parts completed
	public bool part1Completed;
	public bool part2Completed;
	public bool ArmWrestlingCompleted;

	//Level 2
	//Gotten object
	public bool GetGrass;
	public bool GetRope;
	public bool tiedDeer;
	public bool GetSword;
	public bool GetSpear;
	public bool GetThread;
	public bool GetVeil;
	public bool GetHoneyComb;
	public bool GetHoneyComb2;
	public bool GetWarmTea;
	public bool GetStone;
	public bool GetVenison;
	public bool GetMoly;
	public bool GetWine;

	//Maze progression
	public bool mazeCompleted;


	//For Golden Coin
	public bool GetGoldenCoin1;
	public bool GetGoldenCoin2;
	public bool GetGoldenCoin3;
	public bool GetGoldenCoin4;
	public bool GetGoldenCoin5;
	public bool GetGoldenCoin6;
	
	// Use this for initialization
	void Start () 
	{
		if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetLevelProgression == true)
		{
			Destroy (this.gameObject);
		}
		GetLevelProgression = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
