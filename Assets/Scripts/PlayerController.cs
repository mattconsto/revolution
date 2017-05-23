using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jump;

	private Rigidbody _rb;

	public void Start() {
		_rb = GetComponent<Rigidbody>();
	}

	public void FixedUpdate() {
		// Movement
		_rb.MovePosition(transform.position + Vector3.right * Input.GetAxis("Horizontal") * speed);
		if(Input.GetButtonDown("Jump")) _rb.AddForce(Vector3.up * jump);

		// Keep player at forefront
		RaycastHit hito, hit1, hit2, hit3;
		if( // If the player is not occulded
			Physics.Raycast(new Vector3(transform.position.x, transform.position.y, -100), Vector3.forward, out hito) &&
			hito.collider.gameObject == gameObject && 
			// And there is a platform either side
			(Physics.Raycast(new Vector3(transform.position.x - 2, transform.position.y - 2, -100), Vector3.forward, out hit1) | // Non short circuiting
			Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 2, -100), Vector3.forward, out hit2) |
			Physics.Raycast(new Vector3(transform.position.x + 2, transform.position.y - 2, -100), Vector3.forward, out hit3))
		) {
			transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Min(new float[] {hit1.point.z, hit2.point.z, hit3.point.z}) + 5);
			_rb.useGravity = !(hit1.collider != null && hit2.collider != null && hit3.collider != null);
		} else {
			_rb.useGravity = true;
		}
	}
}
