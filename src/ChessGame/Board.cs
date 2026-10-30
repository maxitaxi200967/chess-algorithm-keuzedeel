namespace ChessGame;

public class Board
{
    private readonly Piece[,] _squares = new Piece[8, 8];
    private readonly Stack<Move> _history = new();

    public PieceColor Turn { get; private set; } = PieceColor.White;

    public Board()
    {
        SetupInitialPosition();
    }

    public Piece GetPiece(int row, int col) => _squares[row, col];

    public void SetPiece(int row, int col, Piece piece) => _squares[row, col] = piece;

    // Zet de standaard schaakopstelling klaar
    public void SetupInitialPosition()
    {
        // Maak bord leeg
        for (int r = 0; r < 8; r++)
            for (int c = 0; c < 8; c++)
                _squares[r, c] = Piece.None;

        // Zwart (bovenkant bord, rijen 0 en 1)
        _squares[0, 0] = new Piece(PieceType.Rook, PieceColor.Black);
        _squares[0, 1] = new Piece(PieceType.Knight, PieceColor.Black);
        _squares[0, 2] = new Piece(PieceType.Bishop, PieceColor.Black);
        _squares[0, 3] = new Piece(PieceType.Queen, PieceColor.Black);
        _squares[0, 4] = new Piece(PieceType.King, PieceColor.Black);
        _squares[0, 5] = new Piece(PieceType.Bishop, PieceColor.Black);
        _squares[0, 6] = new Piece(PieceType.Knight, PieceColor.Black);
        _squares[0, 7] = new Piece(PieceType.Rook, PieceColor.Black);

        for (int c = 0; c < 8; c++)
            _squares[1, c] = new Piece(PieceType.Pawn, PieceColor.Black);

        // Wit (onderkant bord, rijen 6 en 7)
        for (int c = 0; c < 8; c++)
            _squares[6, c] = new Piece(PieceType.Pawn, PieceColor.White);

        _squares[7, 0] = new Piece(PieceType.Rook, PieceColor.White);
        _squares[7, 1] = new Piece(PieceType.Knight, PieceColor.White);
        _squares[7, 2] = new Piece(PieceType.Bishop, PieceColor.White);
        _squares[7, 3] = new Piece(PieceType.Queen, PieceColor.White);
        _squares[7, 4] = new Piece(PieceType.King, PieceColor.White);
        _squares[7, 5] = new Piece(PieceType.Bishop, PieceColor.White);
        _squares[7, 6] = new Piece(PieceType.Knight, PieceColor.White);
        _squares[7, 7] = new Piece(PieceType.Rook, PieceColor.White);

        Turn = PieceColor.White;
        _history.Clear();
    }

    // ==========================================
    // ZETTEN DOEN & TERUGDRAAIEN (BELANGRIJK VOOR JE ALGORITME!)
    // ==========================================

    /// <summary>
    /// Voert een zet uit op het bord.
    /// </summary>
    public void MakeMove(Move move)
    {
        _squares[move.FromRow, move.FromCol] = Piece.None;

        if (move.IsPromotion)
        {
            // Promoveer standaard naar Dame
            _squares[move.ToRow, move.ToCol] = new Piece(PieceType.Queen, move.MovedPiece.Color);
        }
        else
        {
            _squares[move.ToRow, move.ToCol] = move.MovedPiece;
        }

        _history.Push(move);
        Turn = (Turn == PieceColor.White) ? PieceColor.Black : PieceColor.White;
    }

    /// <summary>
    /// Maakt de laatste zet ongedaan. Onmisbaar voor Minimax/backtracking!
    /// </summary>
    public void UndoMove()
    {
        if (_history.Count == 0) return;

        Move lastMove = _history.Pop();
        _squares[lastMove.FromRow, lastMove.FromCol] = lastMove.MovedPiece;
        _squares[lastMove.ToRow, lastMove.ToCol] = lastMove.CapturedPiece;

        Turn = (Turn == PieceColor.White) ? PieceColor.Black : PieceColor.White;
    }

