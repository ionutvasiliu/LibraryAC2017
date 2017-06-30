namespace LibraryAC.Services
{
    public interface IScoreService
    {
        int ComputeScore(int bookScore, int userScore);
    }
}
