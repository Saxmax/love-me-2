﻿using UnityEngine;
using System.Collections;

public class AccelScript : MonoBehaviour {

	void Update () {
		transform.Translate(Input.acceleration.x * Time.deltaTime, 0f,
							-Input.acceleration.z * Time.deltaTime);
	}
}