using UnityEngine;

public class Awake : ICube {

	// State initializing.
	private readonly Cube sm;
	Rigidbody2D rb;
	//BoxCollider2D boxCol;
	Animator anim;
	public Awake(Cube sm, Rigidbody2D rb, BoxCollider2D boxCol, Animator anim) {
		this.sm = sm;
		this.rb = rb;
		//this.boxCol = boxCol;
		this.anim = anim;
	}

	// Vars.
	public bool grounded;
	float groundRadius = .2f;
	public float jumpForce = 500f;
	float maxSpeed = 8;
	public float mobileSpeed = 0f;

	// State I/O.
	public void EnterState() {
		CubeManager.Add = sm.gameObject;
		sm.gameObject.layer = LayerMask.NameToLayer("Player");
		rb.isKinematic = false; // Let Unity Physics handle things.
		sm.GetComponent<SpriteRenderer>().sprite = sm.spriteAwake;
	}
	public void LeaveState() {
		CubeManager.Remove = sm.gameObject;
		sm.gameObject.layer = LayerMask.NameToLayer("Ground");
	}

	// State updates.
	public void UpdateState() {
		if(grounded && Input.GetKeyDown(KeyCode.Space)) {
			anim.SetBool("Grounded", false);
			rb.AddForce(new Vector2(0f, jumpForce));
		}
	}
	public void FixedUpdateState() {
		// Check if grounded or not.
		grounded = Physics2D.OverlapCircle(sm.groundCheck.position, groundRadius, sm.groundMask);
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("vSpeed", rb.velocity.y);

		// Move using either mobile input (ui buttons) or horizontal axis.
		float moveSpeed = (mobileSpeed == 0 ? Input.GetAxis("Horizontal") : mobileSpeed);
		anim.SetFloat("Speed", moveSpeed);
		rb.velocity = new Vector2(moveSpeed * maxSpeed, rb.velocity.y);
	}

	// State methods.
	public void CollisionEnter(Collision2D col) {
	} public void TriggerEnter(Collider2D col) {
		// Trigger
	} public void TriggerExit(Collider2D col) {
		//
	}
	public void MouseClick() {
		sm.ChangeState(sm.sleep);
	}
}