namespace abv_api.Model
{
    public class Classification
    {
        public int id_classification { get; set; }
        public int id_game { get; set; }
        public string name { get; set; }
        public int classif { get; set; }
        public int pts { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
        public int sp { get; set; }
        public int sc { get; set; }
        public int ss { get; set; }
        public int pp { get; set; }
        public int pc { get; set; }
        public int points_balance { get; set; }
    }
}
