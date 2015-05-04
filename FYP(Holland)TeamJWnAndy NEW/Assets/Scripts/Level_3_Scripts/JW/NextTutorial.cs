using UnityEngine;
using System.Collections;

public class NextTutorial : MonoBehaviour {
	private int nextTut;
	public GameObject TextPart_1;
	public GameObject ObjectPart_1;
	public GameObject TextPart_2;
	public GameObject ObjectPart_2;
	public GameObject PreviousBtnTutorial;
	// Use this for initialization
	void Start () {
		nextTut = 1;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void nextTutorial(int n)
	{
		nextTut += n;
		if(nextTut == 1)
		{
			nextTut = 1;
			TextPart_1.SetActive(true);
			ObjectPart_1.SetActive(true);
			TextPart_2.SetActive(false);
			ObjectPart_2.SetActive(false);
		}
		if(nextTut == 2)
		{

			TextPart_1.SetActive(false);
			ObjectPart_1.SetActive(false);
			TextPart_2.SetActive(true);
			ObjectPart_2.SetActive(true);
			PreviousBtnTutorial.SetActive(true);
		}
		if(nextTut == 3)
		{
			Application.LoadLevel("minigame_fendoffghost");

		}

	}
}
