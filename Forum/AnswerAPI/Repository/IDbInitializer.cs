namespace AnswerAPI.Repository
{
    public interface IDbInitializer
    {
        void InitializeDatabase(AnswerApiContext answerApiContext);
    }
}