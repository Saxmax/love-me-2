using UnityEngine; using System.Collections.Generic;

public class AdvancedCamera : MonoBehaviour {

	// References
	private Transform self;
	[SerializeField] private Transform goal;

	// Vectors
	private Vector2 averagePosition;
	[Range(0f, 2f)] public float freePanSpeedMultiplier = 1f;
	
	// Bounds
	private Bounds bounds;
	float rB;
	float lB;
	float tB;
	float bB;

	// Movement vars
	private bool smoothing = true; // Default to true.
	[SerializeField] private float lerpPercent = .125f;

	void Awake() {
		self = transform;
		
		float vertEx = Camera.main.orthographicSize;
		float horzEx = vertEx * Screen.width / Screen.height;
		bounds = GameObject.Find("Background").transform.GetChild(0).GetComponent<BoxCollider2D>().bounds;

		rB = (bounds.size.x / 2f - horzEx);
		lB = (horzEx - bounds.size.x / 2f);
		tB = (bounds.size.y / 2f - vertEx);
		bB = (vertEx - bounds.size.y / 2f);
	}

	void Update() {
		if(CubeManager.ActiveCubes.Count < 1) {
			FreeToPan();
		} else {
			FollowCubes(CubeManager.ActiveCubes);
		}
	}

	private Vector2 AveragedPosition2(List<GameObject> targets) {
		// If only following one target:
		if(targets.Count == 1) return new Vector2(targets[0].transform.position.x, targets[0].transform.position.y);

		// Else:
		float x = 0f;
		float y = 0f;
		foreach(GameObject target in targets) {
			x += target.transform.position.x;
			y += target.transform.position.y;
		}
		x /= targets.Count;
		y /= targets.Count;
		return new Vector2(x, y);
	}

	private void FollowCubes(List<GameObject> targets) {
		averagePosition = AveragedPosition2(targets);
		Vector3 target = new Vector3(Mathf.Clamp(averagePosition.x, lB, rB), Mathf.Clamp(averagePosition.y, bB, tB), self.position.z);
		self.position = (smoothing ? Vector3.Lerp(self.position, target, lerpPercent) : target);
	}

	private void FreeToPan() {
		Vector3 newPosition = self.position + new Vector3(Input.GetAxis("Horizontal") * freePanSpeedMultiplier, Input.GetAxis("Vertical") * freePanSpeedMultiplier, 0f);
		Vector3 clampedPosition = new Vector3(Mathf.Clamp(newPosition.x, lB, rB), Mathf.Clamp(newPosition.y, bB, tB), self.position.z);
		self.position = Vector3.Lerp(self.position, clampedPosition, lerpPercent);
	}

	public bool IsSmoothing {
		get {
			return smoothing;
		} set {
			smoothing = value;
		}
	}

	public Transform SetGoal {
		set {
			goal = value;
		}
	}

}