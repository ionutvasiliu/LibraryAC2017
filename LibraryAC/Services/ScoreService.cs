namespace LibraryAC.Services
{
    public class ScoreService : IScoreService
    {
        public int ComputeScore(int bookScore, int userScore)
        {
            if(bookScore < 0)
            {
                return userScore;
            }

            if(userScore < 0)
            {
                return 0;
            }

            return bookScore + userScore;
        }
    }
}
