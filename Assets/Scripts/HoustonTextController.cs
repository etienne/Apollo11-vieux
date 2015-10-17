using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoustonTextController : MonoBehaviour {

	static private Text textField;
	private int currentStage;

	// Use this for initialization
	void Start () {
		textField = gameObject.GetComponent<Text>();
		currentStage = 0;
	}
	
	static public void UpdateText (string text) {
		textField.text = text;
	}

	void Update() {
		if (Time.time > 4 && currentStage == 0) {
			UpdateText("Columbia, Houston. Nous les avons perdus à cause des hautes fréquences. Nous recommandons qu’ils pivotent à droite de dix degrés. Pouvez-vous leur transmettre nos directives?");
			currentStage = 1;
		}

		if (Time.time > 12 && currentStage == 1) {
			UpdateText("Abaissez le levier B72 pour procéder à l’arrimage des deux vaisseaux.");
			currentStage = 2;
		}

		if (Time.time > 20 && currentStage == 2) {
			UpdateText("Activez le système pyrotechnique.");
			currentStage = 3;
		}
	}
}
