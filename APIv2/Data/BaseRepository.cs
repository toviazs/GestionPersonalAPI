namespace APIv2.Data
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly PersonalDB _personalDb;
        public BaseRepository(PersonalDB personalDb)
        {
            _personalDb = personalDb;
        }
        public void SaveChanges()
        {
            _personalDb.SaveChanges();
        }
    }
}
