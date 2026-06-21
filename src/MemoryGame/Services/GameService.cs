using MemoryGame.Models;
using MemoryGame.Services.Interfaces;

namespace MemoryGame.Services;

public class GameService : IGameService
{
    private readonly Random _rng = new();

    public List<Card> GenerateCards(int pairs, GameDifficulty difficulty)
    {
        var cardList = new List<Card>();
        var colors = Enum.GetValues<Color>();
        for (var i = 0; i < pairs; i++)
        {
            var number = i + 1;
            var color = colors[i % colors.Length];
            var cardA = new Card
            {
                Number = number,
                Color = color,
                GameDifficulty = difficulty,
            };
            var cardB = new Card
            {
                Number = number,
                Color = color,
                GameDifficulty = difficulty,
            };
            cardList.Add(cardA);
            cardList.Add(cardB);
        }

        return Shuffle(cardList);
    }

    public List<Card> Shuffle(List<Card> source)
    {
        return source.OrderBy(_ => _rng.Next()).ToList();
    }

    public bool AnyFlippableCards(IEnumerable<Card> cards)
    {
        return cards.Any(c => !c.IsMatched && !c.IsFlipped);
    }
}
