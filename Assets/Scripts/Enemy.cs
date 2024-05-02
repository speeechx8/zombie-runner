using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[HideInInspector] public bool facingRight = false;

	[SerializeField] public Vector3 pos1 = new Vector3(0, 0);
	[SerializeField] public Vector3 pos2 = new Vector3(0, 0);
	[SerializeField] public Vector3 flipPos1 = new Vector3(0, 0);
	[SerializeField] public Vector3 flipPos2 = new Vector3(0, 0);

	public float speed = 1.0f;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.Instance.GameOver) {
			transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
			if (transform.position.x <= flipPos1.x && !facingRight) {
				spriteRenderer.flipX = true;
				facingRight = true;
			}
			else if (transform.position.x >= flipPos2.x && facingRight) {
				spriteRenderer.flipX = false;
				facingRight = false;
			}
		}
	}
}
