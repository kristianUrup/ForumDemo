namespace UserAPI.Repository
{
    public interface IDbInitializer
    {
        void InitializeDatabase(UserApiContext userContext);
    }
}