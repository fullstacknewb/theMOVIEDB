
namespace MovieDB.Pages;

public class IndexModel : PageModel
{
    public int maxVideos = 3; 
    public int maxCast = 8;
    public Fetch fetch = new Fetch();
    public void OnGet() { }

    public async Task OnPostMovieSearch(string search) {
        //Calls search method in Fetch class
        await fetch.Search(search);

    } // OnPostMovieSearch()
    public async Task OnPostMovieDetails(string movieID){
        await fetch.GetMovieDetails(movieID);
        int vidCount = fetch.videoSet.results.Count;
        if(vidCount < maxVideos){
            maxVideos = vidCount;
        }

    } //OnPostMovieDetails

    public async Task OnPostGetActor(string actorID){
        Response.Redirect("/Actor?id=" + actorID);
    }
} // class

