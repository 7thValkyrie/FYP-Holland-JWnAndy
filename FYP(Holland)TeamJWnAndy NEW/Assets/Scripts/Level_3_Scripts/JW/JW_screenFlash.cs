using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class JW_screenFlash : MonoBehaviour
{
	public float alphaValue;
	public Image takingDmg;
	float rektStay;
	// Use this for initialization
	void Start () {
		alphaValue = 1;
		rektStay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		takingDmg.color = new Color(1, 1, 1,alphaValue);
		if (gameObject.activeSelf == true)
		{
			rektStay += Time.deltaTime;
			alphaValue =  Mathf.Lerp(alphaValue, 0,Time.deltaTime);
			if (rektStay > 1)
			{
				rektStay = 0;
				alphaValue = 1;
				gameObject.SetActive(false);
				
			}


		}


			
			
		
	}
}
