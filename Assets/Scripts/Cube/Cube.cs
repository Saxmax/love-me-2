using UnityEngine; using System.Collections.Generic;
public enum StartingState {	Awake, Sleep, Depressed };

public partial class Cube : MonoBehaviour {

	// Reference to the interface and states.
	public ICube currentState;
	public Awake awake;
	[HideInInspector] public Sleep sleep;
	[HideInInspector] public Depressed depressed;

	// Components.
	Animator anim;
	Rigidbody2D rb;
	BoxCollider2D boxCol;
	BoxCollider2D triggerCol;

	// Sprites
	public Sprite spriteAwake;
	public Sprite spriteSleep;

	// Other vars.
	public Transform groundCheck;
	public LayerMask groundMask;

	// Allows starting state to be set from the Unity Inspector.
	public StartingState startState;

	void Awake() {
		// Fetch components first for in-data options.
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
		boxCol = (!colliders[0].isTrigger) ? colliders[0] : colliders[1];
		triggerCol = (colliders[1].isTrigger) ? colliders[1] : colliders[0];

		// Initialize states with in-data.
		awake = new Awake(this, rb, boxCol, anim);
		sleep = new Sleep(this, rb, boxCol);
		depressed = new Depressed(this, rb, boxCol);
	}

	void Start() {
		// Temporary:
		if(startState.ToString() == awake.ToString())
			ChangeState(awake);
		else if(startState.ToString() == sleep.ToString())
			ChangeState(sleep);
		else
			ChangeState(depressed);
	}

	// State methods.
	void Update() {
		if(currentState != null)
			currentState.UpdateState();
	}
	void FixedUpdate() {
		if(currentState != null)
			currentState.FixedUpdateState();
	}

	void OnCollisionEnter2D(Collision2D col) {
	  if(currentState != null)
	  currentState.CollisionEnter(col);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(currentState != null)
			currentState.TriggerEnter(col);
	}
	void OnTriggerExit2D(Collider2D col) {
		if(currentState != null)
			currentState.TriggerExit(col);
	}

	void OnMouseDown() {
		if(currentState != null)
			currentState.MouseClick();
	}

	public void ChangeState(ICube toState) {
		if(currentState != null)
			currentState.LeaveState();
		currentState = toState;
		currentState.EnterState();
	}

	public bool TriggerCollider {
		get {
			return triggerCol.enabled;
		} set {
			triggerCol.enabled = value;
		}
	}

	public void FreezeCube() {
		print("hey");
		ChangeState(sleep);
	}
}