namespace BusinessLogicLayer.Interfaces
{
    public interface Iservice<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T model);
        void Delete(int id);
        void Add(T model);
    }
}