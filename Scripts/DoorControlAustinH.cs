using UnityEngine;
using System.Collections;

public class DoorControlAustinH : MonoBehaviour {

	public float toggle_time;

	private Collider2D door_collider;
	private float prev_time;
	private MeshRenderer render;

	// Use this for initialization
	void Start () {
		door_collider = GetComponent<Collider2D> ();
		door_collider.enabled = true;
		render = GetComponent<MeshRenderer> ();
		render.enabled = true;

		prev_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - prev_time > toggle_time) {
			door_collider.enabled = !door_collider.enabled;
			render.enabled = !render.enabled;
			prev_time = Time.time;
		}
	}
}
