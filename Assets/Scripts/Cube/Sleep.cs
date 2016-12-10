using UnityEngine;

public class Sleep : ICube {

	// State initializing.
	private readonly Cube sm;
	Rigidbody2D rb;
	//BoxCollider2D boxCol;
	public Sleep(Cube sm, Rigidbody2D rb, BoxCollider2D boxCol) {
		this.sm = sm;
		this.rb = rb;
		//this.boxCol = boxCol;
	}

	// State I/O.
	public void EnterState() {
		rb.isKinematic = true; // Turn off unity physics and gravity.
		sm.GetComponent<SpriteRenderer>().sprite = sm.spriteSleep;
	}
	public void LeaveState() {
		// Leaving..
	}

	// State updates.
	public void UpdateState() {
	}
	public void FixedUpdateState() {
		// FixedUpdate
	}

	// State methods.
	public void CollisionEnter(Collision2D col) {
	// Col
	} public void TriggerEnter(Collider2D col) {
		// Trigger
	} public void TriggerExit(Collider2D col) {
		//
	}
	public void MouseClick() {
		sm.ChangeState(sm.awake);
	}
}