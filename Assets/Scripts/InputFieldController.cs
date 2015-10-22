using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class InputFieldController : MonoBehaviour {
	private Command[] commands = new Command[] {
		new Command(@"^PVT (D|G) (\d+)DEG$",  "trop cool ton message"),
		new Command(@"^AB LEV-([A-Z])(\d+)$", "jcapote littéralement"),
		new Command(@"ACT PYR",               "pyrrrooooootechnie")
	};

	private InputField inputField;

	void Start () {
		inputField = gameObject.GetComponent<InputField>();
		inputField.onEndEdit.AddListener(RespondToText);
//		houstonText = GetComponent<Text>();
	}
	
	private void RespondToText(string text) {
		foreach (Command command in commands) {
			Regex regex = new Regex(command.regex);
			Match match = regex.Match(text);
			if (match.Success) {
				StatusTextController.UpdateText(command.successMessage);
				return;
			}
		}
		StatusTextController.UpdateText("ERR // COMMANDE INVALIDE; CONSULTEZ LE MANUEL");
	}
}