namespace ChessGame;

/// <summary>
/// Hier komt jouw eigen schaakalgoritme!
/// Dit bestand is speciaal ingericht zodat jij stap voor stap jouw algoritme (zoals Minimax)
/// kunt bouwen bovenop het schaakbord.
/// </summary>
public static class ChessAI
{
    private static readonly Random _random = new();

    /// <summary>
    /// Deze methode kiest de beste zet voor de computer.
    /// Nu kiest hij nog een willekeurige zet of een directe slagzet.
    /// Hier kun jij later jouw Minimax-algoritme aanroepen!
    /// </summary>
    public static Move ChooseMove(Board board)
    {
        List<Move> legalMoves = board.GetLegalMoves();

        if (legalMoves.Count == 0)
        {
            return default;
        }

        // =========================================================================
        // STAP VOOR DE TOEKOMST: HIER ROEP JE JOUW MINIMAX AAN!
        // Voorbeeld:
        // return FindBestMoveWithMinimax(board, depth: 3);
        // =========================================================================

        // SIMPELE PLACEHOLDER VOOR NU:
        // 1. Als we een stuk kunnen slaan, kies die met voorrang.
        var captureMoves = legalMoves.FindAll(m => !m.CapturedPiece.IsEmpty);
        if (captureMoves.Count > 0)
        {
            return captureMoves[_random.Next(captureMoves.Count)];
        }

        // 2. Anders een willekeurige legale zet
        return legalMoves[_random.Next(legalMoves.Count)];
    }

    // =============================================================================
    // UITLEG & TEMPLATE VOOR JOUW MINIMAX ALGORITME (WEEK 12 t/m 14 UIT DE PLANNING)
    // =============================================================================
    /*
    public static Move FindBestMoveWithMinimax(Board board, int depth)
    {
        Move bestMove = default;
        int bestScore = int.MinValue; // Zwart wil minimaliseren of Wit maximaliseren

        foreach (var move in board.GetLegalMoves())
        {
            board.MakeMove(move);
            int score = Minimax(board, depth - 1, isMaximizing: false);
            board.UndoMove();

            if (score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }

        return bestMove;
    }

    private static int Minimax(Board board, int depth, bool isMaximizing)
    {
        // Stopconditie: diepte bereikt of potje afgelopen
        if (depth == 0 || board.GetLegalMoves().Count == 0)
        {
            return board.Evaluate();
        }

        if (isMaximizing)
        {
            int maxEval = int.MinValue;
            foreach (var move in board.GetLegalMoves())
            {
                board.MakeMove(move);
                int eval = Minimax(board, depth - 1, false);
                board.UndoMove();
                maxEval = Math.Max(maxEval, eval);
            }
            return maxEval;
        }
        else
        {
            int minEval = int.MaxValue;
            foreach (var move in board.GetLegalMoves())
            {
                board.MakeMove(move);
                int eval = Minimax(board, depth - 1, true);
                board.UndoMove();
                minEval = Math.Min(minEval, eval);
            }
            return minEval;
        }
    }
    */
}
