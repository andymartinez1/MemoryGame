namespace MemoryGame.Models;

public class GameHistoryEntry
{
    public int GameNumber { get; set; }

    public GameDifficulty Difficulty { get; set; }

    public TimeSpan Duration { get; set; }
}