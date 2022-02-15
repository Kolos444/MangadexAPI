namespace MangadexAPI;

public class APIRequestStatistic{
	public string result { get; set; }
	
	public Dictionary<string,Statistics> statistics { get; set; }
	
}

public class Statistics{
	
	/// <summary>
	/// Beinhaltet die Bewertung eines Mangas
	/// </summary>
	public Rating rating { get; set; }
	
	/// <summary>
	/// Gibt die derzeitigen follower an
	/// </summary>
	public int follows { get; set; }
	
}

/// <summary>
/// Beeinhaltet die Bewertungen eines Mangas
/// </summary>
public class Rating{
	
	/// <summary>
	/// Die durschnittliche Bewertung des Mangas
	/// </summary>
	public double average { get; set; }
	
}