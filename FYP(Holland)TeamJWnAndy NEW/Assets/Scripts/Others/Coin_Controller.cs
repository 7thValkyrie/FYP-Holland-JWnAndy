
using UnityEngine;
using System.Collections;

public class Coin_Controller : MonoBehaviour {
	public int ID;
	private Vector3 targetPosition = new Vector3 (640.0f, 360.0f, 0.0f);
	private Vector3 velocity = new Vector3 (0.0f, 0.0f, 0.0f);
	private float smoothTime = 0.5f;
	public bool CoinMoving;
	private bool Stop;

	// Use this for initialization
	void Start () {
		if (ID != 0) {
            if (GameObject.Find("SaveData").GetComponent<SaveData>().current_Level == 1)
            {
                if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoldenCoin1 == true && ID == 1)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }

                else if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoldenCoin2 == true && ID == 2)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }

                else if (GameObject.Find("LevelProgression").GetComponent<LevelProgress>().GetGoldenCoin3 == true && ID == 3)
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
			else if (GameObject.Find("SaveData").GetComponent<SaveData>().current_Level == 2)
			{
				if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoldenCoin4 == true && ID == 4)
				{
					this.GetComponent<SpriteRenderer>().enabled = false;
				}
				
				else if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoldenCoin5 == true && ID == 5)
				{
					this.GetComponent<SpriteRenderer>().enabled = false;
				}
				
				else if (GameObject.Find("LevelProgression2").GetComponent<LevelProgress2>().GetGoldenCoin6 == true && ID == 6)
				{
					this.GetComponent<SpriteRenderer>().enabled = false;
				}
			}
		}

		CoinMoving = false;
		Stop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && this.transform.localScale.x >= 0.4f && this.transform.localScale.y >= 0.4f && Stop == true) {
			GameObject.Find("GoldenCoin_Glow").GetComponent<SpriteRenderer>().enabled = false;
			this.GetComponent<SpriteRenderer> ().enabled = false;
		}

		if (CoinMoving == true && Stop == false) {
			CoinMove();
			if(GameObject.Find("CoinMovement"))
			{
				GameObject.Find("CoinMovement").GetComponent<Animator>().enabled = false;
			}
		}

	}

	public void CoinMove () {
		this.transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref(velocity), smoothTime);

		if (this.transform.localScale.x < 0.4f && this.transform.localScale.y < 0.4f) {
			this.transform.localScale = new Vector3 ((this.transform.localScale.x) + ((0.4f/smoothTime)*Time.deltaTime), (this.transform.localScale.y) + ((0.4f/smoothTime)*Time.deltaTime), this.transform.localScale.z);
		}
		if (Mathf.Ceil(this.transform.position.x)+5 >= targetPosition.x && Mathf.Ceil(this.transform.position.y)+5 >= targetPosition.y &&
			Mathf.Ceil(this.transform.position.x)-5 <= targetPosition.x && Mathf.Ceil(this.transform.position.y)+5 >= targetPosition.y &&
		    Mathf.Ceil(this.transform.position.x)+5 >= targetPosition.x && Mathf.Ceil(this.transform.position.y)-5 <= targetPosition.y &&
		    Mathf.Ceil(this.transform.position.x)-5 <= targetPosition.x && Mathf.Ceil(this.transform.position.y)-5 <= targetPosition.y) {
			GameObject.Find("GoldenCoin").GetComponent<SpriteRenderer>().color = new Vector4 (1.0f,1.0f,1.0f,1.0f);
			GameObject.Find("GoldenCoin_Glow").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("CoinCounter").GetComponent<CoinCounter>().level1coincount++;
			CoinMoving = false;
			Stop = true;
		}
	}
	
}
