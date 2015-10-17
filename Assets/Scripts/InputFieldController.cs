using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class InputFieldController : MonoBehaviour {
	private string[] commands = new string[] {
		@"^PVT (D|G) (\d+)DEG$",
		@"^AB LEV-([A-Z])(\d+)$",
		@"ACT PYR"
	};

	private InputField inputField;

	void Start () {
		inputField = gameObject.GetComponent<InputField>();
		inputField.onEndEdit.AddListener(RespondToText);
//		houstonText = GetComponent<Text>();
	}
	
	private void RespondToText(string text) {
		foreach (string command in commands) {
			Regex regex = new Regex(command);
			Match match = regex.Match(text);
			if (match.Success) {
				StatusTextController.UpdateText(match.Value);
				return;
			}
		}
		StatusTextController.UpdateText("ERR // COMMANDE INVALIDE; CONSULTEZ LE MANUEL");
	}
}