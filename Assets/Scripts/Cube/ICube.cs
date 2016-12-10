public interface ICube {
	void EnterState();
	void LeaveState();
	void UpdateState();
	void FixedUpdateState();
	void CollisionEnter(UnityEngine.Collision2D col);
	void TriggerEnter(UnityEngine.Collider2D col);
	void TriggerExit(UnityEngine.Collider2D col);
	void MouseClick();
}