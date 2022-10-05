[System.Serializable]
public class MenuData
{
    public string BestScorePlayer;
    public int BestScorePoints;

    public MenuData(string player, int points)
    {
        this.BestScorePlayer = player;
        this.BestScorePoints = points;
    }
}
