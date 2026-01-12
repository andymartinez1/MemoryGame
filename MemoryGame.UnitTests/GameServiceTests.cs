using MemoryGame.Models;
using MemoryGame.Services;
using MemoryGame.Services.Interfaces;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject1;

public class GameServiceTests
{
    private readonly Mock<IGameService> _gameServiceMock;
    private readonly GameService _gameService;

    public GameServiceTests()
    {
        _gameServiceMock = new Mock<IGameService>();
        _gameService = new GameService();
    }

    [Fact]
    public void GenerateCards()
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    public void Shuffle()
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    public void AnyFlippableCards_ReturnsTrue_WhenUnmatchedAndUnflipped()
    {
        // Arrange
        var cards = new List<Card>
        {
            new() { Id = 1, IsMatched = true, IsFlipped = false },
            new() { Id = 2, IsMatched = false, IsFlipped = false },
            new() { Id = 3, IsMatched = false, IsFlipped = true }
        };

        // Assert
        Assert.True(_gameService.AnyFlippableCards(cards));
    }

    [Fact]
    public void AnyFlippableCards_ReturnsFalse_WhenNoneAvailable()
    {
        var cards = new List<Card>
        {
            new() { Id = 1, IsMatched = true, IsFlipped = false },
            new() { Id = 2, IsMatched = true, IsFlipped = false },
            new() { Id = 3, IsMatched = false, IsFlipped = true }
        };

        Assert.False(_gameService.AnyFlippableCards(cards));
    }
}