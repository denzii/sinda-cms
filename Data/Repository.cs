namespace SindaCMS.Data
{
    public class Repository
    {
        private readonly DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

    }
}
