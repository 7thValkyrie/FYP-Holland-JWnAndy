using UnityEngine;
using System.Collections;

public class DialogueBox : MonoBehaviour 
{
	public string Dialogue;
	public GUIStyle style;
	public GUISkin guiskin;
	public float Dialogue_Width, Dialogue_Height;
	public float Button_Width, Button_Height;
	public float NameBox_Width, NameBox_Height;
	public bool Activate_Elpenor2;
	public bool Activate_Elpenor3;
	public bool Activate_Elpenor4;
	private string NameDisplay;
	
	private string[] DialogueArray;
	public bool isSetDialogue;

	private int CurrentIndex;
	private int IndexCounter;

	private bool isChoice;
	public string ChoiceDialogue_1, ChoiceDialogue_2, ChoiceDialogue_3;
	public int ChoiceSelected;
	private bool isTwoChoice;

	private int OdysseusPrevExpression_Index;

	private int Level = 0;
	void Awake() {
		Level = GameObject.Find ("SaveData").GetComponent<SaveData> ().current_Level;
	}
	// Use this for initialization 
	void Start () 
	{
		DialogueArray = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Dialogue;
		IndexCounter = 0;
		isChoice = false;
		ChoiceSelected = 0;
		isTwoChoice = false;
		OdysseusPrevExpression_Index = 0;
		style.fontSize = 10;
		style.fontStyle = FontStyle.BoldAndItalic;

	}
	
	// Update is called once per frame
	void Update () 
	{
		InputUpdate ();
	}

