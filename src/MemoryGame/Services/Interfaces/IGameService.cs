using MemoryGame.Models;

namespace MemoryGame.Services.Interfaces;

public interface IGameService
{
    public List<Card> GenerateCards(int pairs, GameDifficulty difficulty);

    public List<Card> Shuffle(List<Card> source);

    public bool AnyFlippableCards(IEnumerable<Card> cards);
}
