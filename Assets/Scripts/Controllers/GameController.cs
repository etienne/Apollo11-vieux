using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
  static public Node currentNode;
  static private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
  
  static public void SwitchToNode(string name) {
    currentNode = nodes[name];
    currentNode.Execute();
  }
  
  public void AddNode(Node node) {
    nodes[node.name] = node;
  }
  
  static public void RespondToText(string text) {
    currentNode.RespondToText(text);
  }
  
	void Start () {
    this.AddNode(new Node("directive1", "Columbia, Houston. Nous les avons perdus à cause des hautes fréquences. Nous recommandons qu’ils pivotent à droite de dix degrés. Pouvez-vous leur transmettre nos directives?", "PVT D 12DEG", "directive2"));
    this.AddNode(new Node("directive2", "Abaissez le levier B72 pour procéder à l’arrimage des deux vaisseaux.", "AB LEV-B72", "directive3"));
    this.AddNode(new Node("directive3", "Activez le système pyrotechnique.", "ACT PYR", "directive1"));
	}
	
	void Update () {
    if (currentNode == null) {
      this.SwitchToNode("directive1");
    }
	}
}
