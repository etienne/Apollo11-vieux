using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusTextController : MonoBehaviour {

	static private Text textField;

	// Use this for initialization
	void Start () {
		textField = GetComponent<Text>();
		Debug.Log (textField.text);
	}
	
	static public void UpdateText (string text) {
		Debug.Log (textField.text);
		textField.text = text;
	}
}
