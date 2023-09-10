namespace abv_api.Model
{
    public class Sets
    {
        public int id_set { get; set; }
        public int id_team1 { get; set; }
        public int id_team2 { get; set; }
        public string pts_team1 { get; set; }
        public string pts_team2 { get; set; }
        public int id_replacement_team1 { get; set; }
        public int id_replacement_team2 { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set;}
        public int game { get; set; }
    }
}
