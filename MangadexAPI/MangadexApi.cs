using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MangadexAPI;

public class MangadexAPI{
	
	/// <summary>
	/// Der globale client mit dem Http requests geschickt werden.
	/// </summary>
	private static readonly HttpClient client = new();
	
	/// <summary>
	/// Die daten des aktiven Nutzers
	/// </summary>
	private static Account? account;
	
	
	private static Manga[] mangaSortRankingDesc(Manga[] mangas) {
		return mangas.OrderByDescending(a => a.statistics.rating.average).ToArray();
	}

	/// <summary>
	/// Setzt den Authentication Header auf den aktiven Token
	/// </summary>
	private static void setTokenAuth(Account account) {
		if (account != null)
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.token);
		else
			accountLogin();
	}
	/// <summary>
	/// Setzt denn Http Header für standard Anfragen
	/// </summary>
	private static void setHttpHeader(HttpClient client) {
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
	}

	/// <summary>
	/// Nutzer soll sich einloggen
	/// </summary>
	private static void accountLogin() {
		throw new NotImplementedException();
	}

	/// <summary>
	/// Aktiviert den gespeicherten Account
	/// </summary>
	/// <returns>Der gespeicherte Account</returns>
	private static async Task getAccountFromFile() {
		account = JsonSerializer.Deserialize<Account>(
			await File.ReadAllTextAsync("../../../../Login.json"));
	}

	/// <summary>
	/// Besorgt die ratings der Mangas
	/// </summary>
	/// <param name="mangas">Array der gewünschten Mangas</param>
	/// <returns>Manga Array der Mangas mit ratings</returns>
	private static async Task ratingRequest(Manga[] mangas) {
		int i = 0;
		while (i < mangas.GetLength(0)){
			string httpRequest = "https://api.mangadex.org/statistics/manga?";

			for (int tmpI = 0; tmpI < 100; i++,tmpI++){
				httpRequest += "manga[]=" + mangas[i].id + "&";
			}	
		
			Task<Stream>         stream    = client.GetStreamAsync(httpRequest);
			APIRequestStatistic? tmpMangas = await JsonSerializer.DeserializeAsync<APIRequestStatistic>(await stream);

			i -= 100;
			for (int tmpI = 0; tmpI < 100; tmpI++, i++){
				mangas[i].statistics = tmpMangas?.statistics[mangas[i].id];
			}
		}
	}

	/// <summary>
	/// Besorgt einen aktiven Token von der MangaDex API
	/// </summary>
	/// <param name="account">Der Account desen Token besorgt werden soll</param>
	/// <returns>Den aktiven string Token</returns>
	private static async Task<APIRequest?> authLogin(Account account) {
		AuthPost authPost = new() { username = account?.username, password = account?.password };

		StringContent payload = new(JsonSerializer.Serialize(authPost), Encoding.UTF8, "application/json");

		HttpResponseMessage ergebnis = await client.PostAsync("https://api.mangadex.org/auth/login", payload);

		return JsonSerializer.Deserialize<APIRequest>(await ergebnis.Content.ReadAsStreamAsync());
	}

	/// <summary>
	/// Besorgt die variable meist gefolgten Mangas von MangaDex
	/// </summary>
	/// <param name="top">Anzahl der gewünschten Mangas</param>
	/// <returns>Manga Array</returns>
	private static async Task<Manga[]> getMostFollowedMangas(int top) {
		Manga[] mangas = new Manga[top];
		int     offset = 0;
		for (int i = 0; i < top && offset<top;i+=100){
			string       requestUri = "https://api.mangadex.org/manga?order[followedCount]=desc&limit=100&offset=" + offset.ToString();
			Task<Stream> streamTask                                                = client.GetStreamAsync(requestUri);
			
			APIRequest? tmpMangas = await JsonSerializer.DeserializeAsync<APIRequest>(await streamTask);
			
			foreach (Manga manga in tmpMangas?.data!){
				
				mangas[offset] = manga;
				offset++;
				
			}
		}

		return mangas;
	}
}
