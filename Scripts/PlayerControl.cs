using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public float jump_force;
	public float grounded_distance;
	public float max_velocity;
	public float flip_margin;
	public float hurt_speed;
	public float fall_time;

    //public GameObject groundChecker;
    //for anim speed
    public float start_velocity;
    public float run_anim_multiplier;
    public float max_anim_speed;

    public int player_no;

	[HideInInspector] public bool movement_locked;
	[HideInInspector] public bool isFacingRight = true;
	[HideInInspector] public bool pause_locked;

	private Rigidbody2D rb;
	private bool just_jumped;
	private float movement_locked_time;

    Animator anim_state;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		just_jumped = false;
		movement_locked = false;
		Physics2D.IgnoreLayerCollision (8, 8);
        anim_state = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause_locked) {
			float moveHorizontal = Input.GetAxis ("P" + player_no + " Horizontal");


			Vector2 movement = new Vector2 (moveHorizontal, 0.0f);
			Vector2 jump = new Vector2 (0.0f, jump_force);

			if (!movement_locked) {
				if (moveHorizontal < 0.0f && rb.velocity.x > -start_velocity)        //add start velocity on beginning movement
	                rb.velocity = new Vector2 (-start_velocity, rb.velocity.y);
				else if (moveHorizontal > 0.0f && rb.velocity.x < start_velocity)
					rb.velocity = new Vector2 (start_velocity, rb.velocity.y);
				rb.AddForce (movement * speed);
			} else if (Time.time - movement_locked_time >= fall_time)
				movement_locked = false;

			RaycastHit2D[] hits = new RaycastHit2D[8];
			int num_hits = transform.GetChild (2).GetComponent<Collider2D> ().Raycast (Vector2.down, hits, grounded_distance);

			bool hit_ground = false;

			for (int i = 1; i < hits.Length; i++) {
				if (hits [i].transform != null)
				if (hits [i].transform.gameObject.tag == "Floor" || hits [i].transform.gameObject.tag == "Obstacle")
					hit_ground = true;
			}

			if (Input.GetAxis ("P" + player_no + " Jump") > 0) {
				if (num_hits > 1 && !just_jumped && !movement_locked) {
					if (hit_ground) {
						rb.AddForce (jump, ForceMode2D.Impulse);
						just_jumped = true;
					}
				}
			} else
				just_jumped = false;

			//if velocity goes past max_velocity then set it to max_velocity
			/*
	        if (rb.velocity.x > max_velocity) rb.velocity = new Vector2(max_velocity, rb.velocity.y);
			if (rb.velocity.x < -max_velocity)
				rb.velocity = new Vector2 (-max_velocity, rb.velocity.y);

			//animation control
			if (hit_ground)
			{
				GetComponent<Animator>().SetBool("inAir", false);
			}
			else
			{
				GetComponent<Animator>().SetBool("inAir", true);
			}


			GetComponent<Animator> ().SetFloat ("CharacterSpeed", Math.Abs(GetComponent<Rigidbody2D> ().velocity.x));

			if (GetComponent<Rigidbody2D> ().velocity.x < -flip_margin & isFacingRight)
			{
				Flip ();
			}
			else if (GetComponent<Rigidbody2D> ().velocity.x > flip_margin & isFacingRight == false)
				Flip ();
		}
	        */
			rb.velocity = new Vector2 (Mathf.Clamp (rb.velocity.x, -max_velocity, max_velocity), rb.velocity.y);

			if (hit_ground) {
				GetComponent<Animator> ().SetBool ("inAir", false);
			} else {
				GetComponent<Animator> ().SetBool ("inAir", true);
			}


			GetComponent<Animator> ().SetFloat ("CharacterSpeed", Math.Abs (GetComponent<Rigidbody2D> ().velocity.x));
			//Austin R.'s code for making anim speed match velocity of movement
			GetComponent<Animator> ().SetFloat ("AnimSpeed", Mathf.Clamp (run_anim_multiplier * Math.Abs (GetComponent<Rigidbody2D> ().velocity.x), 0.0f, max_anim_speed));

			if (GetComponent<Rigidbody2D> ().velocity.x < -flip_margin & isFacingRight) {
				Flip ();
			} else if (GetComponent<Rigidbody2D> ().velocity.x > flip_margin & isFacingRight == false)
				Flip ();
		}
    }



	private void Flip()
	{
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		isFacingRight = !isFacingRight;
	}

	public void BodyCollide(Collision2D collision) {

		if (collision.gameObject.tag != "Floor" && collision.gameObject.tag != "Player") {
			if (Math.Abs(collision.relativeVelocity.x) > hurt_speed) {
				rb.velocity = Vector2.zero;
				movement_locked = true;
				movement_locked_time = Time.time;
				//mine
				//anim_state.SetBool("fallTrigger", true);
				if (collision.relativeVelocity.x >= 0 && isFacingRight || collision.relativeVelocity.x <= 0 && !isFacingRight) {
					Debug.Log ("Falling backwards");
					anim_state.SetTrigger ("fallBackTrigger");
				}
				else if (collision.relativeVelocity.x < 0 && isFacingRight || collision.relativeVelocity.x > 0 && !isFacingRight)
					anim_state.SetTrigger ("fallTrigger");

				//rb.isKinematic = true;
				//StartCoroutine(yield return new WaitForSeconds (fall_time);
				//rb.isKinematic = false;
			}
		}

		Debug.Log ("Collided with " + collision.gameObject.tag);
    }
}
