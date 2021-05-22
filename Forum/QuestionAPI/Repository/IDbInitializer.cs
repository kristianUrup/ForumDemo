namespace QuestionAPI.Repository
{
    public interface IDbInitializer
    {
        void InitializeDatabase(QuestionApiContext questionApiContext);
    }
}