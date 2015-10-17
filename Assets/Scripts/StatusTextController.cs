using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusTextController : MonoBehaviour {

	static private Text textField;

	// Use this for initialization
	void Start () {
		Debug.Log(GetComponent<Text> ().text);
		textField = GetComponent<Text>();
	}
	
	static public void UpdateText (string text) {
		textField.text = text;
	}
}
