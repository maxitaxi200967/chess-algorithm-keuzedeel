namespace ChessGame;

public struct Move
{
    public int FromRow { get; }
    public int FromCol { get; }
    public int ToRow { get; }
    public int ToCol { get; }
    public Piece MovedPiece { get; }
    public Piece CapturedPiece { get; }
    public bool IsPromotion { get; }

    public Move(int fromRow, int fromCol, int toRow, int toCol, Piece movedPiece, Piece capturedPiece = default, bool isPromotion = false)
    {
        FromRow = fromRow;
        FromCol = fromCol;
        ToRow = toRow;
        ToCol = toCol;
        MovedPiece = movedPiece;
        CapturedPiece = capturedPiece;
        IsPromotion = isPromotion;
    }

    // Zet om naar bijvoorbeeld "e2e4"
    public override string ToString()
    {
        char fromFile = (char)('a' + FromCol);
        int fromRank = 8 - FromRow;
        char toFile = (char)('a' + ToCol);
        int toRank = 8 - ToRow;

        return $"{fromFile}{fromRank}{toFile}{toRank}";
    }

    // Handige methode om te controleren of twee zetten hetzelfde zijn
    public bool Equals(int fromRow, int fromCol, int toRow, int toCol)
    {
        return FromRow == fromRow && FromCol == fromCol && ToRow == toRow && ToCol == toCol;
    }
}
