using UnityEngine;
using System.Collections;

public partial class Cube : MonoBehaviour {

	public void Press(float x) {
		awake.mobileSpeed = Mathf.Clamp(x, -1f, 1f);
	}

	public void Release() {
		awake.mobileSpeed = 0f;
	}

	public void Jump() {
		if(awake.grounded) {
			anim.SetBool("Grounded", false);
			rb.AddForce(new Vector2(0f, awake.jumpForce));
		}
	}
}