	void InputUpdate ()
	{
		if (this.GetComponent<DialogueBox>().enabled == true && isSetDialogue == false)
		{
			if(Input.GetMouseButtonUp(0) == true)
			{
				this.GetComponent<DialogueBox>().enabled = false;
                if (GameObject.Find("DialogueBackground") != null)
                {
                    GameObject.Find("DialogueBackground").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("OdysseusDialogue") != null)
                {
                    GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("CyclopsDialogue") != null)
                {
                    GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("ElpenorDialogue") != null)
                {
                    GameObject.Find("ElpenorDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("BeardyManDialouge") != null)
                {
                    GameObject.Find("BeardyManDialouge").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("HairyManDialogue") != null)
                {
                    GameObject.Find("HairyManDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("MoustacheDialogue") != null)
                {
                    GameObject.Find("MoustacheDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("OtherCyclops_BlueDialogue") != null)
                {
                    GameObject.Find("OtherCyclops_BlueDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("OtherCyclops_HairDialogue") != null)
                {
                    GameObject.Find("OtherCyclops_HairDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("RamDialogue") != null)
                {
                    GameObject.Find("RamDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("MenDialogue") != null)
                {
                    GameObject.Find("MenDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("ChefDialogue") != null)
                {
                    GameObject.Find("ChefDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("PersonADialogue") != null)
                {
                    GameObject.Find("PersonADialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("PersonBDialogue") != null)
                {
                    GameObject.Find("PersonBDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("EurylochusDialogue") != null)
                {
                    GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("CirceDialogue") != null)
                {
                    GameObject.Find("CirceDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }

                if (GameObject.Find("HermesDialogue") != null)
                {
                    GameObject.Find("HermesDialogue").GetComponent<SpriteRenderer>().enabled = false;
                }
			}
		}
		else if(isSetDialogue == true && isChoice == false)
		{
			if(Input.GetMouseButtonUp(0) == true && GameObject.Find("DescriptionBox").GetComponent<DescriptionBox>().enabled == false)
			{
				IndexCounter += 1;
				DisplayDialogue(CurrentIndex);
			}
		}

	}
	void OnGUI ()
	{
		GUI.skin = guiskin;
		GUI.Box(new Rect(this.transform.position.x/1280.0f*Screen.width, (this.transform.position.y/720.0f * Screen.height) * -1 , Dialogue_Width / 1280.0f * Screen.width,  Dialogue_Height / 720.0f * Screen.height), Dialogue);
	
		GUI.skin.box.fontSize = (int)(Screen.width * 0.02f);
		GUI.skin.box.overflow.left = (int)(Screen.width * 0.048476f);

		GUI.skin.box.overflow.right = (int)(Screen.width * 0.048476f);
		GUI.skin.button.wordWrap = true;
		//GUI.skin.button.alignment = TextAnchor.MiddleLeft;
        if (NameDisplay != null)
        {
            if (NameDisplay.Length > 14)
            {
                GUI.skin.label.fontSize = (int)(Screen.width * 0.01f);
            }
            else if (NameDisplay.Length > 9)
            {
                GUI.skin.label.fontSize = (int)(Screen.width * 0.014f);
            }
            else
            {
                GUI.skin.label.fontSize = (int)(Screen.width * 0.017f);
            }
            GUI.Label(new Rect(this.transform.position.x / 1280.0f * Screen.width, (this.transform.position.y / 720.0f * Screen.height + NameBox_Height / 720.0f * Screen.height) * -1, NameBox_Width / 1280.0f * Screen.width, NameBox_Height / 720.0f * Screen.height), NameDisplay);
            if (isChoice == true)
            {
                if (ChoiceDialogue_1.Length > 80 ||
                    ChoiceDialogue_2.Length > 80 ||
                    ChoiceDialogue_3.Length > 80)
                {
                    GUI.skin.button.fontSize = (int)(Screen.width * 0.015f);
                }
                else
                {
                    GUI.skin.button.fontSize = (int)(Screen.width * 0.018f);
                }
                if (isTwoChoice == true)
                {
                    //Button 1 (Choice 1)
                    if (GUI.Button(new Rect(this.transform.position.x / 1280.0f * Screen.width, ((this.transform.position.y - 65.0f) / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ChoiceDialogue_1) == true)
                    {
                        ChoiceSelected = 1;
                        isChoice = false;
                    }
                    //Button 2 (Choice 2)
                    if (GUI.Button(new Rect(this.transform.position.x / 1280.0f * Screen.width, ((this.transform.position.y - 65.0f - 20.0f - Button_Height) / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ChoiceDialogue_2) == true)
                    {
                        ChoiceSelected = 2;
                        isChoice = false;
                    }
                }
                else
                {
                    //Button 1 (Choice 1)
                    if (GUI.Button(new Rect(this.transform.position.x / 1280.0f * Screen.width, ((this.transform.position.y - 40.0f) / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ChoiceDialogue_1) == true)
                    {
                        ChoiceSelected = 1;
                        isChoice = false;
                    }
                    //Button 2 (Choice 2)
                    if (GUI.Button(new Rect(this.transform.position.x / 1280.0f * Screen.width, ((this.transform.position.y - 40.0f - 5.0f - Button_Height) / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ChoiceDialogue_2) == true)
                    {
                        ChoiceSelected = 2;
                        isChoice = false;
                    }
                    //Button 3 (Choice 3)
                    if (GUI.Button(new Rect(this.transform.position.x / 1280.0f * Screen.width, ((this.transform.position.y - 40.0f - 5.0f - 5.0f - Button_Height - Button_Height) / 720.0f * Screen.height) * -1, Button_Width / 1280.0f * Screen.width, Button_Height / 720.0f * Screen.height), ChoiceDialogue_3) == true)
                    {
                        ChoiceSelected = 3;
                        isChoice = false;
                    }
                }
            }
        }

	}

	void OdysseueTalking (bool b_Display, int ExpressionIndex)
	{
		Animator OdysseusAnimator = GameObject.Find("OdysseusDialogue").GetComponent<Animator> ();

		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
			//Neutral Idle
			case 1:
				OdysseusAnimator.SetInteger("Index", 1);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			//Neutral Talking
			case 2:
				OdysseusAnimator.SetInteger("Index", 2);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3: //pissed off idle
				OdysseusAnimator.SetInteger("Index", 3);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 4: //pissed off talking
				OdysseusAnimator.SetInteger("Index", 4);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 5: // Unimpressed Idle blink
				OdysseusAnimator.SetInteger("Index", 5);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 6: //Unimpressed talking
				OdysseusAnimator.SetInteger("Index", 6);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 7: //Unimpressed talking... blink?
				OdysseusAnimator.SetInteger("Index", 7);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 8: // Arrogant Talking
				OdysseusAnimator.SetInteger("Index", 8);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 9: // Screaming
				OdysseusAnimator.SetInteger("Index", 9);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 10: // Chapter 2
				OdysseusAnimator.SetInteger("Index", 10);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			default:
				break;
			}
		}
		else
		{
			switch(ExpressionIndex)
			{
				//Neutral Idle
			case 1:
				OdysseusAnimator.SetInteger("Index", 1);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
				//Neutral Talking
			case 2:
				OdysseusAnimator.SetInteger("Index", 2);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
            case 3: //pissed off idle
				OdysseusAnimator.SetInteger("Index", 3);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
            case 4: //pissed off talking
				OdysseusAnimator.SetInteger("Index", 4);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
            case 5: // Unimpressed Idle blink
				OdysseusAnimator.SetInteger("Index", 5);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
			case 6: //Unimpressed talking
				OdysseusAnimator.SetInteger("Index", 6);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
            case 7: //Unimpressed talking... blink?
				OdysseusAnimator.SetInteger("Index", 7);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
            case 8: // Arrogant Talking
				OdysseusAnimator.SetInteger("Index", 8);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
            case 9: // Screaming
				OdysseusAnimator.SetInteger("Index", 9);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
			case 10: // Chapter 2
				OdysseusAnimator.SetInteger("Index", 10);
				GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
			default:
				break;
			}
		}

		GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void EurylochusTalking (bool b_Display, int ExpressionIndex)
	{
		Animator EurylochusAnimator = GameObject.Find("EurylochusDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Neutral Idle
			case 1:
				EurylochusAnimator.SetInteger("Index", 1);
				GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Neutral Talking
			case 2:
				EurylochusAnimator.SetInteger("Index", 2);
				GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			default:
				break;
			}
		}
		else
		{
			switch(ExpressionIndex)
			{
				//Neutral Idle
			case 1:
				EurylochusAnimator.SetInteger("Index", 1);
				GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
				//Neutral Talking
			case 2:
				EurylochusAnimator.SetInteger("Index", 2);
				GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				break;
			default:
				break;
			}
		}
		
		GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void MenTalking ( bool b_Display, int ExpressionIndex )
	{
				if (b_Display == true) {
						switch (ExpressionIndex) {
						case 1:
								GameObject.Find ("MenDialogue").GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);
								break;

						case 2:
								GameObject.Find ("MenDialogue").GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);
								break;
						case 3:
								break;
						case 4:
								break;
						}
				} 
		else 
				{
					GameObject.Find("MenDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
				}
		GameObject.Find("MenDialogue").GetComponent<SpriteRenderer>().enabled = true;
		}

	void ChefTalking ( bool b_Display)
	{
		Animator ChefAnimator = GameObject.Find("ChefDialogue").GetComponent<Animator> ();
		if (b_Display == true) {
		
				ChefAnimator.SetBool("isTalking", true);
				GameObject.Find ("ChefDialogue").GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);
		} 
		else 
		{
			ChefAnimator.SetBool("isTalking", false);
			GameObject.Find("ChefDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		GameObject.Find("ChefDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void CyclopTalking (bool b_Display, int ExpressionIndex)
	{
		Animator CyclopsAnimator = GameObject.Find("CyclopsDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				CyclopsAnimator.SetBool("isTalking", false);
				GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Neutral Talking
			case 2:
				CyclopsAnimator.SetBool("isTalking", true);
				GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				CyclopsAnimator.SetBool("isInjured",true);
				CyclopsAnimator.SetBool("isTalking", false);
				GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 4:
				CyclopsAnimator.SetBool("isInjured",true);
				CyclopsAnimator.SetBool("isTalking", true);
				GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			CyclopsAnimator.SetBool("isTalking", false);
			GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("CyclopsDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void OtherCyclopsTalking (bool b_Display, int ExpressionIndex) 
	{
		Animator CyclopsAnimator1 = GameObject.Find("OtherCyclops_BlueDialogue").GetComponent<Animator> ();
		Animator CyclopsAnimator2 = GameObject.Find("OtherCyclops_HairDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				CyclopsAnimator1.SetBool("isTalking", false);
				CyclopsAnimator2.SetBool("isTalking", false);
				GameObject.Find("OtherCyclops_BlueDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				GameObject.Find("OtherCyclops_HairDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Neutral Talking
			case 2:
				CyclopsAnimator1.SetBool("isTalking", true);
				CyclopsAnimator2.SetBool("isTalking", true);
				GameObject.Find("OtherCyclops_BlueDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				GameObject.Find("OtherCyclops_HairDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			CyclopsAnimator1.SetBool("isTalking", false);
			CyclopsAnimator2.SetBool("isTalking", false);
			GameObject.Find("OtherCyclops_BlueDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
			GameObject.Find("OtherCyclops_HairDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}

		GameObject.Find("OtherCyclops_BlueDialogue").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("OtherCyclops_HairDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}
	
	void ElpenorTalking (bool b_Display, int ExpressionIndex)
	{
		Animator ElpenorAnimator = GameObject.Find("ElpenorDialogue").GetComponent<Animator> ();

		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
			//Idle
			case 1:
				ElpenorAnimator.SetBool("isTalking", false);
				GameObject.Find("ElpenorDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			//Angry Talking
			case 2:
				ElpenorAnimator.SetBool("isTalking", true);
				GameObject.Find("ElpenorDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			ElpenorAnimator.SetBool("isTalking", false);
			GameObject.Find("ElpenorDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}

		GameObject.Find("ElpenorDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void BeardyTalking (bool b_Display, int ExpressionIndex)
	{
		Animator BeardyAnimator = GameObject.Find("BeardyManDialouge").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				BeardyAnimator.SetBool("isTalking", false);
				GameObject.Find("BeardyManDialouge").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Angry Talking
			case 2:
				BeardyAnimator.SetBool("isTalking", true);
				GameObject.Find("BeardyManDialouge").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			BeardyAnimator.SetBool("isTalking", false);
			GameObject.Find("BeardyManDialouge").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("BeardyManDialouge").GetComponent<SpriteRenderer>().enabled = true;
	}

	void MoustacheTalking (bool b_Display, int ExpressionIndex)
	{
		Animator MoustacheAnimator = GameObject.Find("MoustacheDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				MoustacheAnimator.SetBool("isTalking", false);
				GameObject.Find("MoustacheDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Angry Talking
			case 2:
				MoustacheAnimator.SetBool("isTalking", true);
				GameObject.Find("MoustacheDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			MoustacheAnimator.SetBool("isTalking", false);
			GameObject.Find("MoustacheDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("MoustacheDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void HairyTalking (bool b_Display, int ExpressionIndex)
	{
		Animator HairyAnimator = GameObject.Find("HairyManDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				HairyAnimator.SetBool("isTalking", false);
				GameObject.Find("HairyManDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Angry Talking
			case 2:
				HairyAnimator.SetBool("isTalking", true);
				GameObject.Find("HairyManDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			HairyAnimator.SetBool("isTalking", false);
			GameObject.Find("HairyManDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("HairyManDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}
	
	
	void RamTalking (bool b_Display, int ExpressionIndex)
	{
		Animator RamAnimator = GameObject.Find("RamDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				RamAnimator.SetBool("isTalking", false);
				GameObject.Find("RamDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Neutral Talking
			case 2:
				RamAnimator.SetBool("isTalking", true);
				GameObject.Find("RamDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			RamAnimator.SetBool("isTalking", false);
			GameObject.Find("RamDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("RamDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void CirceTalking (bool b_Display, int ExpressionIndex)
	{
		Animator CirceAnimator = GameObject.Find("CirceDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				CirceAnimator.SetBool("isTalking", false);
				GameObject.Find("CirceDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Neutral Talking
			case 2:
				CirceAnimator.SetBool("isTalking", true);
				GameObject.Find("CirceDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			CirceAnimator.SetBool("isTalking", false);
			GameObject.Find("CirceDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("CirceDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void HermesTalking (bool b_Display, int ExpressionIndex)
	{
		Animator HermesAnimator = GameObject.Find("HermesDialogue").GetComponent<Animator> ();
		
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				HermesAnimator.SetBool("isTalking", false);
				GameObject.Find("HermesDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Neutral Talking
			case 2:
				HermesAnimator.SetBool("isTalking", true);
				GameObject.Find("HermesDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			HermesAnimator.SetBool("isTalking", false);
			GameObject.Find("HermesDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("HermesDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void PersonA (bool b_Display, int ExpressionIndex)
	{
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				GameObject.Find("PersonADialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Angry Talking
			case 2:
				GameObject.Find("PersonADialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			GameObject.Find("PersonADialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("PersonADialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	void PersonB (bool b_Display, int ExpressionIndex)
	{
		if(b_Display == true)
		{
			switch(ExpressionIndex)
			{
				//Idle
			case 1:
				GameObject.Find("PersonBDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
				//Angry Talking
			case 2:
				GameObject.Find("PersonBDialogue").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
		}
		else
		{
			GameObject.Find("PersonBDialogue").GetComponent<SpriteRenderer>().color = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);
		}
		
		GameObject.Find("PersonBDialogue").GetComponent<SpriteRenderer>().enabled = true;
	}

	public void DisplayDialogue (int Index)
	{
				DialogueArray = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Dialogue;
				if (Level == 1) {
						switch (Index) {
						case 1:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;

								GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkedToElpenor = true;
								if (IndexCounter == 0) {
										NameDisplay = "Elpenor";
										OdysseueTalking (false, 1);
										ElpenorTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [0];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 1);
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [1];
										ChoiceDialogue_2 = DialogueArray [2];
										ChoiceDialogue_3 = DialogueArray [3];
										isChoice = true;
										isTwoChoice = false;
								} else if (IndexCounter == 2) {
										NameDisplay = "Elpenor";
										ElpenorTalking (true, 2);
										if (ChoiceSelected == 1) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [4];
												OdysseueTalking (false, 5);
												OdysseusPrevExpression_Index = 5;
										} else if (ChoiceSelected == 2 || ChoiceSelected == 3) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [5];
												OdysseueTalking (false, 7);
												OdysseusPrevExpression_Index = 7;
										}
								} else if (IndexCounter == 3) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, OdysseusPrevExpression_Index);
										ElpenorTalking (false, 1);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [6];
										ChoiceDialogue_2 = DialogueArray [7];
										isChoice = true;
										isTwoChoice = true;
								} else if (IndexCounter == 4) {
										NameDisplay = "Elpenor";
										ElpenorTalking (true, 2);
										if (ChoiceSelected == 1) {
												OdysseueTalking (false, 7);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [8];
										} else if (ChoiceSelected == 2) {
												OdysseueTalking (false, 5);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [9];
										}
								} else if (IndexCounter == 5) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 4);
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [10];
					
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 2:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Elpenor";
										OdysseueTalking (false, 1);
										ElpenorTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [11];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 1);
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [12];
										ChoiceDialogue_2 = DialogueArray [13];
										ChoiceDialogue_3 = DialogueArray [14];
										isChoice = true;
										isTwoChoice = false;
								} else if (IndexCounter == 2) {
										NameDisplay = "Elpenor";
										ElpenorTalking (true, 2);
										if (ChoiceSelected == 1 || ChoiceSelected == 2) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [15];
												OdysseueTalking (false, 5);
										} else if (ChoiceSelected == 3) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [16];
												OdysseueTalking (false, 1);
										}
								} else if (IndexCounter == 3) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [17];
								} else if (IndexCounter == 4) {
										NameDisplay = "Narration";
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [0];
								} else if (IndexCounter == 5) {
										//START MINI GAME
										//**********************************************
										//	For now i just skip the Mini-Game
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().FinishGetting12Men = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "12MenMiniGame";
					
										CurrentIndex = 0;
										IndexCounter = 0;
										isSetDialogue = false;
								}
								break;
						case 3:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ObserveFireWood == false && GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetFlint == true) {
										if (IndexCounter == 0) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 2);
												ElpenorTalking (false, 0);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [38];
										} else if (IndexCounter == 1) {
												NameDisplay = "Elpenor";
												OdysseueTalking (false, 1);
												ElpenorTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [39];
						
												isSetDialogue = false;
												CurrentIndex = 0;
												IndexCounter = 0;
						
												//Got all cheese objective done! 
												GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GotAllTheCheese = true;
										}
								} else {
										if (IndexCounter == 0) {
												NameDisplay = "Elpenor";
												OdysseueTalking (false, 1);
												ElpenorTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [18];
										} else if (IndexCounter == 1) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 2);
												ElpenorTalking (false, 0);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [19];
										} else if (IndexCounter == 2) {
												NameDisplay = "Elpenor";
												OdysseueTalking (false, 1);
												ElpenorTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [20];
						
												isSetDialogue = false;
												CurrentIndex = 0;
												IndexCounter = 0;

												//Got all cheese objective done! 
												GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GotAllTheCheese = true;
										}
								}


								break;
						case 4:
								if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetFlint == true && GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().ObserveFireWood == true) {
										this.enabled = true;
										isSetDialogue = true;
										CurrentIndex = Index;
										GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
										if (IndexCounter == 0) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 2);
												MenTalking (false, 1);
												BeardyTalking (false, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [38];
										} else if (IndexCounter == 1) {
												NameDisplay = "Men";
												OdysseueTalking (false, 1);
												MenTalking (true, 1);
												BeardyTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [39];
						
												isSetDialogue = false;
												CurrentIndex = 0;
												IndexCounter = 0;
										}
								} else if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().LightedBurntWood == false) {
										this.enabled = true;
										isSetDialogue = true;
										CurrentIndex = Index;
										GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
										if (IndexCounter == 0) {
												NameDisplay = "Men";
												OdysseueTalking (false, 1);
												MenTalking (true, 1);
												BeardyTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [23];
										} else if (IndexCounter == 1) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 6);
												MenTalking (false, 0);
												BeardyTalking (false, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [24];
						
												isSetDialogue = false;
												CurrentIndex = 0;
												IndexCounter = 0;
										}
								} else if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().OfferedCheeseToGod == false) {
										this.enabled = true;
										isSetDialogue = true;
										CurrentIndex = Index;
										GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
										if (IndexCounter == 0) {
												NameDisplay = "Men";
												OdysseueTalking (false, 1);
												MenTalking (true, 1);
												BeardyTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [25];
										} else if (IndexCounter == 1) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 6);
												MenTalking (false, 0);
												BeardyTalking (false, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [26];
						
												isSetDialogue = false;
												CurrentIndex = 0;
												IndexCounter = 0;
										}
								} else if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().OfferedCheeseToMen == false) {
										this.enabled = true;
										isSetDialogue = true;
										CurrentIndex = Index;
										GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
										if (IndexCounter == 0) {
												NameDisplay = "Men";
												OdysseueTalking (false, 1);
												MenTalking (true, 1);
												BeardyTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [21];
										} else if (IndexCounter == 1) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 1);
												MenTalking (false, 1);
												BeardyTalking (false, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
												ChoiceDialogue_1 = DialogueArray [22];
												ChoiceDialogue_2 = DialogueArray [23];
												ChoiceDialogue_3 = DialogueArray [24];
												isChoice = true;
												isTwoChoice = false;
										} else if (IndexCounter == 2) {
												NameDisplay = "Men";
												if (ChoiceSelected == 1) {
														OdysseueTalking (false, 5);
														MenTalking (true, 1);
														BeardyTalking (true, 2);
														GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [25];
												} else if (ChoiceSelected == 3 || ChoiceSelected == 2) {
														OdysseueTalking (false, 1);
														MenTalking (true, 1);
														BeardyTalking (true, 2);
														GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [26];
												}
										} else if (IndexCounter == 3) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 2);
												MenTalking (false, 1);
												BeardyTalking (false, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [27];

										} else if (IndexCounter == 4) {
												//Delete away one feta cheese
												int tempID = 0;
												for (int i = 1; i < GameObject.Find("InventoryBag").GetComponent<Inventory>().ObjectID; i++) {
														int tempStroage = GameObject.Find ("InventoryItem_" + i).GetComponent<ObjectInformation> ().ObjectID;
														if (tempStroage == 16 || tempStroage == 27 || tempStroage == 28) {
																tempID = tempStroage;
														}
												}
												GameObject.Find ("InventoryBag").GetComponent<Inventory> ().DestoryItemIcon (tempID);
												GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().OfferedCheeseToMen = true;

												GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
												GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
						
												CurrentIndex = 0;
												IndexCounter = 0;
												isSetDialogue = false;
										}
								}
								break;
						case 5:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Narration";
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [1];
								} else if (IndexCounter == 1) {
										NameDisplay = "Narration";
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [2];
								} else if (IndexCounter == 2) {
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = false;
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [28];
								} else if (IndexCounter == 3) {
										NameDisplay = "Cyclops";
										OdysseueTalking (false, 0);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [29];
								} else if (IndexCounter == 4) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 9);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [30];
								} else if (IndexCounter == 5) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 9);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [31];
										ChoiceDialogue_2 = DialogueArray [32];
										isChoice = true;
										isTwoChoice = true;
								} else if (IndexCounter == 6) {
										NameDisplay = "Cyclops";
										OdysseueTalking (false, 3);
										CyclopTalking (true, 2);
										if (ChoiceSelected == 1 || ChoiceSelected == 2) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [33];
										} else if (ChoiceSelected == 3) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [34];
										}
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 6:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Men";
										MenTalking (true, 2);
										BeardyTalking (true, 2);
										OdysseueTalking (false, 3);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [35];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 4);
										MenTalking (false, 0);
										BeardyTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [36];
								} else if (IndexCounter == 2) {
										NameDisplay = "Narration";
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [3];
								} else if (IndexCounter == 3) {
										NameDisplay = "Narration";
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [4];
								} else if (IndexCounter == 4) {
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cyclops_Bedroom";
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;

										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().CyclopLeaveCave = true;
								}
								break;
						case 7:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Elpenor";
										OdysseueTalking (false, 1);
										ElpenorTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [37];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 1);
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [38];
										ChoiceDialogue_2 = DialogueArray [39];
										ChoiceDialogue_3 = DialogueArray [40];
										isChoice = true;
										isTwoChoice = false;
								} else if (IndexCounter == 2) {
										if (ChoiceSelected == 1) {
												NameDisplay = "Elpenor";
												OdysseueTalking (false, 1);
												ElpenorTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [41];
										} else if (ChoiceSelected == 2) {
												NameDisplay = "Men";
												GameObject.Find ("ElpenorDialogue").GetComponent<SpriteRenderer> ().enabled = false;
												MenTalking (true, 2);
												BeardyTalking (true, 2);
												OdysseueTalking (false, 7);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [42];
										} else if (ChoiceSelected == 3) {
												NameDisplay = "Elpenor";
												OdysseueTalking (false, 7);
												ElpenorTalking (true, 2);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [43];
										}
								} else if (IndexCounter == 3) {
										NameDisplay = "Odysseus";
										GameObject.Find ("MenDialogue").GetComponent<SpriteRenderer> ().enabled = false;
										GameObject.Find ("BeardyManDialouge").GetComponent<SpriteRenderer> ().enabled = false;
										ElpenorTalking (false, 0);
										if (ChoiceSelected == 1 || ChoiceSelected == 2) {
												OdysseueTalking (true, 3);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [44];
										} else if (ChoiceSelected == 3) {
												OdysseueTalking (true, 1);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [45];
										}
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 8:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
//				if(IndexCounter == 0)
//				{
//				}
//				else 
								if (IndexCounter == 0) {
										NameDisplay = "Men";
										OdysseueTalking (false, 1);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [47];

								} else if (IndexCounter == 1) {

										NameDisplay = "Odysseus";
										OdysseueTalking (true, 1);
										MenTalking (false, 1);
										BeardyTalking (false, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [48];
										ChoiceDialogue_2 = DialogueArray [49];
										ChoiceDialogue_3 = DialogueArray [50];
										isChoice = true;
										isTwoChoice = false;
								} else if (IndexCounter == 2) {
										NameDisplay = "Men";
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										OdysseueTalking (false, 1);
										if (ChoiceSelected == 1) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [54];
										} else if (ChoiceSelected == 2) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [51];
										} else if (ChoiceSelected == 3) {
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [52];
										}
								} else if (IndexCounter == 3) {
										NameDisplay = "Odysseus";
										MenTalking (false, 1);
										BeardyTalking (false, 2);
										if (ChoiceSelected == 1) {
												OdysseueTalking (true, 2);

												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [55];
										} else if (ChoiceSelected == 2 || ChoiceSelected == 3) {
												OdysseueTalking (true, 5);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [53];
												IndexCounter -= 3;
										}
								} else if (IndexCounter == 4) {
										NameDisplay = "Men";
										OdysseueTalking (false, 1);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [56];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 9:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Men";
										OdysseueTalking (false, 7);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [57];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 8);
										MenTalking (false, 1);
										BeardyTalking (false, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [58];
								} else if (IndexCounter == 2) {
										NameDisplay = "Men";
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										OdysseueTalking (false, 5);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
								} else if (IndexCounter == 3) {
										NameDisplay = "Men";
										OdysseueTalking (false, 5);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
								} else if (IndexCounter == 4) {
										NameDisplay = "Men";
										OdysseueTalking (false, 5);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [61];
								} else if (IndexCounter == 5) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 6);
										MenTalking (false, 1);
										BeardyTalking (false, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [62];
								} else if (IndexCounter == 6) {
										NameDisplay = "Men";
										OdysseueTalking (false, 1);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [63];
								} else if (IndexCounter == 7) {
										NameDisplay = "Men";
										OdysseueTalking (false, 1);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [64];
								} else if (IndexCounter == 8) {
										NameDisplay = "Men";
										OdysseueTalking (false, 1);
										MenTalking (true, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [65];
								} else if (IndexCounter == 9) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										MenTalking (false, 1);
										BeardyTalking (false, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [66];
								} else if (IndexCounter == 10) {
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Night";
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;

										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 10:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [67];
								} else if (IndexCounter == 1) {
										NameDisplay = "Cyclops";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [68];
								} else if (IndexCounter == 2) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [69];
								} else if (IndexCounter == 3) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [117];
								} else if (IndexCounter == 4) {
										NameDisplay = "Cyclops";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [70];
								} else if (IndexCounter == 5) {
										NameDisplay = "Cyclops";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [71];
								} else if (IndexCounter == 6) {
										NameDisplay = "Polyphemus";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [72];
										GameObject.Find ("Cyclops").GetComponent<SpriteRenderer> ().enabled = false;
										GameObject.Find ("Cyclops_OneThirdDrunk").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("Cyclops").GetComponent<ObjectInformation> ().NumberOfFrame_X = 6;
								} else if (IndexCounter == 7) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 8);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [73];
								} else if (IndexCounter == 8) {
										NameDisplay = "Polyphemus";
										OdysseueTalking (false, 3);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [74];
								} else if (IndexCounter == 9) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 4);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [75];
										ChoiceDialogue_2 = DialogueArray [76];
										ChoiceDialogue_3 = DialogueArray [77];
										isChoice = true;
										isTwoChoice = false;
								} else if (IndexCounter == 10) {
										NameDisplay = "Polyphemus";
										CyclopTalking (true, 2);
										if (ChoiceSelected == 1 || ChoiceSelected == 2) {
												OdysseueTalking (false, 3);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [78];
										} else if (ChoiceSelected == 3) {
												OdysseueTalking (false, 3);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [79];
										}
								} else if (IndexCounter == 11) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 3);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [80];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										//Testing to change dialogue after finishing one *************************************************************************************
										//GameObject.Find("Odysseus").GetComponent<CharacterDialogue>().DialogueID = 11;
								}
								break;
						case 11:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [81];
								} else if (IndexCounter == 1) {
										NameDisplay = "Polyphemus";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [82];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										//Testing to change dialogue after finishing one *************************************************************************************
										//GameObject.Find("Aaron").GetComponent<CharacterDialogue>().DialogueID = 12;
								}
								break;
						case 12:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Polyphemus";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [83];
								} else if (IndexCounter == 1) {
										NameDisplay = "Polyphemus";
										OdysseueTalking (false, 1);
										CyclopTalking (true, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [84];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 13:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										HairyTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [85];
								} else if (IndexCounter == 1) {
										NameDisplay = "Actor";
										OdysseueTalking (false, 1);
										HairyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [86];
								} else if (IndexCounter == 2) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										HairyTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [87];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkedToMan1 = true;
								}
								break;
						case 14:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										MoustacheTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [85];
								} else if (IndexCounter == 1) {
										NameDisplay = "Bias";
										OdysseueTalking (false, 1);
										MoustacheTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [88];
								} else if (IndexCounter == 2) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										MoustacheTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [89];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkedToMan2 = true;
								}
								break;
						case 15:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										BeardyTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [85];
								} else if (IndexCounter == 1) {
										NameDisplay = "Castor";
										OdysseueTalking (false, 1);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [90];
								} else if (IndexCounter == 2) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 4);
										BeardyTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [91];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().TalkedToMan3 = true;
								}
								break;
						case 16:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [92];
								} else if (IndexCounter == 2) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [93];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 17:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										NameDisplay = "Polyphemus";
										RamTalking (false, 0);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [94];
								} else if (IndexCounter == 1) {
										NameDisplay = "Master Ram";
										RamTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [95];
								} else if (IndexCounter == 2) {
										NameDisplay = "Polyphemus";
										RamTalking (false, 0);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [96];
								} else if (IndexCounter == 3) {
										NameDisplay = "Master Ram";
										RamTalking (true, 2);
										CyclopTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [97];
								} else if (IndexCounter == 4) {
										NameDisplay = "Polyphemus";
										RamTalking (false, 0);
										CyclopTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [98];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "OutsideCave_Enviroment";
								}
								break;
						case 18:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;
								if (IndexCounter == 0) {
										NameDisplay = "Elpenor";
										OdysseueTalking (false, 1);
										ElpenorTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [27];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [28];
					
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 19:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;
								if (IndexCounter == 0) {
										NameDisplay = "Men";
										OdysseueTalking (false, 1);
										//ElpenorTalking(true, 2);
										MenTalking (true, 2);
										BeardyTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [29];
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										//ElpenorTalking(false, 0);
										MenTalking (false, 0);
										BeardyTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [30];
					
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 20:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;
								if (IndexCounter == 0) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [31];

								} else if (IndexCounter == 1) {
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "CaveTree_CloseUp";
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 21:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;
								if (IndexCounter == 0) {
										NameDisplay = "Narration";
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [5];
								} else if (IndexCounter == 1) {
										NameDisplay = "Narration";
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [6];
								} else if (IndexCounter == 2) {
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = false;
										NameDisplay = "Polyphemus";
										CyclopTalking (true, 4);
										OtherCyclopsTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [99];
					
								} else if (IndexCounter == 3) {
										NameDisplay = "Other Cyclops";
										CyclopTalking (false, 3);
										OtherCyclopsTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [100];
								} else if (IndexCounter == 4) {
										NameDisplay = "Polyphemus";
										CyclopTalking (true, 4);
										OtherCyclopsTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [101];
								} else if (IndexCounter == 5) {
										NameDisplay = "Other Cyclops";
										CyclopTalking (false, 3);
										OtherCyclopsTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [102];
										//				isSetDialogue = false;
										//				CurrentIndex = 0;
										//				IndexCounter = 0;
								} else if (IndexCounter == 6) {
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										//GameObject.Find("DialogueBox").GetComponent<DialogueBox>().DisplayDialogue(13);
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 22:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;
								if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GotAllTheCheese = true)
								{
									if (GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetFlint == false) 
									{
											if (IndexCounter == 0) {
													NameDisplay = "Odysseus";
													OdysseueTalking (true, 2);
													ChefTalking (false);
													//GameObject.Find("DialogueBox").GetComponent<DialogueBox>().Dialogue = GameObject.Find("DialogueStorage").GetComponent<CSVReader>().OneLiner[30];
													GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [38];

											} else if (IndexCounter == 1) {
													NameDisplay = "Chef Nicon";
													OdysseueTalking (false, 1);
													ChefTalking (true);
													GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [40];
													isSetDialogue = false;
													CurrentIndex = 0;
													IndexCounter = 0;
													if (GameObject.Find ("InventoryBag").GetComponent<Inventory> ().ObjectID < 7) {
															GameObject.Find ("InventoryBag").GetComponent<Inventory> ().AddItemToInventory (1);
															GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().GetFlint = true;
													}
											}

									} 
								}
								else {
										if (IndexCounter == 0) {
												NameDisplay = "Chef Nicon";
												OdysseueTalking (false, 1);
												ChefTalking (true);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [36];
						
										} else if (IndexCounter == 1) {
												NameDisplay = "Odysseus";
												OdysseueTalking (true, 2);
												ChefTalking (false);
												GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().OneLiner [37];
												isSetDialogue = false;
												CurrentIndex = 0;
												IndexCounter = 0;
										}
								}
								break;
						case 23:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										MenTalking (false, 1);
										BeardyTalking (false, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [46];
								} else if (IndexCounter == 2) {
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("LevelProgression").GetComponent<LevelProgress> ().StartSharpenMiniGame = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "SharpenStickMiniGame";
								}
								break;
						case 24:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
					
										NameDisplay = "Damian";
										PersonA (true, 2);
										PersonB (false, 1);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [105];
								} else if (IndexCounter == 1) {
										NameDisplay = "Eleon";
										PersonA (false, 1);
										PersonB (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [106];
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
								}
								break;
						case 25:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
										GameObject.Find ("RamDialogue").transform.position = new Vector3 (1200, GameObject.Find ("RamDialogue").transform.position.y, GameObject.Find ("RamDialogue").transform.position.z);
										GameObject.Find ("RamDialogue").transform.localScale = new Vector3 (-1, 1, 1);
								} else if (IndexCounter == 1) {
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2);
										RamTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [118];

								} else if (IndexCounter == 2) {
										NameDisplay = "Master Ram";
										OdysseueTalking (false, 1);
										RamTalking (true, 2);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [97];
								} else if (IndexCounter == 3) {
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
								}
								break;
						case 26:
								this.enabled = true;
								isSetDialogue = true;
								CurrentIndex = Index;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								if (IndexCounter == 0) {
								} else if (IndexCounter == 1) {
										NameDisplay = "Narration";
										GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [7];
								} else if (IndexCounter == 2) {
										isSetDialogue = false;
										CurrentIndex = 0;
										IndexCounter = 0;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
										GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Cave_Morning_Cyclops";
								}
								break;
						default:
								break;
						}
				} // End of Level 1 Dialogues

		//Level 3 Dialogues
		else if (Level == 3) {
			switch (Index) {
				//Elpenor(Shipdeck)
			case 1:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				
				if (IndexCounter == 0) 
				{
					Debug.Log ("100");
					NameDisplay = "Odysseus";
					ElpenorTalking (false, 2);
					OdysseueTalking(true, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [2];
				}
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Elepnor";
					OdysseueTalking (false, 2); 
					ElpenorTalking (true, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [4];

				}
				
				else if (IndexCounter == 2) 
				{
					NameDisplay = "Odysseus";
					ElpenorTalking (false, 2);
					OdysseueTalking (true,1);
					
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [6];
					ChoiceDialogue_2 = DialogueArray [7];
					ChoiceDialogue_3 = DialogueArray [8];
					isChoice = true;
					isTwoChoice = false;

				}
				
				else if (IndexCounter == 3) 
				{
					NameDisplay = "Elpenor";
					ElpenorTalking (true, 2);
					OdysseueTalking (false,1);
					
					if (ChoiceSelected == 1) 
					{
						IndexCounter = 0;
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [10];
						ElpenorTalking (false, 1);
						
					}	
					else if (ChoiceSelected == 2) 
					{
						IndexCounter = 0;
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [11];
						ElpenorTalking (false, 5);

					}
					else if (ChoiceSelected == 3)
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [12];
						ElpenorTalking (false, 5);

					}
					

					
				}
				
				else if (IndexCounter == 4)
				{
					if(ChoiceSelected == 3)
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 0);
						ElpenorTalking (false, 0);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [14];
					}
					
				}
				else if (IndexCounter == 5)
				{
					if(ChoiceSelected == 3)
					{
						NameDisplay = "Elpenor";
						OdysseueTalking (false, 0);
						ElpenorTalking (true, 0);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [16];
						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
						Activate_Elpenor2 = true;
					}
				}
				break;
				
			// Theban
			case 2:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Theban";
					//ThebanTalking(true);
					ChefTalking(true);
					OdysseueTalking(false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray[19];

				}
				else if (IndexCounter == 1)
				{
					NameDisplay = "Odysseus";
					OdysseueTalking(true, 1);
					ChefTalking(false);
					//ThebanTalking(false);

					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [21];
					ChoiceDialogue_2 = DialogueArray [22];
					ChoiceDialogue_3 = DialogueArray [23];
					isChoice = true;
					isTwoChoice = false;
				}
				else if (IndexCounter == 2)
				{
					if(ChoiceSelected == 1)
					{
						IndexCounter = 0;
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [25];
						ChefTalking (true);
						//ThebanTalking(false);
					}
					else if (ChoiceSelected == 2)
					{
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [26];
						ChefTalking (true);
						OdysseueTalking(false, 1);
						//ThebanTalking(false);
					}
					else if (ChoiceSelected == 3)
					{
						IndexCounter = 0;
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [27];
						ChefTalking (true);
						OdysseueTalking(false, 1);
						//ThebanTalking(false);
					}
				}
				else if (IndexCounter == 3)
				{
					if (ChoiceSelected == 2)
					{
						NameDisplay = "Odysseus";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [29];
						ChefTalking (true);
						//ThebanTalking(false);
					}
				}
				else if (IndexCounter == 4)
				{
					//if (ChoiceSelected == 2)
					//{
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [31];
						ChefTalking (true);
						OdysseueTalking(false, 1);
						//ThebanTalking(false;
						/*isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
						Activate_Elpenor3 = true;*/
					//}
				}
				else if (IndexCounter == 5)
				{
					if (ChoiceSelected == 2)
					{
						NameDisplay = "Odysseus";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
						ChoiceDialogue_1 = DialogueArray [33];
						ChoiceDialogue_2 = DialogueArray [34];
						ChoiceDialogue_3 = DialogueArray [35];
						isChoice = true;
						isTwoChoice = false;
						ChefTalking (false);
						OdysseueTalking(true, 1);
					}
				}
				else if (IndexCounter == 6)
				{

					if(ChoiceSelected == 1)
					{
						Debug.Log (IndexCounter);
						IndexCounter = 0;
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [37];
						ChefTalking (true);
						//ThebanTalking(false);
					}
					else if (ChoiceSelected == 2)
					{
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [38];
						ChefTalking (true);
						OdysseueTalking(false, 1);
						//ThebanTalking(false);
					}
					else if (ChoiceSelected == 3)
					{
						IndexCounter = 0;
						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [39];
						ChefTalking (true);
						OdysseueTalking(false, 1);
						//ThebanTalking(false);
					}
				}
				else if (IndexCounter == 7)
				{
					if (ChoiceSelected == 2)
					{

						NameDisplay = "Theban";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [41];
						ChefTalking (true);
						OdysseueTalking(false, 1);
						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
						Activate_Elpenor3 = true;

					}
				}

				break;
				// mother of odysseus
			case 3:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					ElpenorTalking (false, 2);
					OdysseueTalking(true, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [44];
				}
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Mother";
					OdysseueTalking (false, 2); 
					ElpenorTalking (true, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [46];
				}
				
				else if (IndexCounter == 2) 
				{
					NameDisplay = "Odysseus";
					ElpenorTalking (false, 2);
					OdysseueTalking (true,1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [48];

				}
				
				else if (IndexCounter == 3) 
				{
					NameDisplay = "Mother";
					ElpenorTalking (true, 2);
					OdysseueTalking (false,1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [50];
				
				}

				else if (IndexCounter == 4) 
				{
					NameDisplay = "Odysseus";
					ElpenorTalking (false, 2);
					OdysseueTalking (true,1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [52];
				}

				else if (IndexCounter == 5) 
				{
					NameDisplay = "Mother";
					ElpenorTalking (true, 2);
					OdysseueTalking (false,1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [54];
				}

				else if (IndexCounter == 6) 
				{
					NameDisplay = "Odysseus";
					ElpenorTalking (false, 2);
					OdysseueTalking (true,1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [56];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					//set boolean
					Activate_Elpenor4 = true;
				}


				break;
				// heroes
			case 4:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Elpenor3";
					ElpenorTalking (true, 2);
					OdysseueTalking(false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [2];
				}
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2); 
					ElpenorTalking (false, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [4];
					ChoiceDialogue_2 = DialogueArray [5];
					ChoiceDialogue_3 = DialogueArray [6];
					isChoice = true;
					isTwoChoice = false;
				}
				
				else if (IndexCounter == 2) 
				{
					NameDisplay = "Elpenor3";
					ElpenorTalking (true, 2);
					OdysseueTalking (false,1);
					
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [8];
						OdysseueTalking (false, 1);
						OdysseusPrevExpression_Index = 2;
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [9];
						OdysseueTalking (false, 5);
						OdysseusPrevExpression_Index = 5;
					}
					else if (ChoiceSelected == 3)
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [10];
						OdysseueTalking (false, 5);
						OdysseusPrevExpression_Index = 5;
					}
				}
				
				else if (IndexCounter == 3) 
				{
					ElpenorTalking (false, 0);
					
					NameDisplay = "Odysseus";
					if (ChoiceSelected == 1) 
					{
						IndexCounter = 0;
						OdysseueTalking (true, 8);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [12];				
					} 
					else if (ChoiceSelected == 2) 
					{ 
						IndexCounter = 0;
						OdysseueTalking (true, 6);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [13];
					}
					else if (ChoiceSelected == 3)
					{
						OdysseueTalking (true, 6);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [14];
						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
						//set boolean
						Activate_Elpenor4 = true;
					}
					
				}
				break;

				//Chef(Shipdeck)
			case 22:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0)
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 6);
					ChefTalking(false);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [17];
				}
				else if(IndexCounter == 1)
				{
					NameDisplay = "Chef";
					ChefTalking (true);
					OdysseueTalking (false, 7);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [19];
				}
				else if(IndexCounter == 2)
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					ChefTalking (false);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [21];
					ChoiceDialogue_2 = DialogueArray [22];
					isChoice = true;
					isTwoChoice = true;
				}
				
				else if(IndexCounter == 3)
				{
					NameDisplay = "Chef";
					ChefTalking (true);
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [24];
						OdysseueTalking (false, 5);
						OdysseusPrevExpression_Index = 6;
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [25];
						OdysseueTalking (false, 1);
						OdysseusPrevExpression_Index = 2;
					}
				}
				else if(IndexCounter == 4)
				{
					ChefTalking(false);
					
					NameDisplay = "Odysseus";
					if (ChoiceSelected == 1) 
					{
						OdysseueTalking (true, 4);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [27];
						
					} 
					else if (ChoiceSelected == 2) 
					{
						OdysseueTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [28];
					}
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
				break;
				
			case 24:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Damian";
					PersonA (true, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [30];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Eleon";
					PersonA (false, 1);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [31];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
				break;

			case 25:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (true, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Swag";
					//PersonA (false, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().trickfirstman = true;
				}
				break;

			case 26:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (false, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Yolo";
					//PersonA (true, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().tricksecondman = true;
				}
				break;

			case 27:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (true, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Swag";
					//PersonA (false, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().trickthirdman = true;
				}
				break;

			case 28:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (false, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Yolo";
					//PersonA (true, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().trickfourthman = true;
				}
				break;

			case 29:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (true, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Swag";
					//PersonA (false, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().trickfifthman = true;
				}
				break;

			case 30:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (false, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Yolo";
					//PersonA (true, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().tricksixthman = true;
				}
				break;
			
			case 31:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (true, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Swag";
					//PersonA (false, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().talkfirstman = true;
				}
				break;
				
			case 32:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 5);
					//PersonA (false, 2);
					PersonB (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [59];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Yolo";
					//PersonA (true, 1);
					OdysseueTalking(false, 5);
					PersonB (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression3").GetComponent<LevelProgress3> ().talksecondman = true;
				}
				break;

			default:
				break;
			}
		} // End of Level 3 Dialogues

		//Level 2 Dialogues
			else if (Level == 2) {
						switch (Index) {
				//Elpenor(Shipdeck)
						case 1:
								this.enabled = true;
								isSetDialogue = true;
								GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
								CurrentIndex = Index;


								if (IndexCounter == 0) 
									{
										NameDisplay = "Elpenor";
										ElpenorTalking (true, 2);
										OdysseueTalking(false, 1);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [2];
									}

								else if (IndexCounter == 1) 
									{
										NameDisplay = "Odysseus";
										OdysseueTalking (true, 2); 
										ElpenorTalking (false, 0);
										GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
										ChoiceDialogue_1 = DialogueArray [4];
										ChoiceDialogue_2 = DialogueArray [5];
										ChoiceDialogue_3 = DialogueArray [6];
										isChoice = true;
										isTwoChoice = false;
									}

							else if (IndexCounter == 2) 
						{
							NameDisplay = "Elpenor";
							ElpenorTalking (true, 2);
							OdysseueTalking (false,1);
					
					if (ChoiceSelected == 1) 
						{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [8];
						OdysseueTalking (false, 1);
						OdysseusPrevExpression_Index = 2;
						}	
					else if (ChoiceSelected == 2) 
						{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [9];
						OdysseueTalking (false, 5);
						OdysseusPrevExpression_Index = 5;
						}
					else if (ChoiceSelected == 3)
						{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [10];
						OdysseueTalking (false, 5);
						OdysseusPrevExpression_Index = 5;
						}
					}
	
				else if (IndexCounter == 3) 
				{
					ElpenorTalking (false, 0);

					NameDisplay = "Odysseus";
					if (ChoiceSelected == 1) 
					{
						OdysseueTalking (true, 8);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [12];

					} 
					else if (ChoiceSelected == 2) 
					{
						OdysseueTalking (true, 6);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [13];
					}
					else if (ChoiceSelected == 3)
					{
						OdysseueTalking (true, 6);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [14];
					}
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
				break;
			
				//Chef(Shipdeck)
			case 22:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;

				 if (IndexCounter == 0)
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 6);
                    ChefTalking(false);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [17];
				}
				else if(IndexCounter == 1)
				{
					NameDisplay = "Chef";
					ChefTalking (true);
					OdysseueTalking (false, 7);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [19];
				}
				else if(IndexCounter == 2)
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					ChefTalking (false);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [21];
					ChoiceDialogue_2 = DialogueArray [22];
					isChoice = true;
					isTwoChoice = true;
				}

				else if(IndexCounter == 3)
				{
					NameDisplay = "Chef";
					ChefTalking (true);
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [24];
						OdysseueTalking (false, 5);
						OdysseusPrevExpression_Index = 6;
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [25];
						OdysseueTalking (false, 1);
						OdysseusPrevExpression_Index = 2;
					}
				}
				else if(IndexCounter == 4)
				{
					ChefTalking(false);

					NameDisplay = "Odysseus";
					if (ChoiceSelected == 1) 
					{
						OdysseueTalking (true, 4);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [27];
						
					} 
					else if (ChoiceSelected == 2) 
					{
						OdysseueTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [28];
					}
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
				break;
			
			case 24:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;

					if (IndexCounter == 0) 
					{
						NameDisplay = "Damian";
						PersonA (true, 2);
						PersonB (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [30];
					} 

				else if (IndexCounter == 1) 
				{
						NameDisplay = "Eleon";
						PersonA (false, 1);
						PersonB (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [31];
						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
				}
				break;

				//Chef ending for part 1
			case 25:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;

				CurrentIndex = Index;
				
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					ChefTalking(false);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [34];
				} 
				
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Chef";
					ChefTalking(true);
					OdysseueTalking (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [36];
				}

				else if (IndexCounter == 2) 
				{
					OdysseueTalking(false, 1);
					ChefTalking(false);
					NameDisplay = "Narration";
					GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [1];
				} 
				else if (IndexCounter == 3) 
				{
					NameDisplay = "Narration";
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [2];
				} 
				else if (IndexCounter == 4) 
				{
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Shore_Level2-2";
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
				break;

				//Odysseus and eurylochus at shore part 2
			case 26:
				this.enabled = true;
				isSetDialogue = true;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				CurrentIndex = Index;

				if(GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus == false)
				{
					GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().talkedToOdysseus = true;
				}
				 if (IndexCounter == 0)
				{
					NameDisplay = "Odysseus";
					EurylochusTalking(false, 1);
					OdysseueTalking(true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [40];
				}
			
				else if (IndexCounter == 1)
				{
					NameDisplay = "Eurylochus";
					EurylochusTalking(true, 2);
					OdysseueTalking(false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [42];
					ChoiceDialogue_2 = DialogueArray [43];
					isChoice = true;
					isTwoChoice = true;
				}

				else if (IndexCounter == 2)
				{
					NameDisplay = "Odysseus";
					EurylochusTalking(false, 1);
					OdysseueTalking(true, 2);
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [45];
						OdysseueTalking (true, 11);
						EurylochusTalking(false, 1);
						//OdysseusPrevExpression_Index = 6;
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [46];
						OdysseueTalking (true, 3);
						EurylochusTalking(false, 1);
					}
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				}
				break;

				//Eurylochus & circe at castle front in part 2
			case 27:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if (IndexCounter == 0) {
					GameObject.Find ("CirceDialogue").transform.position = new Vector3 (GameObject.Find ("CirceDialogue").transform.position.x, GameObject.Find ("CirceDialogue").transform.position.y, GameObject.Find ("CirceDialogue").transform.position.z);
					GameObject.Find ("CirceDialogue").transform.localScale = new Vector3 (1, 1, 1);
				} 
				else if (IndexCounter == 1) {
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					CirceTalking (false, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [53];
				} 
				else if (IndexCounter == 2) {
					NameDisplay = "Circe";
					EurylochusTalking (false, 1);
					CirceTalking (true, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [55];
				} 
				else if (IndexCounter == 3) {
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					CirceTalking (false, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [57];
				}
				else if (IndexCounter == 4)
				{
					NameDisplay = "Eurylochus";
					BeardyTalking (false, 1);
					EurylochusTalking (true, 1);
                    GameObject.Find("CirceDialogue").GetComponent<SpriteRenderer>().enabled = false;
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [60];
				}
				else if (IndexCounter == 5)
				{
					NameDisplay = "Crewman";
					BeardyTalking(true, 2);
					EurylochusTalking (false, 1);

					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [62];
				}
				else if (IndexCounter == 6)
				{
					NameDisplay = "Eurylochus";
					BeardyTalking(false, 1);
					EurylochusTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [64];
				}
				else if (IndexCounter == 7) {
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
				break;


				//Eurylochus & circe at castle front in part 2(Ending)
			case 28:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if (IndexCounter == 0) {
					GameObject.Find ("CirceDialogue").transform.position = new Vector3 (GameObject.Find ("CirceDialogue").transform.position.x, GameObject.Find ("CirceDialogue").transform.position.y, GameObject.Find ("CirceDialogue").transform.position.z);
					GameObject.Find ("CirceDialogue").transform.localScale = new Vector3 (1, 1, 1);
				} 
				else if (IndexCounter == 1) {
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					CirceTalking (false, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [67];
				} 
				else if (IndexCounter == 2) {
					NameDisplay = "Circe";
					EurylochusTalking (false, 1);
					CirceTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [69];
				} 
				else if (IndexCounter == 3) {
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					CirceTalking (false, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [71];
					ChoiceDialogue_2 = DialogueArray [72];
					ChoiceDialogue_3 = DialogueArray [73];
					isChoice = true;
					isTwoChoice = false;
				}
				else if (IndexCounter == 4)
					{
						NameDisplay = "Circe";
						CirceTalking (true, 2);
						EurylochusTalking (false,1);
						
						if (ChoiceSelected == 1) 
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [75];
							EurylochusTalking (false, 1);
						}	
						else if (ChoiceSelected == 2) 
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [76];
							EurylochusTalking (false, 5);
						}
						else if (ChoiceSelected == 3)
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [77];
							EurylochusTalking (false, 5);
						}
					}
						else if (IndexCounter == 5)
						{
							GameObject.Find ("BlackScreen").GetComponent<SpriteRenderer> ().enabled = true;
							NameDisplay = "Narration";
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [4];
						}
					else if (IndexCounter == 6)
					{
						NameDisplay = "Narration";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [5];
					}
					else if (IndexCounter == 7)
					{
						NameDisplay = "Narration";
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = GameObject.Find ("DialogueStorage").GetComponent<CSVReader> ().Narration [6];
					}

					else if (IndexCounter == 8) {
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "RunningMiniGame";
					GameObject.Find ("InventoryItem_1").GetComponent<SpriteRenderer>().enabled = false;
				}
				break;

				//Odysseus and Eurylochus at shore part 3
			case 29:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if (IndexCounter == 0) {
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 1);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [81];
				} 
				else if (IndexCounter == 1) {
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					OdysseueTalking (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [83];
				} 
				else if (IndexCounter == 2) {
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 1);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [85];
					ChoiceDialogue_2 = DialogueArray [86];
					ChoiceDialogue_3 = DialogueArray [87];
					isChoice = true;
					isTwoChoice = false;
				}
				else if (IndexCounter == 3)
				{
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					OdysseueTalking (false, 1);
					
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [89];
						EurylochusTalking (true, 2);
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [90];
						EurylochusTalking (true, 2);
					}
					else if (ChoiceSelected == 3)
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [91];
						EurylochusTalking (true, 2);
					}
				}
				else if (IndexCounter == 4)
				{
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 1);
					OdysseueTalking (true, 2);
					
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [93];
						EurylochusTalking (false, 1);
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [94];
						EurylochusTalking (false, 1);
					}
					else if (ChoiceSelected == 3)
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [95];
						EurylochusTalking (false, 1);
					}
				}
				else if (IndexCounter == 5) {
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().talkedToEurylochus = true;
				}
				break;

				//Odysseus and Eurylochus at shore part 3(after opening)
			case 30:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if (IndexCounter == 0) {
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 1);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [98];
				} 
				else if (IndexCounter == 1) {
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					OdysseueTalking (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [100];
				} 
				else if (IndexCounter == 2) {
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 1);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [102];
					ChoiceDialogue_2 = DialogueArray [103];
					isChoice = true;
					isTwoChoice = true;
				}
				else if (IndexCounter == 3)
				{
					NameDisplay = "Eurylochus";
					EurylochusTalking (true, 2);
					OdysseueTalking (false, 1);
					
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [105];
						EurylochusTalking (true, 2);
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [106];
						EurylochusTalking (true, 2);
					}
				}
				else if (IndexCounter == 4)
				{
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 1);
					OdysseueTalking (true, 2);
					
					if (ChoiceSelected == 1) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [108];
						EurylochusTalking (false, 1);
					}	
					else if (ChoiceSelected == 2) 
					{
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [109];
						EurylochusTalking (false, 1);
					}
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}

				break;

				//Odysseus and chef at shore part 3
			case 31:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().sharpenSword == false)
					{
				if (IndexCounter == 0) {
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					ChefTalking (false);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [112];
				} 
				else if (IndexCounter == 1) {
					NameDisplay = "Chef";
					ChefTalking (true);
					OdysseueTalking (false, 1);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [114];
				} 
				else if (IndexCounter == 2) {
					NameDisplay = "Odysseus";
					ChefTalking (false);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [116];
				}
				else if (IndexCounter == 3)
				{
					NameDisplay = "Odysseus";
					ChefTalking (false);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [118];
				}
				else if (IndexCounter == 4)
				{
					NameDisplay = "Odysseus";
					ChefTalking (false);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [120];

					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
				}
					}
				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().sharpenSword == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetVenison == false)
				{
					if (IndexCounter == 0) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						ChefTalking (false);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [123];
						GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(81);
						GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(81);
						GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetVenison = true;

						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;

					}
				}

				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().sharpenSword == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetVenison == true)
				{
					if (IndexCounter == 0) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						ChefTalking (false);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [193];
						
						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
					} 
				}
				break;

				//Odysseus and hermes at clearing part 3
			case 32:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true; 
	
				if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetMoly == false && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().talkedToHermes == false)
				{

				 if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					HermesTalking (false, 0);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [126];
				} 

				else if (IndexCounter == 1) 
				{
						NameDisplay = "Hermes";
						HermesTalking (true, 2);
						OdysseueTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [128];
				}

				else if (IndexCounter == 2) 
				{
					NameDisplay = "Odysseus";
					HermesTalking (false, 1);
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
					ChoiceDialogue_1 = DialogueArray [130];
					ChoiceDialogue_2 = DialogueArray [131];
					isChoice = true;
					isTwoChoice = true;
				}
					
				else if (IndexCounter == 3)
					{
						NameDisplay = "Hermes";
						HermesTalking (true, 2);
						OdysseueTalking (false, 1);
					
					if (ChoiceSelected == 1) 
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [133];
							HermesTalking (true, 2);
						}	
					else if (ChoiceSelected == 2) 
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [134];
							HermesTalking (true, 2);
						}
					}

					else if (IndexCounter == 4)
					{
						NameDisplay = "Hermes";
						HermesTalking (true, 2);
						OdysseueTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [136];
					}
					else if (IndexCounter == 5)
					{
						NameDisplay = "Odysseus";
						HermesTalking (false, 1);
						OdysseueTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [138];
					}
					else if (IndexCounter == 6)
					{
						NameDisplay = "Hermes";
						HermesTalking (true, 2);
						OdysseueTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [140];
					}
					else if (IndexCounter == 7)
					{
						NameDisplay = "Hermes";
						HermesTalking (true, 2);
						OdysseueTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [142];
						GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(82);

					}
					else if (IndexCounter == 8)
					{
						NameDisplay = "Odysseus";
						HermesTalking (false, 1);
						OdysseueTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [144];
						GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().talkedToHermes = true;
						GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetMoly = true;

						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
					}
				}
				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetMoly == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().talkedToHermes == true)
				{
					if (IndexCounter == 0) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						HermesTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [194];
						
						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
					} 
				}
					break;
				//Odysseus and circe at circe's room(First)
			case 33:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWine == false && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().combineMolyWithWine == false)
				{
					if (IndexCounter == 0) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						CirceTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [147];
					}

					else if (IndexCounter == 1) 
					{
						NameDisplay = "Circe";
						OdysseueTalking (false, 1);
						CirceTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [149];
					} 

					else if (IndexCounter == 2) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						CirceTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [151];
					} 
					else if (IndexCounter == 3) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						CirceTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [153];
						//GameObject.Find("InventoryBag").GetComponent<Inventory>().AddItemToInventory(84);
						//GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWine = true;

						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
					}
				}

