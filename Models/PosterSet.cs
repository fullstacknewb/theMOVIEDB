namespace MovieDB.Models;

//Collection of movies.. Right after search
 public class PosterSet
    {
        public int page { get; set; }
        public List<Poster> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }