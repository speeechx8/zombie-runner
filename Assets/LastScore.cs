using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour {

	private int finalScore;
	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		finalScore = ScoreManager.score;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Final score: " + finalScore + "!";
	}
}
