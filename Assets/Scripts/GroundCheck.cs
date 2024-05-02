using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<PlayerController>();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Ground") {
			player.Grounded = true;
			player.RB2D.velocity = new Vector3(0, 0, 0);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "Ground") {
			player.Grounded = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		player.Grounded = false;
	}
}
