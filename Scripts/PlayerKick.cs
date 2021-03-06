using UnityEngine;
using System.Collections;

public class PlayerKick : MonoBehaviour {

	public float x_force;
	public float y_force;
	public float rotation_speed;

	private bool just_kicked;
	private int player_no;

	// Use this for initialization
	void Start () {
		just_kicked = false;
		player_no = transform.parent.GetComponent<PlayerControl> ().player_no;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("P" + player_no + " Kick") > 0) {
			if (!just_kicked && !transform.parent.GetComponent<PlayerControl>().movement_locked) {

				//get if the character is facing right from the parent
				bool isFacingRight = transform.parent.GetComponent<PlayerControl> ().isFacingRight;

				//trigger kick animation
				transform.parent.GetComponent<Animator> ().SetTrigger ("kickTrigger");

				//get a list of all nearby objects when attempting to kick
				Collider2D[] kickedObjects = Physics2D.OverlapCircleAll (transform.position, 4.5f);

				//for every object in kickedObjects, test if it is within the hitbox and if it can be kicked
				for (int i = 0; i < kickedObjects.Length; i++) {
					if (kickedObjects [i].GetComponent<Rigidbody2D> () != null && kickedObjects[i].transform.position.y < transform.position.y && kickedObjects [i].tag != "Player") {

						if (isFacingRight) {
							if (kickedObjects [i].transform.position.x > transform.position.x) {
								kickedObjects [i].attachedRigidbody.velocity = new Vector2 (x_force, y_force);
								kickedObjects[i].attachedRigidbody.angularVelocity = rotation_speed;
								PlayKickedSound (kickedObjects[i]);
							}
						}
						else {
							if (kickedObjects [i].transform.position.x < transform.position.x) {
								kickedObjects [i].attachedRigidbody.velocity = new Vector2 (-x_force, y_force);
								kickedObjects[i].attachedRigidbody.angularVelocity = -rotation_speed;
								PlayKickedSound (kickedObjects[i]);
							}
						}
					}
				}
			}
			just_kicked = true;
		} else
			just_kicked = false;
	}

	private void PlayKickedSound (Collider2D objectKicked) {
		objectKicked.gameObject.GetComponent<AudioSource>().Play();
	}
}
