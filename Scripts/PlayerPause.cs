using UnityEngine;
using System.Collections;

public class PlayerPause : PauseScript {

	public override void Pause(bool isPaused) {
		GetComponent<PlayerControl> ().pause_locked = isPaused;
	}
}
