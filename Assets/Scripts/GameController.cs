using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject camera;

	private float target = 0;

	public void Start() {
		target = camera.transform.eulerAngles.y;
	}

	public void LateUpdate() {
		bool left = Input.GetButtonDown("Left"), right = Input.GetButtonDown("Right");

		if(left && !right) target -= 90;
		if(right && !left) target += 90;

		camera.transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(camera.transform.eulerAngles.y, target, 0.25f), 0);
	}
}
