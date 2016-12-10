using UnityEngine; using System.Collections.Generic;

public class InputManager : MonoBehaviour {
	/*
		Inputs for:
			- Pinch-to-zoom (Mobile)
			- Drag-to-pan (Mobile)
	*/

	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
			CubeManager.FreezeAllCubes();
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}