using UnityEngine;
using System.Collections;

public class MoonController : MonoBehaviour {

	void FixedUpdate () {
	  transform.Translate(new Vector3(0.0f, -0.02f, 0.0f));
	}
}
