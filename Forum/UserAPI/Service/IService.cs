namespace UserAPI.Service
{
    public interface IService<T>
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}