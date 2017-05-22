using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jump;

	public void FixedUpdate() {
		GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.right * Input.GetAxis("Horizontal") * speed);

		if(Input.GetButtonDown("Jump")) {
			GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
		}
	}
}
