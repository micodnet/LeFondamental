namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        void Delete(int id);
        void Add(T entity);

    }
}