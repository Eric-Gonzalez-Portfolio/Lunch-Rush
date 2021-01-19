using UnityEngine;
using System.Collections;

public class FallDetector : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D collision) {
		transform.parent.gameObject.GetComponent<PlayerControl> ().BodyCollide (collision);
	}
}
