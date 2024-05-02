using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager> {

	[SerializeField] private AudioClip jump;
	[SerializeField] private AudioClip hurt;
	[SerializeField] private AudioClip coin;
	[SerializeField] private AudioClip level;

	public AudioClip Jump {
		get {
			return jump;
		}
	}
	public AudioClip Hurt {
		get {
			return hurt;
		}
	}
	public AudioClip Coin {
		get {
			return coin;
		}
	}
	public AudioClip Level {
		get {
			return level;
		}
	}
}
