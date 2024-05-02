using UnityEngine;
using System.Collections;

public class ExitPoint : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GameManager.Instance.IsMoving = false;
			GameManager.Instance.TurnOnNext();
		}
	}
}
