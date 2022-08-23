
namespace MovieDB.Models;

 public class Actor
    {
        public bool adult { get; set; }
        public List<object> also_known_as { get; set; }
        public string? biography { get; set; }
        public object? birthday { get; set; }
        public object? deathday { get; set; }
        public int? gender { get; set; }
        public object? homepage { get; set; }
        public int id { get; set; }
        public string? imdb_id { get; set; }
        public string? known_for_department { get; set; }
        public string? name { get; set; }
        public object? place_of_birth { get; set; }
        public double popularity { get; set; }
        public object? profile_path { get; set; }
    }
