using UnityEngine; using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour {

	public Worlds worldToLoad;
	public int levelToLoad;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Player") {
			StartCoroutine(RestartLevel());
		}
	}

	IEnumerator RestartLevel() {;
		float time2Wait = 1.5f;
		yield return new WaitForSeconds(time2Wait);
		CubeManager.ResetCubes();
		LevelManager.LoadLevel(worldToLoad, levelToLoad);
	}
}
