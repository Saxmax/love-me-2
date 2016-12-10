using UnityEngine.SceneManagement;
public enum Worlds {
	None, // Menu?
	Evening,
	Mountain,
	Desert
};
public static class LevelManager {
	
	private static Worlds currentWorld = Worlds.Evening; // Should only be set when testing.
	private static int currentLevel = 1; // Should only be set when testing.
	private static int levelsPerWorld = 5;

	public static int CurrentLevel {
		get {
			return currentLevel;
		} set {
			// Set level to be 1-5 (including) but if set to 0, set it to 1.
			currentLevel = (value == 0 ? 1 : (value % levelsPerWorld == 0 ? 5 : value % levelsPerWorld));
		}
	}

	public static Worlds CurrentWorld {
		get {
			return currentWorld;
		}
		set {
			currentWorld = value;
		}
	}

	public static void LoadLevel(Worlds world, int level) {
		CurrentWorld = world;
		CurrentLevel = level;
		SceneManager.LoadScene("W" + ((int)CurrentWorld).ToString() + "L" + CurrentLevel.ToString());
	}
}