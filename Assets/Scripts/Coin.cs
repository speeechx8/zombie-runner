using UnityEngine;
using System.Collections;

public class Coin : Singleton<Coin> {

	[SerializeField] private int points;
	
	public int Points {
		get {
			return points;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints () {
		ScoreManager.score += points;
	}
}
