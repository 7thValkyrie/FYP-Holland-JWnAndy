using UnityEngine;
using System.Collections;

//Description
enum MessageType1
{
	Flint = 0,
	emptybag = 16,
	slightfilledbag = 32,
	partiallyfilledbag = 40,
	almostfullbag = 48,
	fullbag = 56,
	winebottles = 88,
	wardrobekey = 64,
	sword = 8,
	osierband = 168,
	treebranch = 184,
	stake = 191,
	charredstake = 199,
	stackofcheese = 136,
	bush = 255,
	vines = 271,
	stone = 77
}

enum MessageType2
{
	sword = 1,
	spear = 3,
	thread = 5,
	deer = 11,
	rope = 23,
	helmet = 40,
	grass = 8,
    closet = 34,
	helmetWithWater = 43,
	HoneyComb = 56,
    river = 29,
	veil = 62,
	helmetWithTea = 65,
	helmetWithWarmWater = 67,
	helmetWithWarmTea = 66,
	Venison = 75,
	Moly = 70,
	Wine = 73,
    DeerFromCliff = 22,
    MazeFromCliff = 18,
    CastleFromCliff = 21,
    CastleFromCliff2 = 51,
    SmoothStone = 77,
	Goblet = 73
}

enum MessageType3
{
	sword = 1,
	//spear = 3,
	animalgluecrystals = 5,
	bowl = 7,
	bowlwithwater = 9,
	spade = 11,
	stick = 13,
	unheatedanimalglue = 15,
	heatedanimalglue = 17,
	stickwithheatedanimalglue = 19,
	shovel = 21,
	river = 351,
	firepit = 352
}

public class ObjectInformation : MonoBehaviour
{
	public int ObjectID;
	//public bool isSelected;
	public int NumberOfFrame_X;
	public string Name;


	private int current_Level;

	void Awake ()
	{
		current_Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
	}

	// Use this for initialization
	void Start () 
	{
		if (current_Level == 1) {
		//isSelected = false;
			switch(ObjectID)
			{
			case 1:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.Flint];
				break;
			case 2:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.slightfilledbag];
				break;
			case 3:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.partiallyfilledbag];
				break;
			case 4:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.almostfullbag];
				break;
			case 5:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.fullbag];
				break;
			case 6:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.winebottles];
				break;
			case 7:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.winebottles];
				break;
			case 8:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.winebottles];
				break;
			case 9:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.winebottles];
				break;
			case 10:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.wardrobekey];
				break;
			case 11:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.sword];
				break;
			case 12:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.osierband];
				break;
			case 13:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.treebranch];
				break;
			case 14:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.stake];
				break;
			case 15:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.charredstake];
				break;
			case 16:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.stackofcheese];
				break;
			case 20:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.emptybag];
				break;
			case 27:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.stackofcheese];
				break;
			case 28:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.stackofcheese];
				break;
			case 40:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.bush];
				break;
			case 44:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType1.vines];
				break;

			default:
				Name = "Not set";
				break;
			}
		}

		else if (current_Level == 2) {
			switch(ObjectID)
			{
			case 11:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.sword];
				break;
			case 60:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.spear];
				break;
			case 61:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.thread];
				break;
			case 62:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.deer];
				break;
			case 63:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.grass];
				break;
			case 64:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.rope];
				break;
			case 65:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.deer];
				break;
			case 67:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.helmet];
				break;
            case 66:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.closet];
				break;
			case 70:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.helmetWithWater];
				break;
			case 68:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.HoneyComb];
				break;
			case 75:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.veil];
				break;
			case 74:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.helmet];
				break;
			case 72:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.helmetWithTea];
				break;
			case 71:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.helmetWithWarmWater];
				break;
			case 73:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.helmetWithWarmTea];
				break;
			case 81:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.Venison];
				break;
			case 82:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.Moly];
				break;
			case 85:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType2.Wine];
				break;
            case 86:
                Name = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[(int)MessageType2.DeerFromCliff];
                break;
            case 87:
                Name = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[(int)MessageType2.MazeFromCliff];
                break;
            case 88:
                Name = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[(int)MessageType2.CastleFromCliff];
                break;
            case 80:
                Name = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[(int)MessageType2.SmoothStone];
                break;
            case 89:
                Name = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[(int)MessageType2.CastleFromCliff2];
                break;
			case 84:
				Name = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().Description[(int)MessageType2.Goblet];
				break;
			default:
				Name = "Not set";
				break; 

			}
		}
		else if (current_Level == 3) 
		{
			switch(ObjectID)
			{
			case 11:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.sword];
				break;
			//case 60:
			//	Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.spear];
			//	break;
			case 52:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.animalgluecrystals];
				break;
			case 53:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.bowl];
				break;
			case 54:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.bowlwithwater];
				break;
			case 60:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.spade];
				break;
			case 57:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.stick];
				break;
			case 55:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.unheatedanimalglue];
				break;
			case 56:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.heatedanimalglue];
				break;
			case 58:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.stickwithheatedanimalglue];
				break;
			case 59:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.shovel];
				break;
				// Environmental
			case 351:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.river];
				break;
			case 352:
				Name = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Description[(int)MessageType3.firepit];
				break;


			default:
				Name = "Not set";
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
