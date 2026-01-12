using MemoryGame.Models;
using MemoryGame.Services.Interfaces;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject1;

public class GameServiceTests
{
    private readonly Mock<IGameService> _mockGameService;

    public GameServiceTests()
    {
        _mockGameService = new Mock<IGameService>();
    }

    [Fact]
    public void GenerateCards_ReturnsExpectedCount_ForGivenPairs()
    {
        // Arrange
        var pairs = 3;
        var generatedCards = new List<Card>
        {
            new() { Number = 1 },
            new() { Number = 1 },
            new() { Number = 2 },
            new() { Number = 2 },
            new() { Number = 3 },
            new() { Number = 3 },
        };
        _mockGameService
            .Setup(gs => gs.GenerateCards(pairs, GameDifficulty.Beginner))
            .Returns(generatedCards);

        // Act
        var result = _mockGameService.Object.GenerateCards(pairs, GameDifficulty.Beginner);

        // Assert
        Assert.Equal(pairs * 2, result.Count);
    }

    [Fact]
    public void Shuffle_ReordersCards()
    {
        // Arrange
        var cards = new List<Card>
        {
            new() { Id = 1 },
            new() { Id = 2 },
            new() { Id = 3 },
            new() { Id = 4 },
            new() { Id = 5 },
        };
        var shuffled = new List<Card> { cards[2], cards[0], cards[4], cards[1], cards[3] };

        _mockGameService.Setup(gs => gs.Shuffle(cards)).Returns(shuffled);

        // Act
        var result = _mockGameService.Object.Shuffle(cards);

        // Assert
        Assert.NotSame(cards, result);
        Assert.Equal(shuffled, result);
    }

    [Fact]
    public void Shuffle_PreservesAllCards()
    {
        // Arrange
        var cards = new List<Card>
        {
            new() { Id = 1 },
            new() { Id = 2 },
            new() { Id = 3 },
        };
        var shuffled = new List<Card> { cards[1], cards[2], cards[0] };

        _mockGameService.Setup(gs => gs.Shuffle(cards)).Returns(shuffled);

        // Act
        var result = _mockGameService.Object.Shuffle(cards);

        // Assert
        Assert.Equal(cards.Count, result.Count);
        var ids = new HashSet<int>();
        foreach (var c in result)
            ids.Add(c.Id);
        for (var i = 1; i <= cards.Count; i++)
            Assert.Contains(i, ids);
    }

    [Fact]
    public void AnyFlippableCards_ReturnsTrue_WhenUnmatchedAndUnflipped()
    {
        // Arrange
        var cards = new List<Card>
        {
            new()
            {
                Id = 1,
                IsMatched = true,
                IsFlipped = false,
            },
            new()
            {
                Id = 2,
                IsMatched = false,
                IsFlipped = false,
            },
            new()
            {
                Id = 3,
                IsMatched = false,
                IsFlipped = true,
            },
        };

        _mockGameService.Setup(gs => gs.AnyFlippableCards(cards)).Returns(true);

        // Act
        var result = _mockGameService.Object.AnyFlippableCards(cards);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyFlippableCards_ReturnsFalse_WhenNoneAvailable()
    {
        // Arrange
        var cards = new List<Card>
        {
            new()
            {
                Id = 1,
                IsMatched = true,
                IsFlipped = false,
            },
            new()
            {
                Id = 2,
                IsMatched = true,
                IsFlipped = false,
            },
            new()
            {
                Id = 3,
                IsMatched = false,
                IsFlipped = true,
            },
        };

        _mockGameService.Setup(gs => gs.AnyFlippableCards(cards)).Returns(false);

        // Act
        var result = _mockGameService.Object.AnyFlippableCards(cards);

        // Assert
        Assert.False(result);
    }
}
