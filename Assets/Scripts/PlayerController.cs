using UnityEngine;
using System.Collections;

public class PlayerController : Singleton<PlayerController> {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpForce;

	private Animator anim;
	private Rigidbody2D rb2d;
	private bool grounded; 
	private AudioSource audioSource;
	private SpriteRenderer spriteRenderer;

	public Rigidbody2D RB2D {
		get {
			return rb2d;
		}
		set {
			rb2d = value;
		}
	}
	public bool Grounded {
		get {
			return grounded;
		}
		set {
			grounded = value;
		}
	}
	

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (GameManager.Instance.GameStarted && GameManager.Instance.PlayerActive == false) {
			if (Input.GetAxis("Jump") > 0) {
				GameManager.Instance.PlayerStartedGame();
			}
		}

		if (GameManager.Instance.IsDead) {
			anim.SetBool("Hurt", true);
			GameManager.Instance.PlayerCollided();
		}

		if (GameManager.Instance.GameOver) {
			if (Input.GetAxis("Jump") > 0) {
				GameManager.Instance.LoadFirstLvl();
			}
		}
		if (Input.GetKey("escape")) {
			Application.Quit();
		}
	}

	void FixedUpdate () {
		if (GameManager.Instance.PlayerActive) {
			if (GameManager.Instance.IsMoving) {
				anim.SetBool("isWalking", true);
				rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
			}
			if (!GameManager.Instance.IsMoving) {
				anim.SetBool("isWalking", false);
				rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
			}
			if (grounded) {
				anim.SetBool("Ground", true);
			}
			if (Input.GetAxis("Jump") > 0 && grounded && !GameManager.Instance.GameOver) {
				anim.SetBool("Ground", false);
				rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
				audioSource.PlayOneShot(SoundManager.Instance.Jump);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "InnerWall" && !grounded) {
			GameManager.Instance.IsMoving = false;
		}
		if (col.gameObject.tag == "Coin") {
			audioSource.PlayOneShot(SoundManager.Instance.Coin);
			Destroy(col.gameObject);
			Coin.Instance.AddPoints();
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "InnerWall" && !grounded) {
			GameManager.Instance.IsMoving = false;
		}

		if (col.gameObject.tag == "Hurt") {
			GameManager.Instance.IsMoving = false;
			GameManager.Instance.IsDead = true;
			rb2d.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
			audioSource.PlayOneShot(SoundManager.Instance.Hurt);
		}

		if (col.gameObject.tag == "Exit") {
			if (Input.GetAxis("Jump") > 0) {
				GameManager.Instance.LoadNextScene();
				//GameManager.Instance.TeleportPlayer();
			}
		}
	}
}
