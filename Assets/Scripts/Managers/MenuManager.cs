using UnityEngine; using UnityEngine.UI; using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void Play() {
		LevelManager.LoadLevel(Worlds.Evening, 1);
	}

	public void Quit() {
		Application.Quit();
	}

}