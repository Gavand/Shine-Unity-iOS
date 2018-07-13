using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour {

	private bool gyroEnabled;
	private Gyroscope gyro;

	private GameObject cameraController;
	private Quaternion rot;


	private void Start () {
		cameraController = new GameObject("Sphere");
		cameraController.transform.position = transform.position;
		transform.SetParent(cameraController.transform);

		gyroEnabled = EnabledGyro();
	}

	private bool EnabledGyro() {

		if (SystemInfo.supportsGyroscope) {

			gyro = Input.gyro;
			gyro.enabled = true;

			cameraController.transform.rotation = Quaternion.Euler(90f, 90f, 0f);

			rot = new Quaternion(0, 0, 1, 0);

			return true;
		}
		return false;
	}

	// Update is called once per frame
	private void Update () {

		if (gyroEnabled) {
			transform.localRotation = gyro.attitude * rot;
		}

	}
}