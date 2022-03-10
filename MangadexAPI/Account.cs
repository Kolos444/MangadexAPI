namespace MangadexAPI;

/// <summary>
/// Speichert die Daten eines Accounts
/// </summary>
public class Account{
	
	/// <summary>
	/// Nutzername des Accounts
	/// </summary>
	public string? username { get; set; }
	/// <summary>
	/// Passwort des Accounts
	/// </summary>
	public string? password { get; set; }
	/// <summary>
	/// Der derzeitige Token des Accounts
	/// </summary>
	public Token? token { get; set; }


	/// <summary>
	/// Erstell einen Account
	/// </summary>
	/// <param name="username">Nutzername des Accounts als string</param>
	/// <param name="password">Passwort des Accounts als string</param>
	/// <param name="token">Der derzeitige Token des Accounts als string ist optional</param>
	public Account(string? username, string? password, Token? token = null) {
		this.username = username;
		this.password = password;
		this.token    = token;
	}
}