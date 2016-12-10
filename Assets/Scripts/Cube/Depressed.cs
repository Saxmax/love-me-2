using UnityEngine;

public class Depressed : ICube {

	// State initializing.
	private readonly Cube sm;
	Rigidbody2D rb;
	//BoxCollider2D boxCol;
	//BoxCollider2D triggerCol;
	public Depressed(Cube sm, Rigidbody2D rb, BoxCollider2D boxCol) {
		this.sm = sm;
		this.rb = rb;
		//this.boxCol = boxCol;
	}

	bool gettingHugged = false;

	// State I/O.
	public void EnterState() {
		rb.isKinematic = true; // Turn off unity physics.
		sm.TriggerCollider = true;

		sm.GetComponent<Renderer>().material.color = Color.blue;
	}
	public void LeaveState() {
		sm.TriggerCollider = false;
	}

	// State updates.
	public void UpdateState() {
		// Update
	}
	public void FixedUpdateState() {
		// FixedUpdate
	}

	// State methods.
	public void CollisionEnter(Collision2D col) {
		// Col
	}
	public void TriggerEnter(Collider2D col) {
	}
	public void TriggerExit(Collider2D col) {
	}
	public void MouseClick() {
		if(gettingHugged)
			sm.ChangeState(sm.awake);
	}
}