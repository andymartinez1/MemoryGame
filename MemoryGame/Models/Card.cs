namespace MemoryGame.Models;

public class Card
{
    public int Id { get; set; }

    public Color Color { get; set; }

    public int Number { get; set; }

    public bool IsFlipped { get; set; }

    public bool IsMatched { get; set; }
}

public enum Color
{
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple
}