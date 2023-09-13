namespace abv_api.Model
{
    public class Games
    {
        public int id_game { get; set; }
        public int id_team1 { get; set; }
        public int id_team2 { get; set; }
        public DateTime game_date { get; set; }
        public int id_set1 { get; set; }
        public int id_set2 { get; set; }
        public int? id_set3 { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public DateTime total_game_time { get; set; }
    }
}
