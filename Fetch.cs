namespace MovieDB;

public class Fetch{
    public PosterSet? posterSet;
    public Actor actor;
    public ProfileSet profileSet;
    public Movie? movie;
    public VideoSet? videoSet;
    public CastSet? castSet;
    public HttpClient client = new HttpClient();
    public const string API_KEY = "d194eb72915bc79fac2eb1a70a71ddd3";    
    public string Data { get; set; }
    public string Videos { get; set; }
    public string Cast {get; set; }
    public string? Details { get; set; }
    public string? Info { get; set; }
    public string? Profile {get; set;}
     
   public Fetch() { }

   
// A method that does an API Call that does a movie search
    public async Task Search(string search) {
        ClearHeaders();

        
        HttpResponseMessage response = 
            await client.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=" + 
            API_KEY + "&query=" + search);

        if(response.IsSuccessStatusCode) {
            Data = await response.Content.ReadAsStringAsync();
            //Taking the data from the search and placing it in the class that represents it
            posterSet = JsonSerializer.Deserialize<PosterSet>(Data);
        }
        else {
            Data = null;
        }


    } 


    //A method that calls to the API for the Cast Details
    public async Task GetMovieDetails(string movieID){
        ClearHeaders();

        HttpResponseMessage response = 
        await client.GetAsync("https://api.themoviedb.org/3/movie/" + movieID + "?api_key=" + API_KEY);

        if(response.IsSuccessStatusCode){
            Details = await response.Content.ReadAsStringAsync();
            movie = JsonSerializer.Deserialize<Movie>(Details);

        }

        response = await client.GetAsync("https://api.themoviedb.org/3/movie/" + movieID + "/videos?api_key=" +API_KEY);

        if(response.IsSuccessStatusCode){
            Videos = await response.Content.ReadAsStringAsync();
            videoSet = JsonSerializer.Deserialize<VideoSet>(Videos);

        }

        response = await client.GetAsync("https://api.themoviedb.org/3/movie/" + movieID + "/credits?api_key=" + API_KEY);

        if(response.IsSuccessStatusCode){
            Cast = await response.Content.ReadAsStringAsync();
            castSet = JsonSerializer.Deserialize<CastSet>(Cast);
            
        }

        
    }

    public async Task GetActorDetails(string id){
        ClearHeaders();

        HttpResponseMessage response =
        await client.GetAsync("https://api.themoviedb.org/3/person/" + id + "?api_key=" + API_KEY);

        if(response.IsSuccessStatusCode){
            Info = await response.Content.ReadAsStringAsync();
            actor = JsonSerializer.Deserialize<Actor>(Info);

        }

        response = await client.GetAsync("https://api.themoviedb.org/3/person/" + id + "/images?api_key=" + API_KEY);

        if(response.IsSuccessStatusCode){
            Profile = await response.Content.ReadAsStringAsync();
            profileSet = JsonSerializer.Deserialize<ProfileSet>(Profile);

        }
        
    }

       public void ClearHeaders() {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));
    } // ClearHeaders()
} // clss