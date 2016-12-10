using UnityEngine; using System.Collections;

public class Parallax : MonoBehaviour {

	[Tooltip("This needs to be set manually depending on how far back the mid background is.")]
	public float midYOffset = 1f;
	public float effectSmoothing = 10f;
	private Transform[] backgrounds;
	private float[] modifiers;
	private Vector3 prevCamPos;
	private Transform pos;

	void Awake() {
		backgrounds = new Transform[3];
		GameObject bg = GameObject.Find("Background");
		for(int i = 0; i < backgrounds.Length; i++) {
			backgrounds[i] = bg.transform.GetChild(i).transform;
		}
	}

	void Start() {
		backgrounds[1].position += new Vector3(0f, midYOffset, 0f);
		pos = transform;
		prevCamPos = pos.position;
		modifiers = new float[backgrounds.Length];
		for(int i = 0; i < backgrounds.Length; i++) {
			modifiers[i] = backgrounds[i].position.z * -1;
		}
	}

	void LateUpdate() {
		for(int i = 0; i < backgrounds.Length; i++) {
			Vector3 effect = (prevCamPos - transform.position) * (modifiers[i] / effectSmoothing);
			backgrounds[i].position = new Vector3(backgrounds[i].position.x + effect.x, backgrounds[i].position.y + effect.y, backgrounds[i].position.z);
		}
		prevCamPos = pos.position;
	}
}