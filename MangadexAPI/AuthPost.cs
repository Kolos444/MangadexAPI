namespace MangadexAPI;

/// <summary>
/// Bereitet ein objekt für eine Http Request vor die den aktiven Nutzernamen und passwort benutzt
/// </summary>
internal class AuthPost{
	
	/// <summary>
	/// Nutzername des Accounts
	/// </summary>
	public string? username { get; set; }
	
	/// <summary>
	/// Passwort des Accounts
	/// </summary>
	public string? password { get; set; }
}