using UnityEngine;
using System.Collections;

public class LevelProgress3 : MonoBehaviour {

	//Standard variable
	public bool GetLevelProgression;
	public bool GetInventoryBag;

	//Level 3 --------------------------------------------------------------------------------------------------------------------------------------
	// Action done
	public bool combinewaterandunheatedanimalglue;
	public bool combinestickandheatedanimalglue;
	public bool combinespadeandstickwithheatedanimalglue;
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
	public bool reachedhell;
	public bool dughole;
	
	//Parts completed
	public bool part1Completed;
	public bool part2Completed;
	public bool sirencompleted;

	//trick them all
	public bool trickfirstman;
	public bool tricksecondman;
	public bool trickthirdman;
	public bool trickfourthman;
	public bool trickfifthman;
	public bool tricksixthman;

	//islandofthesun
	public bool talkfirstman;
	public bool talksecondman;
	
	//Level 3
	//Gotten object
	public bool Getanimalgluecrystal;
	public bool Getbowl;
	public bool Getbowlwithwater;
	public bool GetSword;
	public bool GetSpear;
	public bool Getspade;
	public bool Getstick;
	public bool GetUnheatedanimalglue;
	public bool GetHeatedanimalglue;
	public bool GetStickwithheatedanimalglue;
	public bool GetShovel;
	
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
		if(GameObject.Find("LevelProgression3").GetComponent<LevelProgress3>().GetLevelProgression == true)
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
