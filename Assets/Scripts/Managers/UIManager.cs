using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

	[SerializeField] private Text gameOverTxt;
	[SerializeField] private Text playAgainTxt;
	[SerializeField] private Text nextTxt;
	[SerializeField] private Text playNextTxt;

	

	// Use this for initialization
	void Start () {
		TurnOffGO();
		TurnOffNext();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOnGO () {
		Debug.Log("Turnt on");
		gameOverTxt.enabled = true;
		playAgainTxt.enabled = true;
	}

	public void TurnOffGO () {
		Debug.Log("Turnt off");
		gameOverTxt.enabled = false;
		playAgainTxt.enabled = false;
	}

	public void TurnOnNext () {
		nextTxt.enabled = true;
		playNextTxt.enabled = true;
	}

	public void TurnOffNext () {
		nextTxt.enabled = false;
		playNextTxt.enabled = false;
	}
}
