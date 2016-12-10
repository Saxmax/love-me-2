using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			// Player died.
			CubeManager.ResetCubes();
			LevelManager.LoadLevel(LevelManager.CurrentWorld, LevelManager.CurrentLevel);
		}
	}
}