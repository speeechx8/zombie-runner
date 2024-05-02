using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	[SerializeField] private Text gameOverTxt;
	[SerializeField] private Text playAgainTxt;
	[SerializeField] private Text nextTxt;
	[SerializeField] private Text playNextTxt;
	[SerializeField] private Text score;
	[SerializeField] private Text play;
	[SerializeField] private Image title;

	private static bool playerActive;
	private static bool gameOver;
	private static bool gameStarted;
	private bool isMoving;
	private bool grounded;
	private bool isDead;
	private bool lastScene;

	public bool LastScene {
		get {
			return lastScene;
		}
	}
	public bool GameStarted {
		get {
			return gameStarted;
		}
	}
	public bool PlayerActive {
		get {
			return playerActive;
		}
	}
	public bool GameOver {
		get {
			return gameOver;
		}
	}
	public bool IsMoving {
		get {
			return isMoving;
		}
		set {
			isMoving = value;
		}
	}
	public bool IsDead {
		get {
			return isDead;
		}
		set {
			isDead = value;
		}
	}


	void Start () {
		TurnOffGO();
		TurnOffNext();
		TurnOffScore();

		gameStarted = true;
		isMoving = false;

		if (playerActive == false && SceneManager.GetActiveScene().buildIndex != (0)) {
			SceneManager.LoadScene(0);
		}
	}
	
	void Update () {
		
	}

	//UI Controls
	public void TurnOnGO () {
		Debug.Log("Game over turnt on");
		gameOverTxt.enabled = true;
		playAgainTxt.enabled = true;
	}
	public void TurnOffGO () {
		Debug.Log("Game over turnt off");
		gameOverTxt.enabled = false;
		playAgainTxt.enabled = false;
	}
	public void TurnOnNext () {
		Debug.Log("Next turnt on");
		nextTxt.enabled = true;
		playNextTxt.enabled = true;
	}
	public void TurnOffNext () {
		Debug.Log("Next turnt off");
		nextTxt.enabled = false;
		playNextTxt.enabled = false;
	}
	public void TurnOnScore () {
		Debug.Log("Score turnt on");
		score.enabled = true;
	}
	public void TurnOffScore () {
		Debug.Log("Score turnt off");
		score.enabled = false;
	}
	public void TurnOffMenu () {
		Debug.Log("Menu turnt off");
		title.enabled = false;
		play.enabled = false;
	}

	//Player Controls
	public void PlayerStartedGame() {
		LoadFirstLvl();
		TurnOffMenu();
		TurnOffGO();
		TurnOnScore();
		playerActive = true;
		Debug.Log("Player active");
		isMoving = true;
	}
	public void PlayerCollided() {
		TurnOnGO();
		gameOver = true;
		Debug.Log("Game over!");
	}

	//Scene Controls
	public void LoadFirstLvl() {
		SceneManager.LoadScene(1);
		ScoreManager.Instance.ResetScore();
		gameOver = false;
		isDead = false;
		isMoving = true;
		TurnOffGO();
		TurnOffNext();
	}
	public void LoadNextScene () {
		for (int i = SceneManager.GetActiveScene().buildIndex; i <= 3; i++) {
			Debug.Log ("Scene is " + SceneManager.GetActiveScene().buildIndex);
			SceneManager.LoadScene(i += 1);
			Debug.Log ("Scene loaded");
		}
		Debug.Log ("Scene is now " + SceneManager.GetActiveScene().buildIndex);
		if (SceneManager.GetActiveScene().buildIndex == 2) {
			lastScene = true;
			Debug.Log("On last scene");
			TurnOffScore();
		}

		TurnOffNext();
		isMoving = true;
	}
}
