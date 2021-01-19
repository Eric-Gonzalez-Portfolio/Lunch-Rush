using UnityEngine;
using System.Collections;

public class HitAudio : MonoBehaviour {

	public float sound_velocity;

	void OnCollisionEnter2D (Collision2D col) {
		if (col.relativeVelocity.magnitude > sound_velocity)
			transform.GetChild(0).GetComponent<AudioSource> ().Play ();
	}
}
