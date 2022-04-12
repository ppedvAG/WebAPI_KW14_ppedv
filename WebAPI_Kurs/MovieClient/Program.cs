//7184

using Newtonsoft.Json;
using SharedLib;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

Console.WriteLine("Bitte drücke Key, wenn Service verfügbar ist");
Console.ReadKey();


//WebClient webClient = new WebClient();
//
string baseUrl = "https://localhost:7184/api/Movies/";
HttpClient client = new HttpClient();


#region GET Methode via HttpClient
HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, baseUrl);
httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//HttpResponseMessage responseMessage = client.SendAsync(httpRequestMessage).Result;

HttpResponseMessage responseMessage = await client.SendAsync(httpRequestMessage);
string jsonText = await responseMessage.Content.ReadAsStringAsync(); //wir lesen die JSON Struktur aus der ResponseMessage heraus

List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonText);

foreach (Movie currentMovie in movies)
{
    Console.WriteLine($"{currentMovie.Id} {currentMovie.Title} {currentMovie.Description} {Enum.GetName(typeof(MovieGenre), currentMovie.Genre)}");
}


#endregion

#region GetById
//https://localhost:7184/api/Movies/1
string extendedURL = baseUrl + "3";

HttpResponseMessage response1 = await client.GetAsync(extendedURL);
jsonText = await response1.Content.ReadAsStringAsync();
Movie movie = JsonConvert.DeserializeObject<Movie>(jsonText);
Console.WriteLine($"{movie.Id} {movie.Title} {movie.Description} {Enum.GetName(typeof(MovieGenre), movie.Genre)}");


#endregion


#region POST 

movie = new Movie()
{
    Title = "Batman",
    Description = "Batman und Joker gründen weitere WG",
    Genre = MovieGenre.Comedy
};
//jsonText = JsonConvert.SerializeObject(currentMovies, Formatting.Indented);
jsonText = JsonConvert.SerializeObject(movie);
StringContent body = new StringContent(jsonText, Encoding.UTF8, "application/json");

HttpResponseMessage response2 = await client.PostAsync(baseUrl, body);
response2.StatusCode.ToString();



#endregion


#region Put
extendedURL = baseUrl + "5";

response1 = await client.GetAsync(extendedURL);
jsonText = await response1.Content.ReadAsStringAsync();
movie = JsonConvert.DeserializeObject<Movie>(jsonText);



movie.Description = "Robin ist back";
string extendetURL2 = baseUrl + movie.Id;
jsonText = JsonConvert.SerializeObject(movie);
body = new StringContent(jsonText, Encoding.UTF8, "application/json");
HttpResponseMessage response3 = await client.PutAsync(extendetURL2, body);
Console.WriteLine(response3.StatusCode.ToString());
#endregion