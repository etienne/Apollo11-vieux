using System.Text.RegularExpressions;

public class Command {
	public string pattern;
	public string rawSuccessMessage;
  public string[,] substitutions;
  public Match match;
  public string successMessage;
  
  public Command(string pattern, string rawSuccessMessage) {
		this.pattern = pattern;
		this.rawSuccessMessage = rawSuccessMessage;
  }
  
	public Command(string pattern, string rawSuccessMessage, string[,] substitutions) {
    // FIXME: Répétition de code
		this.pattern = pattern;
		this.rawSuccessMessage = rawSuccessMessage;
    this.substitutions = substitutions;
	}
  
  public bool Execute(string input) {
    match = Regex.Match(input, pattern);
    if (match.Success) {
      successMessage = match.Result(rawSuccessMessage);
      if (substitutions != null && substitutions.Length > 0) {
        for (int i = 0; i < substitutions.GetLength(0); i += 1) {
          successMessage = successMessage.Replace(substitutions[i, 0], substitutions[i, 1]);
        }
      }
      return true;
    } else {
      return false;
    }
  }
}
