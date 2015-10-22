using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class InputFieldController : MonoBehaviour {
	private Command[] commands = new Command[] {
		new Command(@"^PVT (D|G) (\d+)DEG$",  "Pivoté à %$1 de $2 degrés", new string[,] { {"%D", "droite"}, {"%G", "gauche"} } ),
		new Command(@"^AB LEV-([A-Z])(\d+)$", "Levier $1$2 abaissé"),
		new Command(@"ACT PYR",               "Système pyrotechnique activé")
	};

	private InputField inputField;

	void Start () {
		inputField = gameObject.GetComponent<InputField>();
		inputField.onEndEdit.AddListener(RespondToText);
	}
	
	private void RespondToText(string text) {
		foreach (Command command in commands) {
      if (command.Execute(text)) {
				StatusTextController.UpdateText(command.successMessage.ToUpper());
				return;
      }
		}
		StatusTextController.UpdateText("ERR // COMMANDE INVALIDE; CONSULTEZ LE MANUEL");
	}
}