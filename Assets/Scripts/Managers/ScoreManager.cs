﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager> {

	public static int score;

	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}

	public void ResetScore () {
		score = 0;
	}
}