    /// <summary>
    /// Maakt een exacte kopie van het bord (handig als je niet met Undo wilt werken).
    /// </summary>
    public Board Clone()
    {
        var copy = new Board();
        for (int r = 0; r < 8; r++)
            for (int c = 0; c < 8; c++)
                copy._squares[r, c] = _squares[r, c];

        copy.Turn = Turn;
        return copy;
    }

    // ==========================================
    // EVALUATIE (DE SCORE VOOR JE ALGORITME)
    // ==========================================

    /// <summary>
    /// Geeft een score van het huidige bord.
    /// Positief getal = Wit staat voor.
    /// Negatief getal = Zwart staat voor.
    /// </summary>
    public int Evaluate()
    {
        int score = 0;
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                Piece piece = _squares[r, c];
                if (piece.IsEmpty) continue;

                if (piece.Color == PieceColor.White)
                    score += piece.Value;
                else
                    score -= piece.Value;
            }
        }
        return score;
    }

    // ==========================================
    // LEGALE ZETTEN GENEREREN
    // ==========================================

    /// <summary>
    /// Geeft alle 100% legale zetten voor de speler die aan de beurt is.
    /// </summary>
    public List<Move> GetLegalMoves()
    {
        var pseudoMoves = GetPseudoLegalMoves(Turn);
        var legalMoves = new List<Move>();

        foreach (var move in pseudoMoves)
        {
            PieceColor moverColor = move.MovedPiece.Color;
            MakeMove(move);

            // Een zet is alleen legaal als je eigen koning daarna NIET schaak staat
            if (!IsInCheck(moverColor))
            {
                legalMoves.Add(move);
            }

            UndoMove();
        }

        return legalMoves;
    }

    public bool IsInCheck(PieceColor color)
    {
        (int kRow, int kCol) = FindKing(color);
        if (kRow == -1) return false;

        PieceColor opponent = (color == PieceColor.White) ? PieceColor.Black : PieceColor.White;
        return IsSquareAttacked(kRow, kCol, opponent);
    }

    public bool IsCheckmate()
    {
        return IsInCheck(Turn) && GetLegalMoves().Count == 0;
    }

    public bool IsStalemate()
    {
        return !IsInCheck(Turn) && GetLegalMoves().Count == 0;
    }

    private (int, int) FindKing(PieceColor color)
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                Piece p = _squares[r, c];
                if (p.Type == PieceType.King && p.Color == color)
                    return (r, c);
            }
        }
        return (-1, -1);
    }

    private bool IsSquareAttacked(int targetRow, int targetCol, PieceColor byColor)
    {
        // 1. Aangevallen door Pionnen
        int pawnRow = (byColor == PieceColor.White) ? targetRow + 1 : targetRow - 1;
        if (pawnRow >= 0 && pawnRow < 8)
        {
            if (targetCol - 1 >= 0 && _squares[pawnRow, targetCol - 1].Type == PieceType.Pawn && _squares[pawnRow, targetCol - 1].Color == byColor)
                return true;
            if (targetCol + 1 < 8 && _squares[pawnRow, targetCol + 1].Type == PieceType.Pawn && _squares[pawnRow, targetCol + 1].Color == byColor)
                return true;
        }

        // 2. Aangevallen door Paard
        int[] knRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
        int[] knCol = { -1, 1, -2, 2, -2, 2, -1, 1 };
        for (int i = 0; i < 8; i++)
        {
            int r = targetRow + knRow[i];
            int c = targetCol + knCol[i];
            if (IsInBounds(r, c))
            {
                Piece p = _squares[r, c];
                if (p.Type == PieceType.Knight && p.Color == byColor)
                    return true;
            }
        }

        // 3. Aangevallen in rechte lijnen (Toren of Dame)
        int[] straightRow = { -1, 1, 0, 0 };
        int[] straightCol = { 0, 0, -1, 1 };
        for (int i = 0; i < 4; i++)
        {
            int r = targetRow + straightRow[i];
            int c = targetCol + straightCol[i];
            while (IsInBounds(r, c))
            {
                Piece p = _squares[r, c];
                if (!p.IsEmpty)
                {
                    if (p.Color == byColor && (p.Type == PieceType.Rook || p.Type == PieceType.Queen))
                        return true;
                    break;
                }
                r += straightRow[i];
                c += straightCol[i];
            }
        }

        // 4. Aangevallen in diagonale lijnen (Loper of Dame)
        int[] diagRow = { -1, -1, 1, 1 };
        int[] diagCol = { -1, 1, -1, 1 };
        for (int i = 0; i < 4; i++)
        {
            int r = targetRow + diagRow[i];
            int c = targetCol + diagCol[i];
            while (IsInBounds(r, c))
            {
                Piece p = _squares[r, c];
                if (!p.IsEmpty)
                {
                    if (p.Color == byColor && (p.Type == PieceType.Bishop || p.Type == PieceType.Queen))
                        return true;
                    break;
                }
                r += diagRow[i];
                c += diagCol[i];
            }
        }

        // 5. Aangevallen door Koning
        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0) continue;
                int r = targetRow + dr;
                int c = targetCol + dc;
                if (IsInBounds(r, c))
                {
                    Piece p = _squares[r, c];
                    if (p.Type == PieceType.King && p.Color == byColor)
                        return true;
                }
            }
        }

        return false;
    }

    private List<Move> GetPseudoLegalMoves(PieceColor color)
    {
        var moves = new List<Move>();

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                Piece p = _squares[r, c];
                if (p.IsEmpty || p.Color != color) continue;

                switch (p.Type)
                {
                    case PieceType.Pawn:
                        GeneratePawnMoves(r, c, p, moves);
                        break;
                    case PieceType.Knight:
                        GenerateKnightMoves(r, c, p, moves);
                        break;
                    case PieceType.Bishop:
                        GenerateRayMoves(r, c, p, moves, new[] { -1, -1, 1, 1 }, new[] { -1, 1, -1, 1 });
                        break;
                    case PieceType.Rook:
                        GenerateRayMoves(r, c, p, moves, new[] { -1, 1, 0, 0 }, new[] { 0, 0, -1, 1 });
                        break;
                    case PieceType.Queen:
                        GenerateRayMoves(r, c, p, moves, new[] { -1, 1, 0, 0, -1, -1, 1, 1 }, new[] { 0, 0, -1, 1, -1, 1, -1, 1 });
                        break;
                    case PieceType.King:
                        GenerateKingMoves(r, c, p, moves);
                        break;
                }
            }
        }

        return moves;
    }

    private void GeneratePawnMoves(int r, int c, Piece p, List<Move> moves)
    {
        int forward = (p.Color == PieceColor.White) ? -1 : 1;
        int startRow = (p.Color == PieceColor.White) ? 6 : 1;
        int promoRow = (p.Color == PieceColor.White) ? 0 : 7;

        // 1 stap vooruit
        int nextR = r + forward;
        if (IsInBounds(nextR, c) && _squares[nextR, c].IsEmpty)
        {
            bool isPromo = (nextR == promoRow);
            moves.Add(new Move(r, c, nextR, c, p, Piece.None, isPromo));

            // 2 stappen vooruit vanaf startrij
            int doubleR = r + (forward * 2);
            if (r == startRow && _squares[doubleR, c].IsEmpty)
            {
                moves.Add(new Move(r, c, doubleR, c, p, Piece.None, false));
            }
        }

        // Schuin slaan
        int[] captureCols = { c - 1, c + 1 };
        foreach (int capC in captureCols)
        {
            if (IsInBounds(nextR, capC))
            {
                Piece target = _squares[nextR, capC];
                if (!target.IsEmpty && target.Color != p.Color)
                {
                    bool isPromo = (nextR == promoRow);
                    moves.Add(new Move(r, c, nextR, capC, p, target, isPromo));
                }
            }
        }
    }

    private void GenerateKnightMoves(int r, int c, Piece p, List<Move> moves)
    {
        int[] dr = { -2, -2, -1, -1, 1, 1, 2, 2 };
        int[] dc = { -1, 1, -2, 2, -2, 2, -1, 1 };

        for (int i = 0; i < 8; i++)
        {
            int nr = r + dr[i];
            int nc = c + dc[i];
            if (IsInBounds(nr, nc))
            {
                Piece target = _squares[nr, nc];
                if (target.IsEmpty || target.Color != p.Color)
                {
                    moves.Add(new Move(r, c, nr, nc, p, target));
                }
            }
        }
    }

    private void GenerateRayMoves(int r, int c, Piece p, List<Move> moves, int[] dr, int[] dc)
    {
        for (int i = 0; i < dr.Length; i++)
        {
            int nr = r + dr[i];
            int nc = c + dc[i];

            while (IsInBounds(nr, nc))
            {
                Piece target = _squares[nr, nc];
                if (target.IsEmpty)
                {
                    moves.Add(new Move(r, c, nr, nc, p, Piece.None));
                }
                else
                {
                    if (target.Color != p.Color)
                    {
                        moves.Add(new Move(r, c, nr, nc, p, target));
                    }
                    break; // Geblokkeerd door een stuk
                }

                nr += dr[i];
                nc += dc[i];
            }
        }
    }

    private void GenerateKingMoves(int r, int c, Piece p, List<Move> moves)
    {
        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0) continue;
                int nr = r + dr;
                int nc = c + dc;
                if (IsInBounds(nr, nc))
                {
                    Piece target = _squares[nr, nc];
                    if (target.IsEmpty || target.Color != p.Color)
                    {
                        moves.Add(new Move(r, c, nr, nc, p, target));
                    }
                }
            }
        }
    }

    private static bool IsInBounds(int r, int c) => r >= 0 && r < 8 && c >= 0 && c < 8;

    // ==========================================
    // WEERGAVE IN DE CONSOLE
    // ==========================================

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("    a   b   c   d   e   f   g   h");
        Console.WriteLine("  +---+---+---+---+---+---+---+---+");

        for (int r = 0; r < 8; r++)
        {
            int rank = 8 - r;
            Console.Write($"{rank} |");

            for (int c = 0; c < 8; c++)
            {
                Piece p = _squares[r, c];
                char sym = p.Symbol;

                if (p.IsEmpty)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" . ");
                }
                else if (p.Color == PieceColor.White)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" {sym} ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {sym} ");
                }

                Console.ResetColor();
                Console.Write("|");
            }

            Console.WriteLine($" {rank}");
            Console.WriteLine("  +---+---+---+---+---+---+---+---+");
        }

        Console.WriteLine("    a   b   c   d   e   f   g   h");
        Console.WriteLine();
    }

    /// <summary>
    /// Probeert een invoer zoals 'e2e4' of 'e2 e4' om te zetten naar een legale zet.
    /// </summary>
    public bool TryParseMove(string input, out Move legalMove)
    {
        legalMove = default;
        input = input.Trim().Replace(" ", "").ToLower();

        if (input.Length != 4) return false;

        int fromCol = input[0] - 'a';
        int fromRow = 8 - (input[1] - '0');
        int toCol = input[2] - 'a';
        int toRow = 8 - (input[3] - '0');

        if (!IsInBounds(fromRow, fromCol) || !IsInBounds(toRow, toCol)) return false;

        foreach (var move in GetLegalMoves())
        {
            if (move.Equals(fromRow, fromCol, toRow, toCol))
            {
                legalMove = move;
                return true;
            }
        }

        return false;
    }
}
