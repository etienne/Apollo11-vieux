public class Node {
	public string name;
  public string message;
  public string correctCommand;
  public string nextNode;
  
  public Node(string name, string message, string correctCommand, string nextNode) {
    this.name = name;
    this.message = message;
    this.correctCommand = correctCommand;
    this.nextNode = nextNode;
  }
  
  public void Execute() {
    HoustonTextController.UpdateText(this.message);
  }
  
  public void RespondToText(string text) {
    if (this.correctCommand == text) {
      GameController.SwitchToNode(nextNode);
    } else {
      HoustonTextController.UpdateText("Columbia, y a-t-il un problème? Nous répétons. " + this.message);
    }
  }
}
