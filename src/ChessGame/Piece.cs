namespace ChessGame;

public enum PieceColor
{
    None = 0,
    White = 1,
    Black = 2
}

public enum PieceType
{
    None = 0,
    Pawn = 1,
    Knight = 2,
    Bishop = 3,
    Rook = 4,
    Queen = 5,
    King = 6
}

public struct Piece
{
    public PieceType Type { get; set; }
    public PieceColor Color { get; set; }

    public Piece(PieceType type, PieceColor color)
    {
        Type = type;
        Color = color;
    }

    public static Piece None => new Piece(PieceType.None, PieceColor.None);

    public bool IsEmpty => Type == PieceType.None;

    // Basiswaarde van de stukken (ideaal voor je algoritme / Minimax)
    public int Value => Type switch
    {
        PieceType.Pawn => 100,
        PieceType.Knight => 320,
        PieceType.Bishop => 330,
        PieceType.Rook => 500,
        PieceType.Queen => 900,
        PieceType.King => 20000,
        _ => 0
    };

    // Stuk-karakter voor weergave in de console (Hoofdletter = Wit, kleine letter = Zwart)
    public char Symbol => (Type, Color) switch
    {
        (PieceType.Pawn, PieceColor.White) => 'P',
        (PieceType.Knight, PieceColor.White) => 'N',
        (PieceType.Bishop, PieceColor.White) => 'B',
        (PieceType.Rook, PieceColor.White) => 'R',
        (PieceType.Queen, PieceColor.White) => 'Q',
        (PieceType.King, PieceColor.White) => 'K',

        (PieceType.Pawn, PieceColor.Black) => 'p',
        (PieceType.Knight, PieceColor.Black) => 'n',
        (PieceType.Bishop, PieceColor.Black) => 'b',
        (PieceType.Rook, PieceColor.Black) => 'r',
        (PieceType.Queen, PieceColor.Black) => 'q',
        (PieceType.King, PieceColor.Black) => 'k',

        _ => '.'
    };
}
