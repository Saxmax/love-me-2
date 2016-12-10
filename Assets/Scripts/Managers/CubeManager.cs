using UnityEngine; using System.Collections.Generic;

public sealed class CubeManager {
	private static CubeManager instance = new CubeManager();
	private CubeManager() {}
	public static CubeManager GetInstance() {
		return instance;
	}

	private static List<GameObject> activeCubes = new List<GameObject>();

	public static void FreezeAllCubes() {
		List<GameObject> copyOfCubes = new List<GameObject>(ActiveCubes); // Copy it first.
		foreach(GameObject cube in copyOfCubes) {
			cube.GetComponent<Cube>().FreezeCube();
		}
	}

	public static List<GameObject> ActiveCubes {
		get {
			return activeCubes;
		}
	}

	public static GameObject Add {
		set {
			activeCubes.Add(value);
		}
	}

	public static GameObject Remove {
		set {
			activeCubes.Remove(value);
		}
	}

	public static void ResetCubes() {
		activeCubes = new List<GameObject>();
	}
}