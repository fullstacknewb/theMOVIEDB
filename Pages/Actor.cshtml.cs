namespace MovieDB;

public class ActorModel : PageModel{
    public Fetch fetch = new Fetch();
    public string actorID = "";
    public async Task OnGet(string id) {
        actorID = id;
        
        await fetch.GetActorDetails(id); 
    }
}