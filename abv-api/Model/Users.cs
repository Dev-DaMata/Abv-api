namespace abv_api.Model
{
    public class Users
    {
        public int id_user { get; set; }
        public int id_type_user { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int rg { get; set; }
        public DateOnly date_of_birth { get; set; }
    }
}
