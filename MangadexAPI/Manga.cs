using System.Diagnostics.CodeAnalysis;

namespace MangadexAPI;

/// <summary>
/// Ein Manga objekt zum empfanen einer JSON Datei der Mangadex API
/// </summary>
public class Manga{
	
	/// <summary>
	/// Die einzigartige Identifikations Nummer des Mangas
	/// </summary>
	public string id { get; set; }
	/// <summary>
	/// Ein Objekt das attribute wie titel usw. speichert
	/// </summary>
	public MangaAttribute attributes { get; set; }

	public Statistics? statistics { get; set; }
	
	public Cover cover { get; set; }
	
}

public class Cover{
	private string result { get; set; }
	private string response { get; set; }
	private coverData data { get; set; }
}

internal class coverData{
	
	private string id { get; set; }
	private string type { get; set; }
	private CoverAttributes attributes { get; set; }
	private CoverRelationships Relationships { get; set; }
	
	
}

internal class CoverRelationships{
	
	//Vermutlich ein Fehler ersetze dann mit List
	private RelationshipData[] RelationshipData { get; set; }
}

internal class RelationshipData{
	private string id { get; set; }
	private string type { get; set; }
}

internal class CoverAttributes{
	private string description { get; set; }
	private string volume { get; set; }
	private string filename { get; set; }
	private string locale { get; set; }
	private string createdAt { get; set; }
	private string updatedAt { get; set; }
	private int version { get; set; }

}

/// <summary>
/// Speichert Attribute eines Mangas der Mangadex API beispielswiese Titel
/// </summary>
public class MangaAttribute{
	
	/// <summary>
	/// Speichert die verschidensprachigen Titel des Mangas beipsielsweise Englisch
	/// </summary>
	public Title title { get; set; }
	
}

/// <summary>
/// Speichert die verschidensprachigen Titel eines Mangas beipsielsweise Englisch
/// </summary>
public class Title{

	/// <summary>
	/// Der Englische Titel eines Mangas
	/// </summary>
	public string en { get; set; }
	
}