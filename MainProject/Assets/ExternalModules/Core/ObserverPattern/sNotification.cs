//
// Script name: sNotification.cs
//
//
// Programmer: Kentaurus
//

public class sNotification
{
	public string key;
	public object[] args;

	public sNotification(string key, params object[] param)
	{
		this.key = key;
		args = param;
	}
}