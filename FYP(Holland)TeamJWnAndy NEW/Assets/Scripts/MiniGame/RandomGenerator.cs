using UnityEngine;
using System.Collections;

public class RandomGenerator : MonoBehaviour {
	public int random_value;
	public bool over;
	// Use this for initialization
	void Start () {
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CalculateRandom () {
		if (GameObject.Find ("Player").GetComponent<Player>().ScorePoint == 5 || GameObject.Find ("Player2").GetComponent<Player>().ScorePoint == 5 || GameObject.Find ("Player3").GetComponent<Player>().ScorePoint == 5)
			over = true;

		random_value = Random.Range(1,4);
	}
}
