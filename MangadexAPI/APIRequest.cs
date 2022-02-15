namespace MangadexAPI;

/// <summary>
/// Empfängt eine JSON Datei einer Http anfrage und erstellt daraus ein nutzbares objekt
/// </summary>
public class APIRequest{

	/// <summary>
	/// Resultat der Anfrage
	/// </summary>
	public string      result { get; set; }
	
	/// <summary>
	/// Eine Manga liste von Mangas
	/// </summary>
	public List<Manga> data   { get; set; }
	
	/// <summary>
	/// Ein string token
	/// </summary>
	public Token       token  { get; set; }

	public Statistics? statistics { get; set; }

}