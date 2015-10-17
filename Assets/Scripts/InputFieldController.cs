using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class InputFieldController : MonoBehaviour {
	private string[] commands = new string[] {
		@"^PVT (DRT|GCH) (\d+)DEG$",
		@"^ACT FRQ (BS|HT)$"
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
				HoustonTextController.UpdateText(match.Value);
				return;
			}
		}
		HoustonTextController.UpdateText("ERR // COMMANDE INVALIDE; CONSULTEZ LE MANUEL");
	}
}