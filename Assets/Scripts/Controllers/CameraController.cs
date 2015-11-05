using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	void Start() {
		Screen.SetResolution(1920, 1080, false);
	}

	void LateUpdate () {
		if(Camera.current != null) {
			Camera.current.transform.Translate(new Vector3(0.0f, 0.0f, 0.001f));
			Camera.current.transform.position = new Vector3(
				Camera.current.transform.position.x, 
				Camera.current.transform.position.y, 
				Mathf.Clamp(Camera.current.transform.position.z, -8.0f, -0.12f)
			);
		}
	}

}
