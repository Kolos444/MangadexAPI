namespace MangadexAPI;

/// <summary>
/// Empfängt eine JSON Datei einer Http Token request
/// </summary>
public class Token{
	
	/// <summary>
	/// Der Neue/Aktive Token
	/// </summary>
	public string session { get; set; }
	/// <summary>
	/// Gute Frage
	/// </summary>
	public string refresh { get; set; }
}