				//Odysseus and circe at circe's room(before using moly with wine)
				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWine == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().combineMolyWithWine == false)
				{
					if (IndexCounter == 0) 
					{
						NameDisplay = "Circe";
						OdysseueTalking (false, 1);
						CirceTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [156];
					}
					else if (IndexCounter == 1) 
					{
						NameDisplay = "Odysseus";
						CirceTalking (false, 0);
						OdysseueTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = "";
						ChoiceDialogue_1 = DialogueArray [158];
						ChoiceDialogue_2 = DialogueArray [159];
						isChoice = true;
						isTwoChoice = true;
					}
					else if (IndexCounter == 2)
					{
						NameDisplay = "Circe";
						CirceTalking (true, 2);
						OdysseueTalking (false, 1);
						
						if (ChoiceSelected == 1) 
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [161];
							CirceTalking (true, 2);
						}	
						else if (ChoiceSelected == 2) 
						{
							GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [162];
							CirceTalking (true, 2);
						}

						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
					}
				}

				else if(GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().GetWine == true && GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().combineMolyWithWine == true)
				{
					if (IndexCounter == 0) 
					{
						NameDisplay = "Circe";
						OdysseueTalking (false, 1);
						CirceTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [165];
					}
					else if (IndexCounter == 1) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 1);
						CirceTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [167];


						isSetDialogue = false;
						CurrentIndex = 0;
						IndexCounter = 0;
						GameObject.Find("Circe").SetActive(false);
						//Debug.Log ("OI");
						GameObject.Find("CirceEnding").GetComponent<SpriteRenderer>().enabled = true;
						GameObject.Find("Shadow").GetComponent<SpriteRenderer>().enabled = true;
						GameObject.Find("CirceEnd_Collision").tag = "InteractableObject";
					} 
				}
					break;

				//Odysseus and circe at circe's room(last)
			case 34:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
					if (IndexCounter == 0) 
					{
						NameDisplay = "Circe";
						OdysseueTalking (false, 1);
						CirceTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [171];
					}
					else if (IndexCounter == 1) 
					{
						NameDisplay = "Odysseus";
						OdysseueTalking (true, 2);
						CirceTalking (false, 1);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [173];
					}

					else if (IndexCounter == 2) 
					{
						NameDisplay = "Circe";
						OdysseueTalking (false, 1);
						CirceTalking (true, 2);
						GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [175];
						
						GameObject.Find ("LevelProgression2").GetComponent<LevelProgress2> ().swordOnCirce = true;

					} 
					else if(IndexCounter == 3)
					{
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Ship_Deck_Level2";
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;
					}
					break;

				//Shipdeck(Ending of chapt 2)
			case 35:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [178];
				}
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Eurylochus";
					OdysseueTalking (false, 1);
					GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().enabled = false;
					EurylochusTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [180];
				}
				else if (IndexCounter == 2) 
				{
					NameDisplay = "Odysseus";
					EurylochusTalking (false, 0);
					OdysseueTalking (true, 2);
					GameObject.Find("EurylochusDialogue").GetComponent<SpriteRenderer>().enabled = false;
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [182];
				}

				else if (IndexCounter == 3)
				{
					isSetDialogue = false;
					CurrentIndex = 0;
					IndexCounter = 0;


					for (int i = 0; i < 6; i++) {
						
						Destroy (GameObject.Find("InventoryItem_"+(i+1)));
						
					}
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "ArmWrestlingMinigame";

				
				}
				break;

				//Towards the ending cutscene
			case 36:
				this.enabled = true;
				isSetDialogue = true;
				CurrentIndex = Index;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				if (IndexCounter == 0) 
				{
					NameDisplay = "Odysseus";
					OdysseueTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [185];
				}
				else if (IndexCounter == 1) 
				{
					NameDisplay = "Eurylochus";
					OdysseueTalking (false, 1);
					GameObject.Find("OdysseusDialogue").GetComponent<SpriteRenderer>().enabled = false;
					EurylochusTalking (true, 2);
					GameObject.Find ("DialogueBox").GetComponent<DialogueBox> ().Dialogue = DialogueArray [187];
				}
				else if (IndexCounter == 2) 
				{
                    Destroy(GameObject.Find("InventoryBag"));
                    Destroy(GameObject.Find("LevelProgression2"));
					GameObject.Find ("GUITransition").GetComponent<Transition> ().isTransition = true;
					GameObject.Find ("GUITransition").GetComponent<Transition> ().LoadLevel = "Chapter2EndCutscene";
				}
				break;



			

				isSetDialogue = false;
				CurrentIndex = 0;
				IndexCounter = 0;
				GameObject.Find ("DialogueBackground").GetComponent<SpriteRenderer> ().enabled = true;
				break;

			default:
				break;

						}

				}
		}// End of Display Dialogue function

	Rect ScreenRect (float coord_x, float coord_y, float coord_width, float coord_height)
	{
		float f_x, f_y, f_width, f_height;

		f_x = coord_x * Screen.width;
		f_y = coord_y * Screen.height;
		f_width = coord_width * Screen.width;
		f_height = coord_height * Screen.height;

		return new Rect (f_x, f_y, f_width, f_height);
	}
}
